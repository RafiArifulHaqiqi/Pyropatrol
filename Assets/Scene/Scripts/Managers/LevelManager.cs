using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayGameplay();
        }
    }
}