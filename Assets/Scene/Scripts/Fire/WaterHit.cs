using UnityEngine;

public class WaterHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}