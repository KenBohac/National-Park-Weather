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
    public class ParkSqlDAOTests : NPGeekDAOTests
    {
        [DataTestMethod]
        public void GetParksReturnsOnePark()
        {
            ParkSqlDAO parkDAO = new ParkSqlDAO(ConnectionString);
            IList<Park> parks = parkDAO.GetAllParks();
            Assert.AreEqual(1, parks.Count);
        }

        
    }
}
