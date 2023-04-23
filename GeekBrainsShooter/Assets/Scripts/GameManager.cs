using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private int _amountOfEnemies;

    [SerializeField] 
    private int _jumpToWin;

    [SerializeField]
    private GameObject _pauseScreen;
    [SerializeField]
    private TextMeshProUGUI _pauseLabel;

    private TasksToWin _tasks;

    private int _defeatToWin;

    public int AmountOfEnemies {get{return _amountOfEnemies;} set{_amountOfEnemies = value;}}
    public int DefeatToWin {get{return _defeatToWin;} set{_defeatToWin = value;}}
    public int JumpToWin {get{return _jumpToWin;} set{_jumpToWin = value;}}

    public bool IsPause {get; set;}

    public static GameManager singleton {get; private set;}

    private void Awake() {
        IsPause = false;
        Time.timeScale = 1;
        singleton = this;
        _tasks = FindObjectOfType<TasksToWin>();
        _defeatToWin = _amountOfEnemies;
    }

    private void Update() {
        _tasks.RedrawTask1(_defeatToWin);
        _tasks.RedrawTask2(_jumpToWin);

        if (_defeatToWin == 0 && _jumpToWin==0) {
            Cursor.visible = true;
            IsPause = true;
            Cursor.lockState = CursorLockMode.None;
            _pauseScreen.SetActive(true);
            _pauseLabel.text = "Win";
            _pauseLabel.color = Color.red;
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!IsPause && !(_defeatToWin == 0 && _jumpToWin==0)){
                Cursor.visible = true;
                IsPause = true;
                Cursor.lockState = CursorLockMode.None;
                _pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else if (IsPause && !(_defeatToWin == 0 && _jumpToWin==0)){
                Cursor.visible = false;
                IsPause = false;
                Cursor.lockState = CursorLockMode.Locked;
                _pauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
