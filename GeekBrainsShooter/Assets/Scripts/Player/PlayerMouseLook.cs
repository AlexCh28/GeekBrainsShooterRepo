using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerCamera;
    [SerializeField]
    private float horSens = 1;
    [SerializeField]
    private float verSens = 1;

    private PlayerInput _playerInput;

    private float deltaX;
    private float deltaY;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _playerInput = GetComponent<PlayerInput>();

        deltaX = 0;
        deltaY = 0;
    }

    private void Update() {

        deltaX += _playerInput.MouseX*horSens;
        deltaY -= _playerInput.MouseY*verSens;

        Vector3 newCharacterRotation = new Vector3(0, deltaX, 0);

        transform.localEulerAngles = newCharacterRotation;

        Vector3 newCameraRotation = new Vector3(deltaY, 0, 0);

        _playerCamera.transform.localEulerAngles = newCameraRotation;
    }
}
