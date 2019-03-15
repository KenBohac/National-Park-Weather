using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;
using SSGeek.Web.Extensions;

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
        public IActionResult ParkDescription(string id, string temppref)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (temppref == null)
            {
                temppref = HttpContext.Session.GetString("temppref");
                if (temppref == null)
                {
                    temppref = "f";
                }
            }
            else
            {
                HttpContext.Session.SetString("temppref", temppref);
            }
            ViewData["temppref"] = temppref;
                
              
            Park park = parkDAO.GetPark(id);
            park.Weather = weatherDAO.GetWeather(park.ParkCode);

            return View(park);
        }


        //[HttpGet]
        //public IActionResult GetTempScale(string unit, string parkCode)
        //{
        //    Park park = parkDAO.GetPark(parkCode);
        //    park.Weather = weatherDAO.GetWeather(park.ParkCode);
        //    if (unit == "C")
        //    {
        //        for(int i = 0; i < park.Weather.Count; i++)
        //        {
        //            park.Weather[i].High = (park.Weather[i].High - 32) * (5 / 9);
        //            park.Weather[i].Low = (park.Weather[i].Low - 32) * (5 / 9);
        //        }


        //    }
        //    return RedirectToAction(HomeController )
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
