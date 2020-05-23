using Assets.Scripts.Models;
using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public GameObject notificationPanel;
    public GameObject panelBehind;
    private TMP_Text notificationText;

    public Dropdown hours;
    public Dropdown minutes;
    public Dropdown seconds;

    private void Start()
    {
        for (int i = 0; i < 24; i++)
        {
            var hoursTimespan = TimeSpan.FromHours(i);
            hours.options.Add(new Dropdown.OptionData() { text = hoursTimespan.ToString("hh") });
        }

        for (int i = 0; i < 60; i++)
        {
            var minutesTimespan = TimeSpan.FromMinutes(i);
            minutes.options.Add(new Dropdown.OptionData() { text = minutesTimespan.ToString("mm") });

            var secondsTimespan = TimeSpan.FromSeconds(i);
            seconds.options.Add(new Dropdown.OptionData() { text = secondsTimespan.ToString("ss") });
        }

        hours.value = 0;
        minutes.value = 0;
        seconds.value = 0;

        notificationText = notificationPanel.transform.GetChild(0).GetComponent<TMP_Text>();
    }

    void Update()
    {
    }

    public void SetCurrnetTime()
    {
        hours.value = TimeOfDay.Hour;
        minutes.value = TimeOfDay.Minute;
        seconds.value = TimeOfDay.Second;
    }

    public void ApplySettedTime()
    {
        TimeOfDay.Hour = hours.value;
        TimeOfDay.Minute = minutes.value;
        TimeOfDay.Second = seconds.value;

        SetCurrnetTime();
    }

    public void SetDefaultAppearance()
    {
        AppearanceIntensity.SetDefaultParameters();

        notificationPanel.SetActive(true);
        notificationText.text = "Default parameters were set successfully!";
    }

    public void Apply()
    {
        string onFDOpenDirectory = Environment.CurrentDirectory;
        string path = EditorUtility.OpenFilePanel("Load appearance parameters", onFDOpenDirectory, "json");

        if (!string.IsNullOrEmpty(path))
        {
            var jsonString = File.ReadAllText(path);
            var appearanceIntensity = JsonUtility.FromJson<AppearanceIntensityJSON>(jsonString);

            if (appearanceIntensity.PeopleAppearanceIntensityArray == null
                || appearanceIntensity.CarsAppearanceIntensityArray == null)
            {
                notificationPanel.SetActive(true);
                panelBehind.SetActive(true);

                notificationText.text = "File was corrupted! Default parameters will be set";
            }

            AppearanceIntensity.CarsAppearanceIntensityArray = 
                appearanceIntensity.CarsAppearanceIntensityArray ?? DefaultAppearanceIntensityParameters.DefaultCarsAppearanceIntensity;
            AppearanceIntensity.PeopleAppearanceIntensityArray = 
                appearanceIntensity.PeopleAppearanceIntensityArray ?? DefaultAppearanceIntensityParameters.DefaultPeopleAppearanceIntensity;
            

        }
    }
}
