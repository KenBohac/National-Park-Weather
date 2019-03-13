using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Instantiates new instance of a survey.
    /// </summary>
    public class Survey
    {
        /// <summary>
        /// Survery ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The park code of the park the user visted.
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// State that the user is from.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The activity level of the user.
        /// </summary>
        public string ActivityLevel { get; set; }
    }
}
