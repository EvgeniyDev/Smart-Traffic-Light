using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider volume;

    public TMP_Dropdown qualitySettings;

    public Toggle fullscreen;
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private void Start()
    {
        ResolutionsInit();
        fullscreen.isOn = Screen.fullScreen;
        qualitySettings.value = QualitySettings.GetQualityLevel();
        mainMixer.GetFloat("volume", out float volumeValue);
        volume.value = volumeValue;
    }

    private void ResolutionsInit()
    {
        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions;

        var currentResolutionIndex = 0;
        var resolutionList = new List<string>(16);

        for (int i = 0; i < resolutions.Length; i++)
        {
            var option = $"{resolutions[i].width}x{resolutions[i].height} {resolutions[i].refreshRate} Hz";

            if (!resolutionList.Contains(option))
            {
                resolutionList.Add(option);
            }

            if (resolutions[i].width == Screen.width
                && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionList);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        var resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
