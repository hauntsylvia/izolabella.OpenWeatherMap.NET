namespace izolabella.OpenWeatherMap.NET.Classes.Processors.Full
{
    /// <summary>
    /// An interface used for structuring weather processors.
    /// </summary>
    public interface IProcessor
    {
        /// <summary>
        /// The current instance of the <see cref="OpenWeatherMapClient"/> this is a child of.
        /// </summary>
        public OpenWeatherMapClient Instance { get; }
    }
}
