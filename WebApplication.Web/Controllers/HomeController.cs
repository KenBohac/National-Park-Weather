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
    public class HomeController : Controller
    {
        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;
        public HomeController(IParkDAO parkDAO, IWeatherDAO weatherDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetAllParks();
            return View(parks);
        }

        [HttpGet]
        public IActionResult ParkDescription(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
                
              
            Park park = parkDAO.GetPark(id);
            park.Weather = weatherDAO.GetWeather(park.ParkCode);

            return View(park);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
