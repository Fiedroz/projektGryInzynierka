using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider generalSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider effectsSlider;
    [SerializeField] Slider environmentSlider;

    const string MIXER_GENERAL = "MasterVolume";
    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_EFFECTS = "EffectsVolume";
    const string MIXER_ENVIRONMENT = "EnvironmentVolume";
    void Start()
    {
        generalSlider.onValueChanged.AddListener(SetGeneralVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
        environmentSlider.onValueChanged.AddListener(SetEnvironmentVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetGeneralVolume(float value)
    {
        audioMixer.SetFloat(MIXER_GENERAL, Mathf.Log10(value) * 20);
    }
    void SetMusicVolume(float value)
    {
        audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }
    void SetEffectsVolume(float value)
    {
        audioMixer.SetFloat(MIXER_EFFECTS, Mathf.Log10(value) * 20);
    }
    void SetEnvironmentVolume(float value)
    {
        audioMixer.SetFloat(MIXER_ENVIRONMENT, Mathf.Log10(value) * 20);
    }
}
