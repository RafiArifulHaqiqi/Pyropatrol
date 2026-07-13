using UnityEngine;
using UnityEngine.UI;

public class LevelStarDisplay : MonoBehaviour
{
    public int levelNumber;

    public Image[] stars;

    public Color starOff = Color.black;
    public Color starOn = Color.yellow;


    private void Start()
    {
        UpdateStars();
    }


    void UpdateStars()
    {
        if (ProgressManager.Instance == null)
        {
            Debug.LogError("ProgressManager belum ada!");
            return;
        }


        if (stars == null || stars.Length == 0)
        {
            Debug.LogError("Star belum diisi di Inspector!");
            return;
        }


        int savedStars = ProgressManager.Instance.GetStars(levelNumber);


        for (int i = 0; i < stars.Length; i++)
        {
            if (stars[i] == null)
            {
                Debug.LogError("Star ke-" + i + " kosong!");
                continue;
            }


            stars[i].color = (i < savedStars) ? starOn : starOff;
        }
    }
}