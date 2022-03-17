using izolabella.OpenWeatherMap.NET.Classes.Internals;
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
        /// 
        /// </summary>
        /// <param name="Lat"></param>
        /// <param name="Lon"></param>
        /// <param name="TimezoneName"></param>
        /// <param name="Current"></param>
        [JsonConstructor]
        public OneCallWeatherResponse(decimal Lat, decimal Lon, string TimezoneName, CurrentWeather Current)
        {
            this.Lat = Lat;
            this.Lon = Lon;
            this.TimezoneName = TimezoneName;
            this.Current = Current;
        }

        /// <summary>
        /// Latitude of the location of this request.
        /// </summary>
        [JsonProperty("lat")]
        public decimal Lat { get; }

        /// <summary>
        /// Longitude of the location of this request.
        /// </summary>
        [JsonProperty("lon")]
        public decimal Lon { get; }

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
    }
}
