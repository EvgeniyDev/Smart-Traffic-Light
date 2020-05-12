using System;

namespace Assets.Scripts.Models
{
    public class PeopleParameters : Parameters
    {
        public static int AverageAmount 
        {
            get => (int)(LevelLimits.MaxPeopleAmount * AverageCoefficient); 
        }

        public static int CurrentAmount 
        {
            get => (int)Math.Round(AverageAmount * AppearanceIntensity.CurrentPeopleAppearance, MidpointRounding.AwayFromZero);
        }       
    }
}
