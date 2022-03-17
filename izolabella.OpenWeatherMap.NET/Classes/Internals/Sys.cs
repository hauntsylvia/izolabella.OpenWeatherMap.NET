using System;

namespace izolabella.OpenWeatherMap.NET.Classes.Internals
{
    /// <summary>
    /// A class containing information used for the country code, sunrise, and sunset.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Sys
    {
        /*
            "type": 1,
            "id": 5122,
            "message": 0.0139,
            "country": "US",
            "sunrise": 1560343627,
            "sunset": 1560396563
         */

        /// <summary>
        /// A class containing information used for the country code, sunrise, and sunset.
        /// </summary>
        public Sys(string? Country, int Sunrise, int Sunset)
        {
            this.Country = Country;
            this.sunrise = Sunrise;
            this.sunset = Sunset;
        }

        /// <summary>
        /// The country in which this information is relevant to.
        /// </summary>
        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("sunrise")]
        private readonly int sunrise;
        /// <summary>
        /// The time the sun rises in UTC.
        /// </summary>
        public DateTime Sunrise
        {
            get
            {
                DateTime N1970 = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                N1970 = N1970.AddSeconds(this.sunrise).ToUniversalTime();
                return N1970;
            }
        }

        [JsonProperty("sunset")]
        private readonly int sunset;
        /// <summary>
        /// The time the sun sets in UTC.
        /// </summary>
        public DateTime TodaysSunset
        {
            get
            {
                DateTime N1970 = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                N1970 = N1970.AddSeconds(this.sunset).ToUniversalTime();
                return N1970;
            }
        }
    }
}
