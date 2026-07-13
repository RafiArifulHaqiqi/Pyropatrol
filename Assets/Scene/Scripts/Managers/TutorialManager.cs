using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Panel")]
    public GameObject tutorialPanel;
    public GameObject missionPanel;

    [Header("Gameplay")]
    public GameObject hud;
    public GameObject mobileControls;

    private MissionManager missionManager;

    private void Start()
    {
        missionManager = GetComponent<MissionManager>();

        // Tutorial sudah pernah ditampilkan
        if (PlayerPrefs.GetInt("TutorialShown", 0) == 1)
        {
            tutorialPanel.SetActive(false);
            missionPanel.SetActive(false);

            hud.SetActive(false);
            mobileControls.SetActive(false);

            Time.timeScale = 1f;

            if (missionManager != null)
            {
                missionManager.ShowMission();
            }

            return;
        }

        // Pertama kali bermain
        tutorialPanel.SetActive(true);
        missionPanel.SetActive(false);

        hud.SetActive(false);
        mobileControls.SetActive(false);

        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        Debug.Log("ContinueGame dipanggil");

        PlayerPrefs.SetInt("TutorialShown", 1);
        PlayerPrefs.Save();

        tutorialPanel.SetActive(false);

        Time.timeScale = 1f;

        if (missionManager != null)
        {
            missionManager.ShowMission();
        }
    }
}