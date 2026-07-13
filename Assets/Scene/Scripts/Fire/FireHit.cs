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

            if (fireParticle != null)
                fireParticle.SetActive(false);

            // 🔊 Suara api padam
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayFireOut();
            }

            Debug.Log("Api Padam!");

            FireManager.Instance.FireExtinguished();
        }
    }
}