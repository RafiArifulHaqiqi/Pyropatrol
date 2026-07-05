using UnityEngine;

public class FireController : MonoBehaviour
{
    [Header("Fire Object")]
    public ParticleSystem fireParticle;

    private bool isExtinguished = false;

    public void Extinguish()
    {
        if (isExtinguished)
            return;

        isExtinguished = true;

        if (fireParticle != null)
            fireParticle.Stop();

        Debug.Log("Api Padam!");
    }

    public bool IsExtinguished()
    {
        return isExtinguished;
    }
}