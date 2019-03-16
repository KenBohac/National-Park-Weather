using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


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
        [Required(ErrorMessage = "* Must select a park.")]
        public string ParkCode { get; set; }

        /// <summary>
        /// Email address of the user.
        /// </summary>
        [Required(ErrorMessage = "* Must provide email.")]
        [EmailAddress(ErrorMessage ="Invalid email address.")]
        public string Email { get; set; }

        /// <summary>
        /// State that the user is from.
        /// </summary>
        [Required(ErrorMessage="* Must provide a state.")]
        public string State { get; set; }

        /// <summary>
        /// The activity level of the user.
        /// </summary>
        [Required(ErrorMessage = "* Must provide an activiy level.")]
        [MaxLength(100, ErrorMessage ="Maximum 100 characters, please.")]
        public string ActivityLevel { get; set; }

        public IList<SurveyResults> Results { get; set; }
    }

}
