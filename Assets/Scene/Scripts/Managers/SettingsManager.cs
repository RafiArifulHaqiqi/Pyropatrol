using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject settingPanel;

    [Header("Music")]
    public Slider musicSlider;

    [Header("SFX")]
    public Slider sfxSlider;


    private void Start()
    {
        settingPanel.SetActive(false);


        // =========================
        // MUSIC
        // =========================

        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.2f);

        musicSlider.value = musicVolume;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.musicSource.volume = musicVolume;
        }


        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);



        // =========================
        // SFX
        // =========================

        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        sfxSlider.value = sfxVolume;

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.engineSource.volume = sfxVolume;
            AudioManager.Instance.waterSource.volume = sfxVolume;
            AudioManager.Instance.sfxSource.volume = sfxVolume;
        }


        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }



    public void OpenSetting()
    {
        settingPanel.SetActive(true);
    }



    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }



    // =========================
    // MUSIC
    // =========================

    void ChangeMusicVolume(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.musicSource.volume = value;
        }

        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }



    // =========================
    // SFX
    // =========================

    void ChangeSFXVolume(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.engineSource.volume = value;
            AudioManager.Instance.waterSource.volume = value;
            AudioManager.Instance.sfxSource.volume = value;
        }

        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
}