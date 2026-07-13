using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour
{
    public GameObject missionPanel;

    public GameObject hud;

    public GameObject mobileControls;

    public float missionTime = 3f;

    public void ShowMission()
    {
        StartCoroutine(MissionRoutine());
    }

    IEnumerator MissionRoutine()
    {
    Debug.Log("Mission Muncul");

    missionPanel.SetActive(true);

    yield return new WaitForSeconds(missionTime);

    Debug.Log("Mission Hilang");

    missionPanel.SetActive(false);

    hud.SetActive(true);

    mobileControls.SetActive(true);

    Debug.Log("Gameplay Dimulai");
    }
}