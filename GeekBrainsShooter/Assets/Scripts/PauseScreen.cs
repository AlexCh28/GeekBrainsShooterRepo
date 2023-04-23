using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _exitButton;

    private void Awake() {
        _restartButton.onClick.AddListener(() => SceneManager.LoadScene("Demo"));
        _exitButton.onClick.AddListener(() => {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
                Application.Quit();
        });
    }
}