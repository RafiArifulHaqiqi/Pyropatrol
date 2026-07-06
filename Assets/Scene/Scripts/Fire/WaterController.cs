using UnityEngine;

public class WaterController : MonoBehaviour
{
    [Header("Water Effect")]
    public ParticleSystem waterSpray;

    [Header("Water Hitbox")]
    public GameObject waterTrigger;

    void Start()
    {
        // Pastikan air dan trigger mati saat game dimulai
        if (waterSpray != null)
            waterSpray.Stop();

        if (waterTrigger != null)
            waterTrigger.SetActive(false);
    }

    // Dipanggil saat tombol TEMBAK ditekan
    public void StartSpray()
    {
        if (waterSpray != null && !waterSpray.isPlaying)
            waterSpray.Play();

        if (waterTrigger != null)
            waterTrigger.SetActive(true);
    }

    // Dipanggil saat tombol TEMBAK dilepas
    public void StopSpray()
    {
        if (waterSpray != null && waterSpray.isPlaying)
            waterSpray.Stop();

        if (waterTrigger != null)
            waterTrigger.SetActive(false);
    }
}