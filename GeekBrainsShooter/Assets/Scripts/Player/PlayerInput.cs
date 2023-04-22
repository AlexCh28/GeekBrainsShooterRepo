using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;
    [SerializeField]
    private KeyCode runKey = KeyCode.LeftShift;

    public float MouseX => Input.GetAxis("Mouse X");
    public float MouseY => Input.GetAxis("Mouse Y"); 
    public float VerticalAxis => Input.GetAxis("Vertical");
    public float HorizontalAxis => Input.GetAxis("Horizontal"); 
    public bool JumpKeyPressed => Input.GetKeyDown(jumpKey);
    public bool RunKeyPressed => Input.GetKeyDown(runKey);
    public bool FireKeyPressed => Input.GetMouseButton(0);
    public bool FireKeyReleased => Input.GetMouseButtonUp(0);
    public bool ScrollUp => Input.mouseScrollDelta.y>0;
    public bool ScrollDown => Input.mouseScrollDelta.y<0;
}
