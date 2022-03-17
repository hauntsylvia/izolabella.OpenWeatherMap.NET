namespace izolabella.OpenWeatherMap.NET.Classes.Internals
{
    /// <summary>
    /// A class containing relevant wind information.
    /// </summary>
    public class Wind
    {
        /// <summary>
        /// A class containing relevant wind information.
        /// </summary>
        public Wind(decimal Speed, int Deg)
        {
            this.Speed = Speed;
            this.Deg = Deg;
        }
        /// <summary>
        /// The speed of the wind in miles per hour.
        /// </summary>
        public decimal Speed { get; set; }
        /// <summary>
        /// The current rotational degree of the wind.
        /// </summary>
        public int Deg { get; set; }
    }
}
