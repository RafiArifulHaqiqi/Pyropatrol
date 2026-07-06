using UnityEngine;

public class FireHit : MonoBehaviour
{
    public GameObject fireParticle;

    private bool isOut = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water") && !isOut)
        {
            isOut = true;

            Debug.Log("Api Padam!");

            if (fireParticle != null)
            {
                fireParticle.SetActive(false);
            }

            if (VictoryManager.Instance != null)
            {
                VictoryManager.Instance.LevelComplete();
            }
            else
            {
                Debug.LogError("VictoryManager tidak ditemukan!");
            }
        }
    }
}