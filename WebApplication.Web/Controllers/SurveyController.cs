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
            IList<SurveyResults> results = surveyDAO.Results();
            return View(results);
        }

        [HttpGet]
        public IActionResult NewSurvey()
        {
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
    }
}