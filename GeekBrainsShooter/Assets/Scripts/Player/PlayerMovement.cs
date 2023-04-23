using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 2.0f;
    [SerializeField]
    private float _jumpHeight = 1.0f;
    [SerializeField]
    private LayerMask _groundLayer;

    private CharacterController _controller;
    private PlayerInput _playerInput;
    
    private float velocityY = 0;
    private float _gravityValue = -9.81f;
    private bool _shouldJump;
    private bool _groundedPlayer;

    public bool GroundedPlayer => _groundedPlayer;

    private void Start()
    {
        _shouldJump = false;
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update() {
        if (GameManager.singleton.IsPause) return;
        if (_playerInput.JumpKeyPressed && _groundedPlayer && !_shouldJump) _shouldJump = true;
    }

    private void FixedUpdate()
    {
        if (GameManager.singleton.IsPause) return;
        _groundedPlayer = Physics.Raycast(transform.position+Vector3.up, Vector3.down, 1.05f, _groundLayer);
        
        if (_groundedPlayer && velocityY < 0f) velocityY = 0.0f;

        Vector3 move = new Vector3(_playerInput.HorizontalAxis * Time.deltaTime * _playerSpeed, 0, _playerInput.VerticalAxis * Time.deltaTime * _playerSpeed);

        if (_shouldJump) {
            velocityY += _jumpHeight * -1.0f * _gravityValue * Time.deltaTime;
            _shouldJump = false;
            GameManager.singleton.JumpToWin = GameManager.singleton.JumpToWin>1 ? GameManager.singleton.JumpToWin-1 : 0;
        }
        else velocityY += _gravityValue * 0.1f *Time.deltaTime;

        move.y = velocityY;

        move = transform.TransformDirection(move);

        _controller.Move(move);
    }
}
