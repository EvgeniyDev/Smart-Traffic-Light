using Assets.Scripts.Models;
using UnityEngine;

public class AppearanceIntensityGameobject : MonoBehaviour
{
    [SerializeField]
    public static double[] carsAppearanceIntensity;
    [SerializeField]
    public static double[] peopleAppearanceIntensity;

    private void Start()
    {
        AppearanceIntensity.SetDefaultParameters();

        SetAppearanceParameters();
    }

    public static void SetAppearanceParameters()
    {
        carsAppearanceIntensity = AppearanceIntensity.CarsAppearanceIntensityArray;
        peopleAppearanceIntensity = AppearanceIntensity.PeopleAppearanceIntensityArray;
    }
}
