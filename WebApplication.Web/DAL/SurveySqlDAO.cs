using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {
        private string connectionString;
        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<SurveyResults> Results()
        {
            IList<SurveyResults> results = new List<SurveyResults>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT survey_result.parkCode, park.parkName, COUNT(survey_result.parkCode) AS favorite FROM survey_result JOIN park ON(park.parkCode = survey_result.parkCode) GROUP BY survey_result.parkCode, park.parkName ORDER by favorite DESC", conn);

                    SqlDataReader reader2 = cmd.ExecuteReader();
                    while (reader2.Read())
                    {
                        SurveyResults survey = ConvertReaderToSurveyResults(reader2);
                        results.Add(survey);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return results;
        }

        public bool SaveSurvey(Survey survey)
        {
            bool isSaved = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();

                    isSaved = true;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return isSaved;
        }

        private Survey ConvertReaderToSurvey(SqlDataReader reader)
        {
            Survey survey = new Survey();
            survey.Id = Convert.ToInt32(reader["surveyId"]);
            survey.ParkCode = Convert.ToString(reader["parkCode"]);
            survey.Email = Convert.ToString(reader["emailAddress"]);
            survey.State = Convert.ToString(reader["state"]);
            survey.ActivityLevel = Convert.ToString(reader["activityLevel"]);
            return survey;
        }


        private SurveyResults ConvertReaderToSurveyResults(SqlDataReader reader2)
        {
            SurveyResults survey = new SurveyResults();
            survey.ParkCode = Convert.ToString(reader2["parkCode"]);
            survey.ParkName = Convert.ToString(reader2["parkName"]);
            survey.VoteCount = Convert.ToInt32(reader2["favorite"]);
            return survey;
        }
    }


}
