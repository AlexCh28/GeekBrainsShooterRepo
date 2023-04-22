using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _menuButton;
    [SerializeField]
    private Button _exitButton;

    private void Awake() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        _restartButton.onClick.AddListener(() => SceneManager.LoadScene("Demo"));

        _menuButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));

        _exitButton.onClick.AddListener(() => {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
                Application.Quit();
        });
    }
}
