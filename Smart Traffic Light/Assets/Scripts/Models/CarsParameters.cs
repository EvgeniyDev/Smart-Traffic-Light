using System;

namespace Assets.Scripts.Models
{
    public class CarsParameters : Parameters
    {
        public static int AverageAmount
        {
            get => (int)(LevelLimits.MaxCarsAmount * AverageCoefficient);
        }

        public static int CurrentAmount
        {
            get => (int)Math.Round(AverageAmount * AppearanceIntensity.CurrentCarsAppearance, MidpointRounding.AwayFromZero);
        }
    }
}
