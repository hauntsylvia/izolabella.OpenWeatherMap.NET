using izolabella.OpenWeatherMap.NET.Classes.Responses.CurrentWeatherData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace izolabella.OpenWeatherMap.NET.Classes.Processors.Full
{
    /// <summary>
    /// A class used for communicating with the OpenWeatherMapAPI for accessing current weather data. 
    /// </summary>
    public class CurrentWeatherDataProcessor : IProcessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentWeatherDataProcessor"/> class.
        /// </summary>
        public CurrentWeatherDataProcessor(OpenWeatherMapClient Instance)
        {
            this.Instance = Instance;
        }

        /// <inheritdoc/>
        public OpenWeatherMapClient Instance { get; }

        private readonly Dictionary<string, KeyValuePair<DateTime, WeatherResponse>> cache = new();

        /// <summary>
        /// Retrieve a <see cref="WeatherResponse"/> from the API using a zip.
        /// </summary>
        /// <param name="ZipCode">The zipcode to specify weather information.</param>
        /// <param name="CountryCode">The 2 letter country code to search in.</param>
        /// <returns>A <see cref="WeatherResponse">WeatherResponse</see> corresponding to the specified zipcode
        /// , or null if nothing can be retrieved.</returns>
        /// <remarks>This method handles cached results automatically.</remarks>
        public async Task<WeatherResponse?> GetWeatherByZipCodeAsync(string ZipCode, string CountryCode = "US")
        {
            if (this.cache.ContainsKey(ZipCode) && this.cache[ZipCode].Key > DateTime.Now)
            {
                return this.cache[ZipCode].Value;
            }
            else
            {
                WeatherResponse? WeatherResponse = await this.Instance.SendAsync<WeatherResponse>("/weather", new Dictionary<string, string>()
                {
                    {"zip", $"{ZipCode},{CountryCode}"},
                });
                if (WeatherResponse != null)
                {
                    if (this.cache.ContainsKey(ZipCode))
                    {
                        this.cache[ZipCode] = new KeyValuePair<DateTime, WeatherResponse>(DateTime.Now.AddMinutes(10), WeatherResponse);
                    }
                    else
                    {
                        this.cache.Add(ZipCode, new KeyValuePair<DateTime, WeatherResponse>(DateTime.Now.AddMinutes(10), WeatherResponse));
                    }

                    return WeatherResponse;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retrieve a <see cref="WeatherResponse"/> from the API using coordinates.
        /// </summary>
        /// <param name="Lat">Latitude</param>
        /// <param name="Lon">Longitude</param>
        /// <param name="Units">Units</param>
        /// <returns>A <see cref="WeatherResponse">WeatherResponse</see> corresponding to the specified zipcode
        /// , or null if nothing can be retrieved.</returns>
        public async Task<WeatherResponse?> GetWeatherByLatAndLonAsync(double Lat, double Lon, UnitTypes? Units = null)
        {
            WeatherResponse? WeatherResponse = await this.Instance.SendAsync<WeatherResponse>("/weather", new Dictionary<string, string>()
            {
                {"lat", $"{Lat}"},
                {"lon", $"{Lon}"}
            }, Units);
            return WeatherResponse;
        }
    }
}
