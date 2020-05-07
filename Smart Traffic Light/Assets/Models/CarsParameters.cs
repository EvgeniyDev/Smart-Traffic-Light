using System;

namespace Assets.Models
{
    public class CarsParameters : Parameters
    {
        public override int AverageAmount
        {
            get => (int)(LevelLimits.MaxCarsAmount * AverageCoefficient);
        }

        public override int CurrentAmount
        {
            get => (int)Math.Round(AverageAmount * AppearanceIntensity.CurrentCarsAppearance, MidpointRounding.AwayFromZero);
        }
    }
}
