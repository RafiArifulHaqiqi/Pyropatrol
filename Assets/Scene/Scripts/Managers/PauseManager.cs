using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject pausePanel;

    [Header("Gameplay UI")]
    public GameObject hud;
    public GameObject mobileControls;

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        if (isPaused)
            return;

        isPaused = true;

        pausePanel.SetActive(true);

        if (hud != null)
            hud.SetActive(false);

        if (mobileControls != null)
            mobileControls.SetActive(false);

        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        if (!isPaused)
            return;

        isPaused = false;

        pausePanel.SetActive(false);

        if (hud != null)
            hud.SetActive(true);

        if (mobileControls != null)
            mobileControls.SetActive(true);

        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}