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

            fireParticle.SetActive(false);

            Debug.Log("Api Padam!");

            FireManager.Instance.FireExtinguished();
        }
    }
}