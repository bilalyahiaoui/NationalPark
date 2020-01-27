using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather 
    {
        public string Parkcode { get; set; }
        public int FiveDaysForecastValue { get; set; }
        public int Low { get; set; }
        public int CelsiusLow
        {
            get
            {

                int calculation = Convert.ToInt32((Low - 32) * 0.55);
                    return calculation;
                
            }
        }

        public int CelsiusHigh
        {
            get
            {
                int calculation = Convert.ToInt32((High - 32) * 0.55);


                return calculation;
                
                
                
            }
        }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string DegreeType { get; set; } 
    }
}
