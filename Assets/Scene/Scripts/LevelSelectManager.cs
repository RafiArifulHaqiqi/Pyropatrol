using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [Header("Level Buttons")]
    public Button[] levelButtons;

    [Header("Lock Images")]
    public GameObject[] lockImages;


    private void Start()
    {
        UpdateLevels();
    }


    void UpdateLevels()
    {
        // Level 1 selalu terbuka
        levelButtons[0].interactable = true;


        // Level 2 - 6
        for(int i = 1; i < levelButtons.Length; i++)
        {
            int levelNumber = i + 1;


            bool unlocked = ProgressManager.Instance.IsLevelUnlocked(levelNumber);


            levelButtons[i].interactable = unlocked;


            if(lockImages[i-1] != null)
            {
                lockImages[i-1].SetActive(!unlocked);
            }
        }
    }



    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }



    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}