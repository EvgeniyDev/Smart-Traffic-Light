using System;

namespace Assets.Models
{
    public class PeopleParameters : Parameters
    {
        public override int AverageAmount 
        {
            get => (int)(LevelLimits.MaxPeopleAmount * AverageCoefficient); 
        }

        public override int CurrentAmount 
        {
            get => (int)Math.Round(AverageAmount * AppearanceIntensity.CurrentPeopleAppearance, MidpointRounding.AwayFromZero);
        }       
    }
}
