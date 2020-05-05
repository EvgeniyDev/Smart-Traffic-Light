namespace Assets.Models
{
    public abstract class Parameters
    {
        public double AverageAmount { get; protected set; }

        public abstract int CurrentAmount { get; set; }

        public abstract int MaxAmount { get; set; }
    }
}
