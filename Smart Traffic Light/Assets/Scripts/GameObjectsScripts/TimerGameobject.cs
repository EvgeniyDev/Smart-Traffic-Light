using Assets.Scripts.Models;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerGameobject : MonoBehaviour
{
    public int hour;
    public int minute;
    public int second;

    private TMP_Text timeText;

    bool isSecondPassed;

    void Start()
    {
        isSecondPassed = true;

        TimeOfDay.Hour = hour;
        TimeOfDay.Minute = minute;
        TimeOfDay.Second = second;

        timeText = transform.GetChild(transform.childCount - 1).gameObject.GetComponentInChildren<TMP_Text>();
        SetRealTime();
    }

    private void Update()
    {
        CustomTimer();
        timeText.text = new DateTime(1, 1, 1, TimeOfDay.Hour, TimeOfDay.Minute, TimeOfDay.Second).ToString("HH:mm:ss");
    }

    public void SetRealTime() => TimeOfDay.SetRealCurrentTime();

    private void CustomTimer()
    {
        if (isSecondPassed)
        {
            StartCoroutine(SecondStep());

            if (TimeOfDay.Second == 60)
            {
                TimeOfDay.Second = 0;
                TimeOfDay.Minute++;
            }

            if (TimeOfDay.Minute == 60)
            {
                TimeOfDay.Minute = 0;
                TimeOfDay.Hour++;
            }

            if (TimeOfDay.Hour == 24)
            {
                TimeOfDay.Hour = 0;
            }
        }
    }

    private IEnumerator SecondStep()
    {
        isSecondPassed = false;

        yield return new WaitForSeconds(1);

        TimeOfDay.Second++;
        isSecondPassed = true;
    }    
}
