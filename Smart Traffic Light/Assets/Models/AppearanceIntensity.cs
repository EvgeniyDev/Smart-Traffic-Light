namespace Assets.Models
{
    public static class AppearanceIntensity
    {
        public static double CurrentPeopleAppearance { get => PeopleAppearanceIntensityArray[TimeOfDay.Hour]; }

        public static double CurrentCarsAppearance { get => CarsAppearanceIntensityArray[TimeOfDay.Hour]; }

        public static double[] PeopleAppearanceIntensityArray = new double[TimeOfDay.HoursInADay];

        public static double[] CarsAppearanceIntensityArray = new double[TimeOfDay.HoursInADay];
    }
}