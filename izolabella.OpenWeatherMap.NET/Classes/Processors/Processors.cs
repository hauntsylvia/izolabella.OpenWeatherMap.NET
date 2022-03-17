using izolabella.OpenWeatherMap.NET.Classes.Processors.Full;

namespace izolabella.OpenWeatherMap.NET.Classes.Processors
{
    /// <summary>
    /// A container for all processors provided by the client.
    /// </summary>
    public class Processors
    {
        internal Processors(OpenWeatherMapClient Instance)
        {
            this.CurrentWeatherDataProcessor = new(Instance);
            this.OneCallProcessor = new(Instance);
        }

        /// <summary>
        /// A processor containing methods for retrieving the current weather in a location.
        /// </summary>
        public CurrentWeatherDataProcessor CurrentWeatherDataProcessor { get; }

        /// <summary>
        /// A processor containing methods for retrieving all possible weather information in a location.
        /// </summary>
        public OneCallProcessor OneCallProcessor { get; }
    }
}
