using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Dropdown hours;
    public Dropdown minutes;
    public Dropdown seconds;

    private void Start()
    {
        for (int i = 0; i < 24; i++)
        {
            hours.options.Add(new Dropdown.OptionData() { text = i.ToString() });
        }

        for (int i = 0; i < 60; i++)
        {
            minutes.options.Add(new Dropdown.OptionData() { text = i.ToString() });
            seconds.options.Add(new Dropdown.OptionData() { text = i.ToString() });
        }

        SetCurrnetTime();
    }

    void Update()
    {
    }

    private void SetCurrnetTime()
    {
        hours.value = TimeOfDay.Hour;
        minutes.value = TimeOfDay.Minute;
        seconds.value = TimeOfDay.Second;
    }

    public void SetDefaultAppearance()
    {
        
    }
}
