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
    public class Minutely
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Minutely"/> class.
        /// </summary>
        /// <param name="TimeUnix">Time of the forecasted data, unix, UTC.</param>
        /// <param name="PrecipitationVolume"></param>
        public Minutely(ulong TimeUnix, decimal PrecipitationVolume)
        {
            this.TimeUnix = TimeUnix;
            this.PrecipitationVolume = PrecipitationVolume;
        }

        private ulong TimeUnix { get; }
        /// <summary>
        /// Time of the forecasted data in UTC.
        /// </summary>
        public DateTime TimestampUTC => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(this.TimeUnix).ToUniversalTime();

        /// <summary>
        /// Precipitation volume, mm.
        /// </summary>
        public decimal PrecipitationVolume { get; }
    }
}
