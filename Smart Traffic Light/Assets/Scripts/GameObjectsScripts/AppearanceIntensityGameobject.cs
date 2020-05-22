﻿using Assets.Scripts.Models;
using UnityEngine;

public class AppearanceIntensityGameobject : MonoBehaviour
{
    [HideInInspector]
    public double[] carsAppearanceIntensity;
    [HideInInspector]
    public double[] peopleAppearanceIntensity;

    void Start()
    {
        AppearanceIntensity.SetDefaultParameters();
        carsAppearanceIntensity = AppearanceIntensity.CarsAppearanceIntensityArray;
        peopleAppearanceIntensity = AppearanceIntensity.PeopleAppearanceIntensityArray;
    }

}
