using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    [Header("UI")]
    public TMP_Text timerText;

    private float timer = 0f;
    private bool isRunning = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!isRunning)
            return;

        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        if (timerText != null)
        {
            timerText.text = $"Time: {minutes:00}:{seconds:00}";
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        timer = 0f;
        isRunning = true;
    }

    public float GetTime()
    {
        return timer;
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}