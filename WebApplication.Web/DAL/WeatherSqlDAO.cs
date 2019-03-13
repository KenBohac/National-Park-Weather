using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private string connectionString;
        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList <Weather>GetWeather(string parkCode)
        {
            IList <Weather> weathers = new List <Weather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode;", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Weather weather  = ConvertReaderToWeather(reader);
                        weathers.Add(weather);
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            return weathers;
        }

        private Weather ConvertReaderToWeather(SqlDataReader reader)
        {
            Weather weather = new Weather();
            weather.ParkCode = Convert.ToString(reader["parkCode"]);
            weather.Day = Convert.ToInt32(reader["fiveDayForecastValue"]);
            weather.Low = Convert.ToInt32(reader["low"]);
            weather.High = Convert.ToInt32(reader["high"]);
            weather.Forecast = Convert.ToString(reader["forecast"]);
            return weather;
        }


    }
}
