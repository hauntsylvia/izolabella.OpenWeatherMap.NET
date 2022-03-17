global using Newtonsoft.Json;

using izolabella.OpenWeatherMap.NET.Classes;
using izolabella.OpenWeatherMap.NET.Classes.Processors;
using izolabella.OpenWeatherMap.NET.Classes.Processors.Full;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace izolabella.OpenWeatherMap.NET
{
    /// <summary>
    /// Types of units to use.
    /// </summary>
    public enum UnitTypes
    {
        /// <summary>
        /// Fahrenheit, miles, etc.
        /// </summary>
        Imperial,
        /// <summary>
        /// Celsius, kilometres, etc.
        /// </summary>
        Metric,
        /// <summary>
        /// The default as specified by the endpoint being called.
        /// </summary>
        Default
    }
    /// <summary>
    /// A class for interacting with the OpenWeatherMap API.
    /// </summary>
    /// <remarks>
    /// If this class is created with no application id, methods will return null until <see cref="AppId"/> is set.
    /// </remarks>
    public class OpenWeatherMapClient
    {
        /// <summary>
        /// Initializes a new <see cref="OpenWeatherMapClient"/> for interacting with the OpenWeatherMap API.
        /// </summary>
        /// <remarks>
        /// If this class is created with no application id, methods will return null until <see cref="AppId"/> is set.
        /// </remarks>
        public OpenWeatherMapClient(string AppId, UnitTypes Units)
        {
            this.appId = AppId;
            this.Units = Units;
            this.Client.BaseAddress = new("https://api.openweathermap.org/data/2.5");
            this.Processors = new(this);
        }
        /// <summary>
        /// Initializes a new <see cref="OpenWeatherMapClient"/> for interacting with the OpenWeatherMap API.
        /// </summary>
        /// <remarks>
        /// If this class is created with no application id, methods will return null until <see cref="AppId"/> is set.
        /// </remarks>
        public OpenWeatherMapClient(string AppId)
        {
            this.appId = AppId;
            this.Client.BaseAddress = new("https://api.openweathermap.org/data/2.5");
            this.Processors = new(this);
        }
        /// <summary>
        /// Initializes a new <see cref="OpenWeatherMapClient"/> for interacting with the OpenWeatherMap API.
        /// </summary>
        /// <remarks>
        /// If this class is created with no application id, methods will return null until <see cref="AppId"/> is set.
        /// </remarks>
        public OpenWeatherMapClient()
        {
            this.Client.BaseAddress = new("https://api.openweathermap.org/data/2.5");
            this.Processors = new(this);
        }

        private string? appId;
        /// <summary>
        /// This application's id as specified by the OpenWeatherMap API.
        /// </summary>
        public string AppId { get => this.appId ?? throw new NullReferenceException($"{nameof(this.AppId)} not specified."); set => this.appId = value; }
        internal HttpClient Client { get; } = new()
        {
            Timeout = TimeSpan.FromSeconds(15),
        };

        /// <summary>
        /// A container for all processors provided by the client.
        /// </summary>
        public Processors Processors { get; }

        /// <summary>
        /// The units currently being used by this instance.
        /// </summary>
        public UnitTypes Units { get; set; } = UnitTypes.Default;

        internal async Task<T?> SendAsync<T>(string EndUrl, Dictionary<string, string> Args)
        {
            UriBuilder UriB = new(this.Client.BaseAddress + EndUrl);
            System.Collections.Specialized.NameValueCollection Query = HttpUtility.ParseQueryString(string.Empty);
            foreach (KeyValuePair<string, string> KeyPair in Args)
            {
                Query[KeyPair.Key] = KeyPair.Value;
            }

            Query["appid"] = this.AppId;
            Query["units"] = this.Units.ToString().ToLower();
            UriB.Query = Query.ToString();
            HttpRequestMessage Req = new(HttpMethod.Get, UriB.Uri);
            HttpResponseMessage Msg = await this.Client.SendAsync(Req);
            HttpContent Content = (Msg).Content;
            string ResultingContent = await Content.ReadAsStringAsync();
            T? Result = JsonConvert.DeserializeObject<T>(ResultingContent);
            return Result;
        }

        private readonly Dictionary<string, KeyValuePair<DateTime, WeatherResponse>> cache = new();

        /// <summary>
        /// Retrieve weather within a specific zipcode.
        /// </summary>
        /// <param name="ZipCode">The 5 digit zipcode to specify search results.</param>
        /// <returns>A <see cref="WeatherResponse">WeatherResponse</see> corresponding to the specified zipcode
        /// , or null if nothing can be retrieved.</returns>
        [Obsolete($"Will be replaced soon. Consider using the {nameof(CurrentWeatherDataProcessor)} class instead.")]
        public async Task<WeatherResponse?> GetWeatherByZipCode(string ZipCode)
        {
            if (this.cache.ContainsKey(ZipCode) && this.cache[ZipCode].Key > DateTime.Now)
            {
                return this.cache[ZipCode].Value;
            }
            else
            {
                WeatherResponse? WeatherResponse = await this.SendAsync<WeatherResponse>("/weather", new Dictionary<string, string>()
                {
                    {"zip", ZipCode},
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
    }
}
