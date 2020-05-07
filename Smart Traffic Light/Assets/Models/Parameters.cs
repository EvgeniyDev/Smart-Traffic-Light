namespace Assets.Models
{
    public abstract class Parameters
    {
        public const double AverageCoefficient = 0.5;

        public abstract int AverageAmount { get; }

        public abstract int CurrentAmount { get; }
    }
}
