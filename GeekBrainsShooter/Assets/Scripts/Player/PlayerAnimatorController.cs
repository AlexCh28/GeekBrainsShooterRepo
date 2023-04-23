using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;

    private void Start() {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        if (GameManager.singleton.IsPause) return;
        RunAnimationController();
        JumpAnimationController();
    }

    private void RunAnimationController(){
        if (_playerInput.VerticalAxis != 0 || _playerInput.HorizontalAxis!=0) 
            _animator.SetBool("IsRun", true);
        else
            _animator.SetBool("IsRun", false);
    }

    private void JumpAnimationController(){
        if (!_playerMovement.GroundedPlayer)
            _animator.SetBool("InAir", true);
        else
            _animator.SetBool("InAir", false);
    }
}
