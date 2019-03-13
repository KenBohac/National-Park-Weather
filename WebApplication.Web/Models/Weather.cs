using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Instantiates a new instance of weather.
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// The park code.
        /// </summary>
        public int ParkCode { get; set; }

        /// <summary>
        /// The day.
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// The low temperature for the given day at the given park.
        /// </summary>
        public int Low { get; set; }

        /// <summary>
        /// The high temperature for the given day at the given park.
        /// </summary>
        public int High { get; set; }

        /// <summary>
        /// The weather forecast for the given day at the given park.
        /// </summary>
        public string Forecast { get; set; }
    }
}
