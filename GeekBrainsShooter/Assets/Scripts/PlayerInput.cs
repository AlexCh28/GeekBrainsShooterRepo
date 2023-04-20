using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    private KeyCode runKey = KeyCode.LeftShift;

    private float _verticalAxis;
    private float _horizontalAxis;
    private bool _jumpKeyPressed;
    private bool _runKeyPressed;

    public float VerticalAxis => _verticalAxis;
    public float HorizontalAxis => _horizontalAxis; 
    public bool JumpKeyPressed => _jumpKeyPressed;
    public bool RunKeyPressed => _runKeyPressed;

    private void Update() {
        _verticalAxis = Input.GetAxis("Vertical");
        _horizontalAxis = Input.GetAxis("Horizontal");

        _jumpKeyPressed = Input.GetKeyDown(jumpKey);
        _runKeyPressed = Input.GetKeyDown(runKey);
    }
}
