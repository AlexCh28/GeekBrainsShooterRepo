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
    private bool _groundedPlayer;
    private float velocityY = 0;
    private float _gravityValue = -9.81f;

    public bool GroundedPlayer => _groundedPlayer;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        _groundedPlayer = Physics.Raycast(transform.position+Vector3.up, Vector3.down, 1.05f, _groundLayer);
        
        if (_groundedPlayer && velocityY < 0f) velocityY = 0.0f;

        Vector3 move = new Vector3(_playerInput.HorizontalAxis * Time.deltaTime * _playerSpeed, 0, _playerInput.VerticalAxis * Time.deltaTime * _playerSpeed);

        if (_playerInput.JumpKeyPressed && _groundedPlayer) velocityY += _jumpHeight * -1.0f * _gravityValue * Time.deltaTime;
        else velocityY += _gravityValue * 0.1f *Time.deltaTime;

        move.y = velocityY;

        move = transform.TransformDirection(move);

        _controller.Move(move);
    }
}
