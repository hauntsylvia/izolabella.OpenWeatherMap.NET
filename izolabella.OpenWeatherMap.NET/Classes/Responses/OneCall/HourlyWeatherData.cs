using izolabella.OpenWeatherMap.NET.Classes.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izolabella.OpenWeatherMap.NET.Classes.Responses.OneCall
{
    /// <summary>
    /// A class containing relevant information in regards to the OneCall API in OpenWeatherMap.
    /// </summary>
    public class HourlyWeatherData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HourlyWeatherData"/> class.
        /// </summary>
        public HourlyWeatherData(ulong WeatherTime, double Temperature, double FeelsLike,
                              int AtmosphericPressure, double Humidity, double DewPoint, double Cloudiness,
                              double UVI, double Visibility, double WindSpeed, double? WindGust, Weather[] Weather)
        {
            this.weatherTime = WeatherTime;
            this.Temperature = Temperature;
            this.FeelsLike = FeelsLike;
            this.AtmosphericPressure = AtmosphericPressure;
            this.humidity = Humidity;
            this.DewPoint = DewPoint;
            this.cloudiness = Cloudiness;
            this.UVI = UVI;
            this.Visibility = Visibility;
            this.WindSpeed = WindSpeed;
            this.WindGust = WindGust;
            this.Weather = Weather;
        }

        [JsonProperty("dt")]
        private readonly ulong weatherTime;
        /// <summary>
        /// The current time in UTC.
        /// </summary>
        public DateTime WeatherTime => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(this.weatherTime).ToUniversalTime();

        /// <summary>
        /// The current temperature.
        /// </summary>
        [JsonProperty("temp")]
        public double Temperature { get; }

        /// <summary>
        /// The human perception of the current temperature.
        /// </summary>
        [JsonProperty("feels_like")]
        public double FeelsLike { get; }

        /// <summary>
        /// Atmospheric pressure on the sea level, hPa.
        /// </summary>
        [JsonProperty("pressure")]
        public int AtmosphericPressure { get; }

        [JsonProperty("humidity")]
        private readonly double humidity;
        /// <summary>
        /// The current humidity as a double ranging from 0 - 1.
        /// </summary>
        public double Humidity => this.humidity / 100;

        /// <summary>
        /// Atmospheric temperature (varying according to pressure and humidity) below which water droplets begin to condense and dew can form.
        /// </summary>
        [JsonProperty("dew_point")]
        public double DewPoint { get; }

        [JsonProperty("clouds")]
        private readonly double cloudiness;
        /// <summary>
        /// The current cloudiness as a double ranging from 0 - 1.
        /// </summary>
        public double Cloudiness => this.cloudiness / 100;

        /// <summary>
        /// Current UV index.
        /// </summary>
        [JsonProperty("uvi")]
        public double UVI { get; }

        /// <summary>
        /// The current visibility average in metres.
        /// </summary>
        [JsonProperty("visibility")]
        public double Visibility { get; }

        /// <summary>
        /// Wind speed. Units – default: metre/sec, metric: metre/sec, imperial: miles/hour.
        /// </summary>
        [JsonProperty("wind_speed")]
        public double WindSpeed { get; }

        /// <summary>
        /// Wind gust. Units – default: metre/sec, metric: metre/sec, imperial: miles/hour.
        /// </summary>
        [JsonProperty("wind_gust")]
        public double? WindGust { get; }

        /// <summary>
        /// Group of weather parameters.
        /// </summary>
        [JsonProperty("weather")]
        public Weather[] Weather { get; }
    }
}
