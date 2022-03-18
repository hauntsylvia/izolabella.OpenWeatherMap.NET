global using Newtonsoft.Json;

using izolabella.OpenWeatherMap.NET.Classes;
using izolabella.OpenWeatherMap.NET.Classes.Processors;
using izolabella.OpenWeatherMap.NET.Classes.Processors.Full;
using izolabella.OpenWeatherMap.NET.Classes.Responses.CurrentWeatherData;
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
    }
}
