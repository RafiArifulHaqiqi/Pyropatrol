using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ===========================
    // Save Stars
    // ===========================

    public void SaveStars(int level, int stars)
    {
        string key = "Level" + level + "Stars";

        int currentStars = PlayerPrefs.GetInt(key, 0);

        if (stars > currentStars)
        {
            PlayerPrefs.SetInt(key, stars);
        }

        PlayerPrefs.Save();
    }

    // ===========================
    // Get Stars
    // ===========================

    public int GetStars(int level)
    {
        return PlayerPrefs.GetInt("Level" + level + "Stars", 0);
    }

    // ===========================
    // Unlock Level
    // ===========================

    public void UnlockLevel(int level)
    {
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (level > unlocked)
        {
            PlayerPrefs.SetInt("UnlockedLevel", level);
            PlayerPrefs.Save();
        }
    }

    // ===========================
    // Check Unlock
    // ===========================

    public bool IsLevelUnlocked(int level)
    {
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);
        return level <= unlocked;
    }

    // ===========================
    // Reset Progress
    // ===========================

    public void ResetProgress()
    {
        // Reset level yang terbuka
        PlayerPrefs.DeleteKey("UnlockedLevel");

        // Reset semua bintang (Level 1-6)
        for (int i = 1; i <= 6; i++)
        {
            PlayerPrefs.DeleteKey("Level" + i + "Stars");
        }

        // Reset tutorial agar muncul lagi
        PlayerPrefs.DeleteKey("TutorialShown");

        PlayerPrefs.Save();

        Debug.Log("Progress berhasil direset!");
    }
}