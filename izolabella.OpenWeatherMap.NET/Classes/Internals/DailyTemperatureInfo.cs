using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izolabella.OpenWeatherMap.NET.Classes.Internals
{
    /// <summary>
    /// A class containing full temperature information.
    /// </summary>
    public class DailyTemperatureInfo : TemperatureInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DailyTemperatureInfo"/> class.
        /// </summary>
        /// <param name="Day"></param>
        /// <param name="Night"></param>
        /// <param name="Eve"></param>
        /// <param name="Morn"></param>
        /// <param name="Min"></param>
        /// <param name="Max"></param>
        public DailyTemperatureInfo(double Day, double Night, double Eve, double Morn, double Min, double Max) : base(Day, Night, Eve, Morn)
        {
            this.Min = Min;
            this.Max = Max;
        }

        /// <summary>
        /// Minimum temperature expected.
        /// </summary>
        public double Min { get; }

        /// <summary>
        /// Maximum temperature expected.
        /// </summary>
        public double Max { get; }
    }
}
