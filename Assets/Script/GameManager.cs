using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int starsCollected = 0;
    public int totalStars = 3;

    public GameObject victoryPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
    }

    public void CollectStar()
    {
        starsCollected++;

        Debug.Log("Bintang: " + starsCollected + "/" + totalStars);

        if (starsCollected >= totalStars)
        {
            WinGame();
        }
    }

    public void LoseStar()
    {
        if (starsCollected > 0)
        {
            starsCollected--;

            Debug.Log("Bintang Berkurang!");
        }
    }

    void WinGame()
    {
        Debug.Log("YOU WIN!");

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}