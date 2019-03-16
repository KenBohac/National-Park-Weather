using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;
namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class SurveySqlDAOTests : NPGeekDAOTests
    {
        [TestMethod]
        public void GetSurveyResultsReturnsOneResult()
        {
            SurveySqlDAO surveyDAO = new SurveySqlDAO(ConnectionString);
            IList<SurveyResults> results = surveyDAO.Results();
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void SaveSurveyAddsANewSurvey()
        {
            Survey survey2 = new Survey();
            survey2.ActivityLevel = "Sedentary";
            survey2.Email = "email@gmail.com";
            survey2.ParkCode = "AAAA";
            survey2.State = "Ohio";
            SurveySqlDAO surveyDAO = new SurveySqlDAO(ConnectionString);
            int startingRowCount = GetRowCount("survey_result");
            surveyDAO.SaveSurvey(survey2);
            int endingRowCount = GetRowCount("survey_result");
            Assert.AreNotEqual(startingRowCount, endingRowCount);
        }
    }
}
