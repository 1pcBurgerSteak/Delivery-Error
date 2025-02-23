using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class optionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;

    public TMP_Dropdown resolutionDropDown;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SFXVolumeKey = "SFXVolume";
    private const string ResolutionIndexKey = "ResolutionIndex"; 
    private const string FullscreenKey = "Fullscreen"; 

    // Reference sa sliders
    public Slider musicSlider; 
    public Slider sfxSlider; 

    // sa toggle button
    public Toggle fullscreenToggle; 

    void Start()
    {
        // Get available resolutions
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " @ " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height && resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);

        
        if (PlayerPrefs.HasKey(ResolutionIndexKey))
        {
            currentResolutionIndex = PlayerPrefs.GetInt(ResolutionIndexKey);
        }

        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        // Load and set the fullscreen state
        if (PlayerPrefs.HasKey(FullscreenKey))
        {
            bool isFullscreen = PlayerPrefs.GetInt(FullscreenKey) == 1; 
            Screen.fullScreen = isFullscreen; 
            fullscreenToggle.isOn = isFullscreen; 
        }

        LoadAudioSettings();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(ResolutionIndexKey, resolutionIndex); 
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt(FullscreenKey, isFullscreen ? 1 : 0); 
    }

    public void OnFullscreenToggleChanged(bool isOn)
    {
        SetFullscreen(isOn); 
    }

    private void LoadAudioSettings()
    {
        // Load and set the music volume
        if (PlayerPrefs.HasKey(MusicVolumeKey))
        {
            float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey);
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(savedMusicVolume) * 20); 
            musicSlider.value = savedMusicVolume; 
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(1) * 20); 
            musicSlider.value = 1; 
        }

        // Load and set the SFX volume
        if (PlayerPrefs.HasKey(SFXVolumeKey))
        {
            float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey);
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(savedSFXVolume) * 20); 
            sfxSlider.value = savedSFXVolume; 
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(1) * 20); 
            sfxSlider.value = 1;
        }
    }
}
