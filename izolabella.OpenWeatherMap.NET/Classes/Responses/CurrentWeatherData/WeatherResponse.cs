using izolabella.OpenWeatherMap.NET.Classes.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izolabella.OpenWeatherMap.NET.Classes.Responses.CurrentWeatherData
{
    /// <summary>
    /// A response containing relevant weather information returned from the OpenWeatherMap API.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WeatherResponse
    {
        /// <summary>
        /// A response containing relevant weather information returned from the OpenWeatherMap API.
        /// </summary>
        [JsonConstructor]
        public WeatherResponse(Weather[] Weather, Wind Wind, Main Main, Sys Sys, int Visibility, long Id, string? Name, int Cod)
        {
            this.Weather = Weather;
            this.Wind = Wind;
            this.Main = Main;
            this.Sys = Sys;
            this.Visibility = Visibility;
            this.Id = Id;
            this.CityName = Name;
            this.Cod = Cod;

        }

        /// <summary>
        /// Contains frontend information.
        /// </summary>
        [JsonProperty("weather")]
        public Weather[] Weather { get; }

        /// <summary>
        /// Contains wind information.
        /// </summary>
        [JsonProperty("wind")]
        public Wind Wind { get; }

        /// <summary>
        /// Contains information such as temperature and humidity.
        /// </summary>
        [JsonProperty("main")]
        public Main Main { get; }

        /// <summary>
        /// Contains information such as the sunrise and sunset time.
        /// </summary>
        [JsonProperty("sys")]
        public Sys Sys { get; }

        /// <summary>
        /// Average visibility in meters.
        /// </summary>
        [JsonProperty("visibility")]
        public int Visibility { get; }

        /// <summary>
        /// Weather condition id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; }

        /// <summary>
        /// City name.
        /// </summary>
        [JsonProperty("name")]
        public string? CityName { get; }

        /// <summary>
        /// Internal parameters.
        /// </summary>
        [JsonProperty("cod")]
        public int Cod { get; }
    }
}
