using izolabella.OpenWeatherMap.NET.Classes.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izolabella.OpenWeatherMap.NET.Classes.Processors.Full
{
    /// <summary>
    /// A class used for communicating with the OpenWeatherMap API for the one-call API.
    /// </summary>
    public class OneCallProcessor : IProcessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneCallProcessor"/> class.
        /// </summary>
        /// <param name="Instance"></param>
        public OneCallProcessor(OpenWeatherMapClient Instance)
        {
            this.Instance = Instance;
        }

        /// <inheritdoc/>
        public OpenWeatherMapClient Instance { get; }

        /// <summary>
        /// Calls the only available endpoint for this API.
        /// </summary>
        /// <param name="Lat">Latitude</param>
        /// <param name="Lon">Longitude</param>
        /// <param name="Units">Units</param>
        /// <returns>A <see cref="OneCallWeatherResponse"/>.</returns>
        public async Task<OneCallWeatherResponse?> CallAsync(double Lat, double Lon, UnitTypes? Units = null)
        {
            OneCallWeatherResponse? WeatherResponse = await this.Instance.SendAsync<OneCallWeatherResponse>("/onecall", new Dictionary<string, string>()
            {
                {"lat", $"{Lat}"},
                {"lon", $"{Lon}"}
            }, Units);
            return WeatherResponse;
        }
    }
}
