using System;

namespace Assets.Models
{
    /// <summary>
    /// Represents game clock
    /// </summary>
    public static class TimeOfDay
    {
        private static int hour;

        public static int Hour
        {
            get => hour;
            set
            {
                if (value >= 0 && value <= 23)
                {
                    hour = value;
                }
            }
        }

        private static int minute;

        public static int Minute
        {
            get => minute;
            set
            {
                if (value >= 0 && value <= 60)
                {
                    minute = value;
                }
            }
        }

        private static int second;

        public static int Second
        {
            get => second;
            set
            {
                if (value >= 0 && value <= 60)
                {
                    second = value;
                }
            }
        }

        /// <summary>
        /// Amount of hours in a day
        /// </summary>
        public static int HoursInADay { get => 24; }

        /// <summary>
        /// Sets game clock to real current time
        /// </summary>
        public static void SetRealCurrentTime()
        {
            Hour = DateTime.Now.Hour;   
            Minute = DateTime.Now.Minute;   
            Second = DateTime.Now.Second;   
        }
    }
}
