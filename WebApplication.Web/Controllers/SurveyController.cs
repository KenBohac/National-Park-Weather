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
        private ISurveyDAO surveyDAO;
        public SurveyController(ISurveyDAO surveyDAO)
        {
            this.surveyDAO = surveyDAO;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewSurvey(Survey survey)
        {
            surveyDAO.SaveSurvey(survey);
            return RedirectToAction("Index");
        }
    }
}