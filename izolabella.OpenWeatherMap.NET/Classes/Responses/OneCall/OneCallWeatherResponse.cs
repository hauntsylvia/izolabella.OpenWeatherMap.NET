using izolabella.OpenWeatherMap.NET.Classes.Internals;
using izolabella.OpenWeatherMap.NET.Classes.Responses.CurrentWeatherData;
using izolabella.OpenWeatherMap.NET.Classes.Responses.OneCall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izolabella.OpenWeatherMap.NET.Classes.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class OneCallWeatherResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneCallWeatherResponse"/> class.
        /// </summary>
        /// <param name="Lat"></param>
        /// <param name="Lon"></param>
        /// <param name="TimezoneName"></param>
        /// <param name="Current"></param>
        /// <param name="Minutely"></param>
        /// <param name="Hourly"></param>
        /// <param name="Daily"></param>
        [JsonConstructor]
        public OneCallWeatherResponse(double Lat,
                                      double Lon,
                                      string TimezoneName,
                                      CurrentWeather Current,
                                      MinutelyPrecipData[] Minutely,
                                      HourlyWeatherData[] Hourly,
                                      DailyWeatherData[] Daily)
        {
            this.Lat = Lat;
            this.Lon = Lon;
            this.TimezoneName = TimezoneName;
            this.Current = Current;
            this.Minutely = Minutely.OrderBy(M => M.TimestampUTC).ToArray();
            this.Hourly = Hourly.OrderBy(H => H.WeatherTime).ToArray();
            this.Daily = Daily.OrderBy(D => D.WeatherTime).ToArray();
        }

        /// <summary>
        /// Latitude of the location of this request.
        /// </summary>
        [JsonProperty("lat")]
        public double Lat { get; }

        /// <summary>
        /// Longitude of the location of this request.
        /// </summary>
        [JsonProperty("lon")]
        public double Lon { get; }

        /// <summary>
        /// The timezone name.
        /// </summary>
        [JsonProperty("timezone")]
        public string TimezoneName { get; }

        /// <summary>
        /// Current weather information.
        /// </summary>
        [JsonProperty("current")]
        public CurrentWeather Current { get; }

        /// <summary>
        /// Minutely precipitation data.
        /// </summary>
        public MinutelyPrecipData[] Minutely { get; }

        /// <summary>
        /// Hourly weather data.
        /// </summary>
        public HourlyWeatherData[] Hourly { get; }

        /// <summary>
        /// Daily weather data.
        /// </summary>
        public DailyWeatherData[] Daily { get; }
    }
}
