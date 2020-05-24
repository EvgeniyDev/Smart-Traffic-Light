using System;

namespace Assets.Scripts.Models
{
    public class TrafficLight
    {
        public const int yellowSignalDelay = 3;
        public const int minPeopleDelayTime = 11;
        public const int minCarsDelayTime = 22;
        public const int maxDelayTime = 99;
        public const double carsCoefficient = 1.5;

        private readonly WaitingPeopleParameters waitingPeopleParameters;
        private readonly WaitingCarsParameters waitingCarsParameters;

        public TrafficLight(WaitingPeopleParameters waitingPeopleParameters, WaitingCarsParameters waitingCarsParameters)
        {
            this.waitingPeopleParameters = waitingPeopleParameters;
            this.waitingCarsParameters = waitingCarsParameters;
        }

        public TrafficLightSignal TrafficLightSignal { get; set; }
        public TrafficLightState TrafficLightState 
        {
            get
            {
                if (TimeOfDay.Hour >= 1 && TimeOfDay.Hour <= 5)
                {
                    return TrafficLightState.UnsignalizedState;
                }

                return TrafficLightState.SignalizedState;
            }
        }


        public int CalculateDelay(int levelNumber)
        {
            int delay;

            switch (TrafficLightSignal)
            {
                case TrafficLightSignal.YellowLight:
                    return yellowSignalDelay;

                case TrafficLightSignal.RedLight:
                    delay = PedestriansTurn(levelNumber);
                    break;

                case TrafficLightSignal.GreenLight:
                    delay = CarsTurn(levelNumber);
                    break;

                default:
                    throw new Exception("Undefined traffic light signal");
            }

            if (delay > maxDelayTime)
            {
                return maxDelayTime;
            }

            return delay;
        }

        private int PedestriansTurn(int levelNumber)
        {
            int delay;

            switch (levelNumber)
            {
                case 1:
                case 2:
                    delay = (int)Math.Round(
                        AppearanceIntensity.CurrentPeopleAppearance * waitingPeopleParameters.WaitingPeopleAmount, 
                        MidpointRounding.AwayFromZero);
                    break;

                default:
                    throw new Exception("Level was not found!");
            }

            if (delay < minPeopleDelayTime)
            {
                return minPeopleDelayTime;
            }

            return delay;
        }

        private int CarsTurn(int levelNumber)
        {
            int delay;

            switch (levelNumber)
            {
                case 1:
                case 2:
                    delay = (int)Math.Round(
                        AppearanceIntensity.CurrentCarsAppearance * waitingCarsParameters.WaitingCarsAmount * carsCoefficient,
                        MidpointRounding.AwayFromZero);
                    break;

                default:
                    throw new Exception("Level was not found!");
            }


            if (delay < minCarsDelayTime)
            {
                return minCarsDelayTime;
            }

            return delay;
        }
    }
}
