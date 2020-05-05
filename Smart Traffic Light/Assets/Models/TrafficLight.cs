namespace Assets.Models
{
    public class TrafficLight
    {
        public const int yellowSignalDelay = 3;
        public const int minDelayTime = 16;
        public const int maxDelayTime = 99;
        public const double pedestrianDelayCoefficient = 0.4;

        public int Delay
        {
            get => CalculateDelay();  
        }

        public TrafficLightSignal TrafficLightSignal { get; set; }
        public TrafficLightState TrafficLightState { get; private set; }


        private int CalculateDelay()
        {
            switch (TrafficLightSignal)
            {
                case TrafficLightSignal.YellowLight:
                    return yellowSignalDelay;


                case TrafficLightSignal.RedLight:
                case TrafficLightSignal.GreenLight:


                    return 1;

                default:
                    throw new System.Exception("Undefined traffic light signal");

            }
        }
    }
}
