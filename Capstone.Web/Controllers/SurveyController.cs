using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAO surveyInput { get; }
        public SurveyController(ISurveyDAO sqlDAO)
        {
            surveyInput = sqlDAO;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Survey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return View(survey);
            }
            surveyInput.AddSurvey(survey);
            return RedirectToAction("FavoriteParks", "FavoriteParks");
        }

        [HttpGet]
        public IActionResult Survey()
        {
            return View();
        }
    }
}