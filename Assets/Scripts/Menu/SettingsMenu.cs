using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private Resolution[] resolutions;


    public Dropdown resolutionDropdown;
    public Dropdown antiAliasingDropdown;
    public Dropdown qualityDropdown;
    public Dropdown texturesDropdown;
    public Dropdown shadowDropdown;
    public Dropdown shadowResolutionDropdown;

    private int currentQualitySettingsIndex = 0;
    private int currentResolutionIndex = 0;
    private int currentAntiAliasingIndex = 0;
    private int currentTexturesIndex = 0;
    private int currentShadowIndex = 0;
    private int currentShadowResolutionIndex = 0;
    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        currentQualitySettingsIndex = QualitySettings.GetQualityLevel();
        qualityDropdown.value = currentQualitySettingsIndex;
        qualityDropdown.RefreshShownValue();

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        currentAntiAliasingIndex = QualitySettings.antiAliasing / 2;
        antiAliasingDropdown.value = currentAntiAliasingIndex;
        antiAliasingDropdown.RefreshShownValue();

        currentTexturesIndex = QualitySettings.masterTextureLimit;
        texturesDropdown.value = currentTexturesIndex;
        texturesDropdown.RefreshShownValue();

        currentShadowIndex = (int)QualitySettings.shadows;
        shadowDropdown.value = currentShadowIndex;
        shadowDropdown.RefreshShownValue();

        currentShadowResolutionIndex = (int)QualitySettings.shadowResolution;
        shadowResolutionDropdown.value = currentShadowResolutionIndex;
        shadowResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetAntiAliasing(int antiAliasingIndex)
    {
        if (antiAliasingIndex == 0)
        {
            QualitySettings.antiAliasing = 0;
        }
        if (antiAliasingIndex == 1)
        {
            QualitySettings.antiAliasing = 2;
        }
        if (antiAliasingIndex == 2)
        {
            QualitySettings.antiAliasing = 4;
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        RefreshValues();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetTextures(int texturesIndex)
    {
        QualitySettings.masterTextureLimit = texturesIndex;
    }

    public void SetShadows(int shadowIndex)
    {
        QualitySettings.shadows = (ShadowQuality)shadowIndex;
    }

    public void SetShadowResolution(int shadowResolutionIndex)
    {
        QualitySettings.shadowResolution = (ShadowResolution)shadowResolutionIndex;
    }

    void RefreshValues()
    {
        currentAntiAliasingIndex = QualitySettings.antiAliasing / 2;
        antiAliasingDropdown.value = currentAntiAliasingIndex;
        antiAliasingDropdown.RefreshShownValue();

        currentTexturesIndex = QualitySettings.masterTextureLimit;
        texturesDropdown.value = currentTexturesIndex;
        texturesDropdown.RefreshShownValue();

        currentShadowIndex = (int)QualitySettings.shadows;
        shadowDropdown.value = currentShadowIndex;
        shadowDropdown.RefreshShownValue();

        currentShadowResolutionIndex = (int)QualitySettings.shadowResolution;
        shadowResolutionDropdown.value = currentShadowResolutionIndex;
        shadowResolutionDropdown.RefreshShownValue();
    }
}
