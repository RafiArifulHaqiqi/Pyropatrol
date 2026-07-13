using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI")]
    public SettingsManager settingsManager;

    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void OpenSetting()
    {
        if (settingsManager != null)
        {
            settingsManager.OpenSetting();
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}