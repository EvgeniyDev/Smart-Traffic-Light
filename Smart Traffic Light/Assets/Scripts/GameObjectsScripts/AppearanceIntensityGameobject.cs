using Assets.Scripts.Models;
using UnityEngine;

public class AppearanceIntensityGameobject : MonoBehaviour
{
    [SerializeField]
    private double[] carsAppearanceIntensity;
    [SerializeField]
    private double[] peopleAppearanceIntensity;

    void Start()
    {
        AppearanceIntensity.SetDefaultParameters();
        carsAppearanceIntensity = AppearanceIntensity.CarsAppearanceIntensityArray;
        peopleAppearanceIntensity = AppearanceIntensity.PeopleAppearanceIntensityArray;
    }

}
