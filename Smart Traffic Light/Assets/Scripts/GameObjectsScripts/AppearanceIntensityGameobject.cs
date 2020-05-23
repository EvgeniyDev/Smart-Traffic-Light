using Assets.Scripts.Models;
using UnityEngine;

public class AppearanceIntensityGameobject : MonoBehaviour
{
    public double[] carsAppearanceIntensity;
    public double[] peopleAppearanceIntensity;

    void Start()
    {
        AppearanceIntensity.SetDefaultParameters();
        carsAppearanceIntensity = AppearanceIntensity.CarsAppearanceIntensityArray;
        peopleAppearanceIntensity = AppearanceIntensity.PeopleAppearanceIntensityArray;
    }

}
