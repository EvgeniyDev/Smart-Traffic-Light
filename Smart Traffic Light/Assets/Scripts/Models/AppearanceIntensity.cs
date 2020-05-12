namespace Assets.Scripts.Models
{
    public static class AppearanceIntensity
    {
        public static double CurrentPeopleAppearance { get => PeopleAppearanceIntensityArray[TimeOfDay.Hour]; }

        public static double CurrentCarsAppearance { get => CarsAppearanceIntensityArray[TimeOfDay.Hour]; }

        public static double[] PeopleAppearanceIntensityArray = new double[TimeOfDay.HoursInADay];

        public static double[] CarsAppearanceIntensityArray = new double[TimeOfDay.HoursInADay];

        public static bool IsParametersValid()
        {
            foreach (var parameter in PeopleAppearanceIntensityArray)
            {
                if (parameter < 0.1 || parameter > 1.9)
                {
                    return false;
                }
            }

            foreach (var parameter in CarsAppearanceIntensityArray)
            {
                if (parameter < 0.1 || parameter > 1.9)
                {
                    return false;
                }
            }

            return true;
        }

        public static void SetDefaultParameters()
        {
            CarsAppearanceIntensityArray = DefaultAppearanceIntensityParameters.DefaultCarsAppearanceIntensity;
            PeopleAppearanceIntensityArray = DefaultAppearanceIntensityParameters.DefaultPeopleAppearanceIntensity;
        }
    }
}