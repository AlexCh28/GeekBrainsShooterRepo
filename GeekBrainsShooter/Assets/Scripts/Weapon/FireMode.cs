using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMode : MonoBehaviour
{
    [SerializeField]
    private bool _isAutomatic;
    [SerializeField]
    private float _interval;
    private float _timer;

    private bool _wasReleased;

    private PlayerInput _playerInput;

    public float Timer { get{return _timer;} set{_timer=value;} }
    public bool CanShoot => _timer>=_interval && (_isAutomatic || _wasReleased);
    public bool IsAutomatic => _isAutomatic;
    public bool WasReleased { get{return _wasReleased;} set{_wasReleased=value;} }

    private void Start() {
        _playerInput = GetComponentInParent<PlayerInput>(); 
        _wasReleased = true;
        _timer = _interval;
    }

    private void Update() {
        _timer += Time.deltaTime;
        if (!_wasReleased && _playerInput.FireKeyReleased) _wasReleased = true;
    }
}
