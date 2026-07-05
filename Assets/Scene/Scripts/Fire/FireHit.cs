using UnityEngine;

public class FireHit : MonoBehaviour
{
    private FireController fire;

    void Start()
    {
        fire = GetComponentInParent<FireController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            fire.Extinguish();
        }
    }
}