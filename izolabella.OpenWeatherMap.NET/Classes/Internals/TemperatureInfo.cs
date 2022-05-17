namespace izolabella.OpenWeatherMap.NET.Classes.Internals
{
    /// <summary>
    /// A base class of temperature information.
    /// </summary>
    public class TemperatureInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemperatureInfo"/> class.
        /// </summary>
        /// <param name="Day"></param>
        /// <param name="Night"></param>
        /// <param name="Eve"></param>
        /// <param name="Morn"></param>
        public TemperatureInfo(double Day, double Night, double Eve, double Morn)
        {
            this.Day = Day;
            this.Night = Night;
            this.Eve = Eve;
            this.Morn = Morn;
        }

        /// <summary>
        /// Temperature for the day.
        /// </summary>
        public double Day { get; }

        /// <summary>
        /// Temperature for the night.
        /// </summary>
        public double Night { get; }

        /// <summary>
        /// Temperature for the evening.
        /// </summary>
        public double Eve { get; }

        /// <summary>
        /// Temperature for the morning.
        /// </summary>
        public double Morn { get; }
    }
}
