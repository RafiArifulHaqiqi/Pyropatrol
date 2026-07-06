using UnityEngine;
using TMPro;

public class FireManager : MonoBehaviour
{
    public static FireManager Instance;

    [Header("Fire Settings")]
    public int totalFire = 1;

    private int extinguishedFire = 0;

    [Header("UI")]
    public TMP_Text fireCounterText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void FireExtinguished()
    {
        extinguishedFire++;

        UpdateUI();

        Debug.Log("Api Padam : " + extinguishedFire + "/" + totalFire);

        if (extinguishedFire >= totalFire)
        {
            VictoryManager.Instance.LevelComplete();
        }
    }

    void UpdateUI()
    {
        if (fireCounterText != null)
        {
            fireCounterText.text = "🔥 " + extinguishedFire + " / " + totalFire;
        }
    }
}