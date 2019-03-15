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

        public IList<Survey> GetSurveyResults()
        {
            IList<Survey> surveys = new List<Survey>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM survey_result;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Survey survey = ConvertReaderToSurvey(reader);
                        surveys.Add(survey);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return surveys;
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

        public int GetVoteCount(string parkCode)
        {
            int voteCount = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM survey_result WHERE parkCode=@parkCode;", conn);
                    cmd.Parameters.AddWithValue("@parkCode", @parkCode);
                    
                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return voteCount;
        }
        //public string GetParkName(string parkCode)
        //{
        //    string parkName = "";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel);", conn);
        //            cmd.Parameters.AddWithValue("@parkCode", @parkCode);

        //            cmd.ExecuteNonQuery();

        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw;
        //    }
        //    return parkName;
        //}
    }


}
