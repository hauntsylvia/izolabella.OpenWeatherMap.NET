namespace izolabella.OpenWeatherMap.NET.Classes.Internals
{
    /// <summary>
    /// Weather information.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Weather
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Main"></param>
        /// <param name="Description"></param>
        /// <param name="Icon"></param>
        [JsonConstructor]
        public Weather(int Id, string Main, string Description, string Icon)
        {
            this.Id = Id;
            this.Main = Main;
            this.Description = Description;
            this.icon = Icon;
        }

        /// <summary>
        /// The id for this object for the OpenWeatherMap API.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("main")]
        public string Main { get; }

        /// <summary>
        /// Description of the current weather.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        private readonly string icon;
        /// <summary>
        /// The url for an icon representing the current weather, as provided by the OpenWeatherMap API.
        /// </summary>
        public string WeatherIconUrl => "http://openweathermap.org/img/w/" + this.icon + ".png";
    }
}
