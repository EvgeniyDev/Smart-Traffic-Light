using Assets.Scripts.Models;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerGameobject : MonoBehaviour
{
    public int hour;
    public int minute;
    public int second;

    private Text timeText;

    void Start()
    {
        TimeOfDay.Hour = hour;
        TimeOfDay.Minute = minute;
        TimeOfDay.Second = second;

        timeText = transform.GetChild(transform.childCount - 1).gameObject.GetComponentInChildren<Text>();
    }

    void Update()
    {
        TimeOfDay.SetRealCurrentTime();
        timeText.text = new DateTime(1, 1, 1, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second).ToString("T");
    }
}
