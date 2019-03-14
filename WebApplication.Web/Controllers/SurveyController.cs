using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web.Controllers
{
    public class SurveyController : Controller
    {
        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;
        private ISurveyDAO surveyDAO;
        public SurveyController(IParkDAO parkDAO, IWeatherDAO weatherDAO, ISurveyDAO surveyDAO)
        {
            this.surveyDAO = surveyDAO;
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
        }


        [HttpGet]
        public IActionResult Index()
        {
            IList<Survey> results = surveyDAO.GetSurveyResults();
            return View(results);
        }

        [HttpGet]
        public IActionResult NewSurvey()
        {
            IList<Survey> surveys = surveyDAO.GetSurveyResults();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewSurvey(Survey survey)
        {

            if (ModelState.IsValid)
            {
                surveyDAO.SaveSurvey(survey);
                return RedirectToAction("Index");
            }

            else
            {
                return View(survey);
            }



        }
        [HttpGet]
        public IActionResult GetTempScale(string unit, string parkCode)
        {
            Park park = parkDAO.GetPark(parkCode);
            park.Weather = weatherDAO.GetWeather(park.ParkCode);
            if (unit == "C")
            {
                for(int i = 0; i < park.Weather.Count; i++)
                {
                    park.Weather[i].High = (park.Weather[i].High - 32) * (5 / 9);
                    park.Weather[i].Low = (park.Weather[i].Low - 32) * (5 / 9);
                }


            }
            return RedirectToAction(HomeController )
        }
    }
}