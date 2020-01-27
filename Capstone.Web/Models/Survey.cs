using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Capstone.Web.Models
{
    //Changing dapper table functionality
    [Table("survey_result")]
    public class Survey
    {
        //Stops trying to insert a PK
        [Dapper.Contrib.Extensions.Key]
        public int SurveyId { get; set; }
        [Required(ErrorMessage = "Select your favorite National Park")]
        [Display(Name = "Favorite National Park")]
        public string ParkCode { get; set; }
        [Required(ErrorMessage ="Please provide a valid Email address")]
        [EmailAddress]
        [Display(Name = "Your email")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Please select your state of residence")]
        [Display(Name = "State of residence")]
        [MaxLength(16)]
        public string State { get; set; }
        [Required(ErrorMessage = "Please select an activity level")]
        [Display(Name = "Activity level")]
        [MaxLength(16)]
        public string ActivityLevel { get; set; }

        //Temporary until we figure out how to import names and codes
        public static List<SelectListItem> ListOfNationalParks = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Cuyahoga Valley National Park", Value = "CVNP"},
            new SelectListItem() { Text = "Everglades National Park", Value = "ENP"},
            new SelectListItem() { Text = "Grand Canyon National Park", Value = "GCNP"},
            new SelectListItem() { Text = "Glacier National Park", Value = "GNP"},
            new SelectListItem() { Text = "Great Smoky Mountains National Park", Value = "GSMNP"},
            new SelectListItem() { Text = "Grand Teton National Park", Value = "GTNP"},
            new SelectListItem() { Text = "Mount Rainier National Park", Value = "MRNP"},
            new SelectListItem() { Text = "Rocky Mountain National Park", Value = "RMNP"},
            new SelectListItem() { Text = "Yellowstone National Park", Value = "YNP"},
            new SelectListItem() { Text = "Yosemite National Park", Value = "YNP2"},
        };

        public static List<SelectListItem> ListOfActivityLevels = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Inactive"},
            new SelectListItem() { Text = "Sedentary"},
            new SelectListItem() { Text = "Active"},
            new SelectListItem() { Text = "Extremely Active"},
        };

        public static List<SelectListItem> ListOfStates = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Alabama" },
                new SelectListItem() { Text = "Alaska" },
                new SelectListItem() { Text = "Arizona" },
                new SelectListItem() { Text = "Arcansas" },
                new SelectListItem() { Text = "California" },
                new SelectListItem() { Text = "Colorado" },
                new SelectListItem() { Text = "Connecticut" },
                new SelectListItem() { Text = "Delaware" },
                new SelectListItem() { Text = "Florida" },
                new SelectListItem() { Text = "Georgia" },
                new SelectListItem() { Text = "Hawaii" },
                new SelectListItem() { Text = "Idaho" },
                new SelectListItem() { Text = "Illinois" },
                new SelectListItem() { Text = "Indiana" },
                new SelectListItem() { Text = "Iowa" },
                new SelectListItem() { Text = "Kansas" },
                new SelectListItem() { Text = "Kentucky" },
                new SelectListItem() { Text = "Louisiana" },
                new SelectListItem() { Text = "Maine" },
                new SelectListItem() { Text = "Maryland" },
                new SelectListItem() { Text = "Massachusetts" },
                new SelectListItem() { Text = "Michigan" },
                new SelectListItem() { Text = "Minnesota" },
                new SelectListItem() { Text = "Mississippi" },
                new SelectListItem() { Text = "Missouri" },
                new SelectListItem() { Text = "Montana" },
                new SelectListItem() { Text = "Nebraska" },
                new SelectListItem() { Text = "Nevada" },
                new SelectListItem() { Text = "New Hampshire" },
                new SelectListItem() { Text = "New Jersey" },
                new SelectListItem() { Text = "New Mexico" },
                new SelectListItem() { Text = "New York" },
                new SelectListItem() { Text = "North Carolina" },
                new SelectListItem() { Text = "North Dakota" },
                new SelectListItem() { Text = "Ohio" },
                new SelectListItem() { Text = "Oklahoma" },
                new SelectListItem() { Text = "Oregon" },
                new SelectListItem() { Text = "Pennsylvania" },
                new SelectListItem() { Text = "Rhode Island" },
                new SelectListItem() { Text = "South Carolina" },
                new SelectListItem() { Text = "South Dakota" },
                new SelectListItem() { Text = "Tennessee" },
                new SelectListItem() { Text = "Texas" },
                new SelectListItem() { Text = "Utah" },
                new SelectListItem() { Text = "Vermont" },
                new SelectListItem() { Text = "Virginia" },
                new SelectListItem() { Text = "Washington" },
                new SelectListItem() { Text = "West Virginia" },
                new SelectListItem() { Text = "Wisconsin" },
                new SelectListItem() { Text = "Wyoming" },
            };

    }
}
