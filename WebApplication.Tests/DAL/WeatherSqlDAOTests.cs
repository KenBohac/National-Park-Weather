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
    public class WeatherSqlDAOTests : NPGeekDAOTests
    {
        [TestMethod]
        public void GetWeatherReturnsListOfFiveWeatherObjects()
        {
            WeatherSqlDAO weatherDAO = new WeatherSqlDAO(ConnectionString);
            IList<Weather> weathers = weatherDAO.GetWeather("AAAA");
            Assert.AreEqual(5, weathers.Count);
        }
    }
}
