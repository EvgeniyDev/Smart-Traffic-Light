namespace Assets.Scripts.Models
{
    public static class DefaultAppearanceIntensityParameters
    {
        public static double[] DefaultPeopleAppearanceIntensity { get; } =
            { 0.4, 1d, 1d, 1d, 1d, 1d, 0.6, 0.8, 1.3, 1.3, 1.5, 1.2, 1.6, 1.6, 1.25, 1.15, 1.2, 1, 0.9, 1.1, 1.3, 0.85, 0.6, 0.5 };

        public static double[] DefaultCarsAppearanceIntensity { get; } =
            { 0.45, 1d, 1d, 1d, 1d, 1d, 0.5, 0.8, 1.6, 1.65, 1.7, 1.3, 1.2, 1.1, 1.1, 1.15, 1.2, 1.3, 1.75, 1.3, 1.2, 0.95, 0.6, 0.55 };
    }
}
