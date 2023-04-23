using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarCanvas : MonoBehaviour
{
    [SerializeField] Transform _playerCamera;

    private void Awake() {
        _playerCamera = FindObjectOfType<PlayerTag>().GetComponentInChildren<Camera>().transform;
    }

    private void Update() {
        Vector3 towards = new Vector3(_playerCamera.position.x, transform.position.y, _playerCamera.position.z);
        transform.LookAt(towards);
        transform.Rotate(0,180,0);
    }
}
