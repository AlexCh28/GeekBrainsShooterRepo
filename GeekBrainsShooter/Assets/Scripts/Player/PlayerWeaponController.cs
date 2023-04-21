using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    private IWeapon[] _weapons;
    private IWeapon _currentWeapon;
    private PlayerInput _playerInput;
    private int _activeWeaponIndex;

    private void Awake() {
        _weapons = GetComponentsInChildren<IWeapon>();
        _currentWeapon = _weapons[_activeWeaponIndex];

        DisableMeshRendererAll(_weapons);
        SetMeshRenderer((Weapon)_currentWeapon, true);

        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update() {
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
        SetMeshRenderer((Weapon)_currentWeapon, true);
    }
}
