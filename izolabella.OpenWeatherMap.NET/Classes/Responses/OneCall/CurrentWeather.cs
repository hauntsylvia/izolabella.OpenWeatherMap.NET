using izolabella.OpenWeatherMap.NET.Classes.Internals;
using izolabella.OpenWeatherMap.NET.Classes.Responses.CurrentWeatherData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izolabella.OpenWeatherMap.NET.Classes.Responses.OneCall
{
    /// <summary>
    /// Current weather data.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CurrentWeather : WeatherResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentWeather"/> class.
        /// </summary>
        public CurrentWeather(Weather[] Weather,
                                  Main Main,
                                  Sys Sys,
                                  int Visibility,
                                  long Id,
                                  string Name,
                                  int Cod,
                                  ulong Timestamp,
                                  ulong Sunrise,
                                  ulong Sunset,
                                  double Temperature,
                                  double FeelsLike,
                                  int Pressure,
                                  int Humidity,
                                  double UVI,
                                  double Clouds,
                                  double WindSpeed,
                                  int WindDeg,
                                  double WindGust) : base(Weather, new(WindSpeed, WindDeg), Main, Sys, Visibility, Id, Name, Cod)
        {
            this.weatherTime = Timestamp;
            this.sunrise = Sunrise;
            this.sunset = Sunset;
            this.Temperature = Temperature;
            this.FeelsLike = FeelsLike;
            this.AtmosphericPressure = Pressure;
            this.humidity = Humidity;
            this.UVI = UVI;
            this.cloudiness = Clouds;
            this.WindSpeed = WindSpeed;
            this.WindDeg = WindDeg;
            this.WindGust = WindGust;
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
        public double Temperature { get; }

        /// <summary>
        /// The human perception of the temperature.
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
        /// Wind speed. Units – default: metre/sec, metric: metre/sec, imperial: miles/hour.
        /// </summary>
        [JsonProperty("wind_speed")]
        public double WindSpeed { get; }

        /// <summary>
        /// Wind degree.
        /// </summary>
        [JsonProperty("wind_deg")]
        public int WindDeg { get; }

        /// <summary>
        /// Wind gust. Units – default: metre/sec, metric: metre/sec, imperial: miles/hour.
        /// </summary>
        [JsonProperty("wind_gust")]
        public double? WindGust { get; }
    }
}
