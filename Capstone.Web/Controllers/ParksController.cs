using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Capstone.Web.Controllers
{
    public class ParksController : Controller
    {
        private IParkDAO parks { get; }
        private IWeatherDAO weatherDAO { get; }
        Weather weather = new Weather();

        public ParksController(IParkDAO parkDAO, IWeatherDAO weatherDAO)
        {
            this.parks = parkDAO;
            this.weatherDAO = weatherDAO;
        }
         
        public IActionResult Index()
        {
            IList<Park> AllParks = parks.GetAllParks();
            return View(AllParks);
        }
        public IActionResult Details(string parkCode, string degreeType)
        {
            Park details = new Park();
            
            details = parks.GetDetails(parkCode);
            details.weather = weatherDAO.GetWeathers(details.ParkCode);

            foreach (var item in details.weather)
            {
                item.DegreeType = degreeType;
            }
            

            if (HttpContext.Session.GetString("Degree_Type_Selection") == null)
            {
                SaveActiveDegreeType(details);
            }
            else
            {
                string weather_degree_type = HttpContext.Session.GetString("Degree_Type_Selection");
                
                Park parkFromSession = JsonConvert.DeserializeObject<Park>(weather_degree_type);

                foreach(Weather weather in parkFromSession.weather)
                {
                    if(weather.DegreeType == null)
                    {
                        SaveActiveDegreeType(details);
                    }
                    else
                    {
                        foreach(var item in details.weather)
                        {
                            if (degreeType != null)
                            {
                                if (weather.DegreeType != degreeType)
                                {
                                    item.DegreeType = degreeType;
                                    SaveActiveDegreeType(details);
                                }
                            }
                            else
                            {
                                if (weather.DegreeType != degreeType)
                                {

                                    item.DegreeType = weather.DegreeType;
                                }
                                else
                                {
                                    item.DegreeType = degreeType;
                                }
                            }
                        }
                    }
                }
            }
            
            return View(details);
        }


        private void SaveActiveDegreeType(Park park)
        {
            //TODO 20. Turn cart object into a json string
            string parksession = JsonConvert.SerializeObject(park);
            //TODO 21. Add string to session
            HttpContext.Session.SetString("Degree_Type_Selection", parksession);
        }

        

    }
}