namespace izolabella.OpenWeatherMap.NET.Classes.Internals
{
    /// <summary>
    /// A group of weather parameters.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Main
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main(decimal FeelsLike, decimal Temp, decimal TempMinimum, decimal TempMaximum, int Pressure, int Humidity)
        {
            this.FeelsLike = FeelsLike;
            this.Temp = Temp;
            this.TempMinimum = TempMinimum;
            this.TempMaximum = TempMaximum;
            this.Pressure = Pressure;
            this.Humidity = Humidity;

        }

        /// <summary>
        /// The current temperature in Celsius as perceived by a human.
        /// </summary>
        [JsonProperty("feels_like")]
        public decimal FeelsLike { get; set; }

        /// <summary>
        /// The current temperature in Celsius.
        /// </summary>
        [JsonProperty("temp")]
        public decimal Temp { get; set; }

        /// <summary>
        /// The minimum temperature currently observed in Celsius, unless this was returned from a forecast: the minimum temperature forecasted in Celsius.
        /// </summary>
        [JsonProperty("temp_min")]
        public decimal TempMinimum { get; set; }

        /// <summary>
        /// The maximum temperature currently observed in Celsius, unless this was returned from a forecast: the maximum temperature forecasted in Celsius.
        /// </summary>
        [JsonProperty("temp_max")]
        public decimal TempMaximum { get; set; }

        /// <summary>
        /// Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa
        /// </summary>
        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        /// <summary>
        /// The current humidity, %.
        /// </summary>
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }
}
