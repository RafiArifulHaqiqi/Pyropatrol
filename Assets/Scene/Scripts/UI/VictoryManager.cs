using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryManager : MonoBehaviour
{
    public static VictoryManager Instance;

    [Header("UI")]
    public GameObject victoryPanel;
    public GameObject hudPanel;

    [Header("Result")]
    public TMP_Text timeResult;

    [Header("Stars")]
    public Image star1;
    public Image star2;
    public Image star3;

    [Header("Level")]
    public int currentLevel = 1;

    [Header("Star Time")]
    public float threeStarTime = 30f;
    public float twoStarTime = 45f;

    private bool levelCompleted = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (victoryPanel != null)
            victoryPanel.SetActive(false);

        if (hudPanel != null)
            hudPanel.SetActive(true);
    }

    public void LevelComplete()
    {
        if (levelCompleted)
            return;

        levelCompleted = true;

        Debug.Log("LEVEL COMPLETE!");

        float finishTime = 0f;

        if (TimerManager.Instance != null)
        {
            TimerManager.Instance.StopTimer();

            finishTime = TimerManager.Instance.GetTime();

            if (timeResult != null)
            {
                timeResult.text = TimerManager.Instance.GetFormattedTime();
            }
        }

        // Tampilkan bintang
        ShowStars(finishTime);

        // 🔊 Hentikan musik lalu putar suara Victory
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayVictory();
        }

        // Hitung jumlah bintang
        int stars = 1;

        if (finishTime <= threeStarTime)
            stars = 3;
        else if (finishTime <= twoStarTime)
            stars = 2;

        // Simpan progress
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.SaveStars(currentLevel, stars);

            // Buka level berikutnya
            ProgressManager.Instance.UnlockLevel(currentLevel + 1);
        }

        if (hudPanel != null)
            hudPanel.SetActive(false);

        if (victoryPanel != null)
            victoryPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    void ShowStars(float finishTime)
    {
        if (star1 != null)
            star1.gameObject.SetActive(false);

        if (star2 != null)
            star2.gameObject.SetActive(false);

        if (star3 != null)
            star3.gameObject.SetActive(false);

        // ⭐⭐⭐
        if (finishTime <= threeStarTime)
        {
            if (star1 != null) star1.gameObject.SetActive(true);
            if (star2 != null) star2.gameObject.SetActive(true);
            if (star3 != null) star3.gameObject.SetActive(true);
        }
        // ⭐⭐
        else if (finishTime <= twoStarTime)
        {
            if (star1 != null) star1.gameObject.SetActive(true);
            if (star2 != null) star2.gameObject.SetActive(true);
        }
        // ⭐
        else
        {
            if (star1 != null) star1.gameObject.SetActive(true);
        }
    }
}