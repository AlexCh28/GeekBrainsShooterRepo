using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField]
    private RigBuilder _rigBuilder;
    [SerializeField]
    private TwoBoneIKConstraint _constraint;
    private IWeapon[] _weapons;
    private IWeapon _currentWeapon;
    private PlayerInput _playerInput;
    private int _activeWeaponIndex;

    private void Awake() {
        _weapons = GetComponentsInChildren<IWeapon>();
        _currentWeapon = _weapons[_activeWeaponIndex];

        DisableMeshRendererAll(_weapons);
        Weapon weapon = (Weapon)_currentWeapon;
        SetMeshRenderer(weapon, true);
        _constraint.data.target = weapon.Anchor;
        _rigBuilder.Build();

        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update() {
        if (GameManager.singleton.IsPause) return;
        if (_playerInput.FireKeyPressed) {
            _currentWeapon.Fire();
        }
        else if (_playerInput.ScrollUp){
            _activeWeaponIndex = _activeWeaponIndex+1 >= _weapons.Length ? 0 : _activeWeaponIndex + 1;
            ChangeWeapon();
        }
        else if (_playerInput.ScrollDown){
            _activeWeaponIndex = _activeWeaponIndex-1 < 0 ? _weapons.Length-1 : _activeWeaponIndex - 1;
            ChangeWeapon();
        }
    }

    private void DisableMeshRendererAll(IWeapon[] weapons){
        foreach(Weapon weapon in weapons){
            weapon.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void SetMeshRenderer(Weapon weapon, bool value){
        weapon.GetComponent<MeshRenderer>().enabled = value;
    }

    private void ChangeWeapon(){
        SetMeshRenderer((Weapon)_currentWeapon, false);
        _currentWeapon = _weapons[_activeWeaponIndex];

        Weapon weapon = (Weapon)_currentWeapon;
        SetMeshRenderer(weapon, true);
        _constraint.data.target = weapon.Anchor;
        _rigBuilder.Build();
    }
}
