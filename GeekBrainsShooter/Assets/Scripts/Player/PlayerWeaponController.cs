using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    private IWeapon _currentWeapon;

    private void Awake() {
        _currentWeapon = GetComponentInChildren<IWeapon>();
    }
}
