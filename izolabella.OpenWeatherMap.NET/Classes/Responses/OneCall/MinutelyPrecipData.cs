using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izolabella.OpenWeatherMap.NET.Classes.Responses.OneCall
{
    /// <summary>
    /// Minutely precip. data.
    /// </summary>
    public class MinutelyPrecipData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinutelyPrecipData"/> class.
        /// </summary>
        /// <param name="TimeUnix">Time of the forecasted data, unix, UTC.</param>
        /// <param name="PrecipitationVolume"></param>
        public MinutelyPrecipData(ulong TimeUnix, double PrecipitationVolume)
        {
            this.timestamp = TimeUnix;
            this.PrecipitationVolume = PrecipitationVolume;
        }

        [JsonProperty("dt")]
        private readonly ulong timestamp;
        /// <summary>
        /// Time of the forecasted data in UTC.
        /// </summary>
        public DateTime TimestampUTC => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(this.timestamp).ToUniversalTime();

        /// <summary>
        /// Precipitation volume, mm.
        /// </summary>
        public double PrecipitationVolume { get; }
    }
}
