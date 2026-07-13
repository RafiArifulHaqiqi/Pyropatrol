using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource engineSource;
    public AudioSource waterSource;
    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip mainMenuMusic;
    public AudioClip gameplayMusic;

    [Header("Sound Effects")]
    public AudioClip engineLoop;
    public AudioClip waterSpray;
    public AudioClip fireOut;
    public AudioClip victory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //==================== MUSIC ====================//

    public void PlayMainMenu()
    {
        if (musicSource.clip == mainMenuMusic && musicSource.isPlaying)
            return;

        musicSource.clip = mainMenuMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayGameplay()
    {
        if (musicSource.clip == gameplayMusic && musicSource.isPlaying)
            return;

        musicSource.clip = gameplayMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    //==================== ENGINE ====================//

    public void PlayEngine()
    {
        if (engineSource.isPlaying)
            return;

        engineSource.clip = engineLoop;
        engineSource.loop = true;
        engineSource.Play();
    }

    public void StopEngine()
    {
        if (engineSource.isPlaying)
            engineSource.Stop();
    }

    //==================== WATER ====================//

    public void PlayWater()
    {
        if (waterSource.isPlaying)
            return;

        waterSource.clip = waterSpray;
        waterSource.loop = true;
        waterSource.Play();
    }

    public void StopWater()
    {
        if (waterSource.isPlaying)
            waterSource.Stop();
    }

    //==================== SFX ====================//

    public void PlayFireOut()
    {
        if (fireOut != null)
            sfxSource.PlayOneShot(fireOut);
    }

    public void PlayVictory()
    {
        sfxSource.PlayOneShot(victory, 3.0f);
    }
}