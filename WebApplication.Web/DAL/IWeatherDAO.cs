﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IWeatherDAO
    {
       IList <Weather> GetWeather(string parkCode);
    }
}
