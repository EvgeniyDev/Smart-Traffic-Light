using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;

    public Slider volume;
    public Toggle fullscreen;
    public TMP_Dropdown qualitySettingsDropdown;

    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private void Start()
    {
        ResolutionsInit();

        fullscreen.isOn = Screen.fullScreen;

        qualitySettingsDropdown.value = QualitySettings.GetQualityLevel();

        mainMixer.GetFloat("volume", out float volume);
        this.volume.value = volume;
    }

    private void ResolutionsInit()
    {
        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions;

        var currentResolutionIndex = 0;
        var resolutionList = new List<string>(16);

        for (int i = 0; i < resolutions.Length; i++)
        {
            var option = $"{resolutions[i].width}x{resolutions[i].height}";

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
