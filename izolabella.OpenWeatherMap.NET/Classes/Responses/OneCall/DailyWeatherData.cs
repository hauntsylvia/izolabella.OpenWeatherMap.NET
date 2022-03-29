using izolabella.OpenWeatherMap.NET.Classes.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izolabella.OpenWeatherMap.NET.Classes.Responses.OneCall
{
    /// <summary>
    /// A class containing relevant information in regards to the OneCall API in OpenWeatherMap. Daily.
    /// </summary>
    public class DailyWeatherData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DailyWeatherData"/> class.
        /// </summary>
        public DailyWeatherData(ulong WeatherTime, ulong Sunset, ulong Sunrise, DailyTemperatureInfo Temperature, TemperatureInfo FeelsLike,
                              int AtmosphericPressure, double Humidity, double DewPoint, double Cloudiness,
                              double UVI, double Visibility, double WindSpeed, double? WindGust, Weather[] Weather)
        {
            this.weatherTime = WeatherTime;
            this.sunset = Sunset;
            this.sunrise = Sunrise;
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
        /// The time this object represents in UTC.
        /// </summary>
        public DateTime WeatherTime => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(this.weatherTime).ToUniversalTime();

        [JsonProperty("sunset")]
        private readonly ulong sunset;
        /// <summary>
        /// The time the sun sets in UTC.
        /// </summary>
        public DateTime Sunset => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(this.sunset).ToUniversalTime();

        [JsonProperty("sunrise")]
        private readonly ulong sunrise;
        /// <summary>
        /// The time the sun rises in UTC.
        /// </summary>
        public DateTime Sunrise => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(this.sunrise).ToUniversalTime();

        /// <summary>
        /// The temperature.
        /// </summary>
        [JsonProperty("temp")]
        public DailyTemperatureInfo Temperature { get; }

        /// <summary>
        /// The human perception of the temperature.
        /// </summary>
        [JsonProperty("feels_like")]
        public TemperatureInfo FeelsLike { get; }

        /// <summary>
        /// Atmospheric pressure on the sea level, hPa.
        /// </summary>
        [JsonProperty("pressure")]
        public int AtmosphericPressure { get; }

        [JsonProperty("humidity")]
        private readonly double humidity;
        /// <summary>
        /// The humidity as a double ranging from 0 - 1.
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
        /// The cloudiness as a double ranging from 0 - 1.
        /// </summary>
        public double Cloudiness => this.cloudiness / 100;

        /// <summary>
        /// Current UV index.
        /// </summary>
        [JsonProperty("uvi")]
        public double UVI { get; }

        /// <summary>
        /// The visibility average in metres.
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
