namespace Assets.Models
{
    public class CarsParameters : Parameters
    {
        private int currentAmount;

        public override int CurrentAmount
        {
            get => currentAmount;
            set
            {
                if (value >= 0 && value <= maxAmount)
                {
                    currentAmount = value;
                }
            }
        }

        private int maxAmount;

        public override int MaxAmount
        {
            get => maxAmount;
            set
            {
                if (value >= 0 && value <= LevelLimits.MaxCarsAmount)
                {
                    maxAmount = value;
                }
            }
        }
    }
}
