using System;
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
        _currentWeapon = _weapons[_activeWeaponIndex+1];

        DisableMeshRendererAll(_weapons);
        EnableMeshRenderer((Weapon)_currentWeapon);

        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update() {
        if (_playerInput.FireKeyPressed) {
            _currentWeapon.Fire();
        }
        else if (_playerInput.ScrollUp){

        }
        else if (_playerInput.ScrollDown){

        }
    }

    private void DisableMeshRendererAll(IWeapon[] weapons){
        foreach(Weapon weapon in weapons){
            weapon.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void EnableMeshRenderer(Weapon weapon){
        weapon.GetComponent<MeshRenderer>().enabled = true;
    }
}
