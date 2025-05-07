using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSoundEffectsVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
       myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    
    public void SetSoundEffectsVolume()
    {
        float volume = SFXSlider.value;
       myMixer.SetFloat("SoundEffects", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SoundEffectsVolume", volume);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SoundEffectsVolume");

        SetMusicVolume();
        SetSoundEffectsVolume();
    }
}

