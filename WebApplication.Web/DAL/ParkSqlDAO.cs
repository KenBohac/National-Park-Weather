using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebApplication.Web.Models;


namespace WebApplication.Web.DAL
{
    public class ParkSqlDAO: IParkDAO
    {
        private string connectionString;
        public ParkSqlDAO (string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Park> GetAllParks()
        {
            IList<Park> parks = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())

                    {
                        Park park = new Park();


                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.Name = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        park.NumberofCampsites = Convert.ToInt32(reader["numberofCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.Quote = Convert.ToString(reader["inspirationalQuote"]);
                        park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.Description = Convert.ToString(reader["parkDescription"]);
                        park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberofAnimalSpecies"]);

                        parks.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return parks;

        
        }

        public Park GetPark()
        {
            Park park = new Park();
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM park", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())

                {

                    park.ParkCode = Convert.ToString(reader["parkCode"]);
                    park.Name = Convert.ToString(reader["parkName"]);
                    park.State = Convert.ToString(reader["state"]);
                    park.Acreage = Convert.ToInt32(reader["acreage"]);
                    park.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
                    park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                    park.NumberofCampsites = Convert.ToInt32(reader["numberofCampsites"]);
                    park.Climate = Convert.ToString(reader["climate"]);
                    park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                    park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                    park.Quote = Convert.ToString(reader["inspirationalQuote"]);
                    park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                    park.Description = Convert.ToString(reader["parkDescription"]);
                    park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                    park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberofAnimalSpecies"]);


                }
            }
        }

        catch (SqlException ex)
        {
            throw;
        }
            return park;
        }

        public IList<Weather> GetWeather()
        {
            throw new NotImplementedException();
        }
    } 
}
