using Capstone.Web.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyDAO : ISurveyDAO
    {
        private string connectionString;
        public SurveyDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        

        public List<Survey> GetAllSurveys ()
        {
            List<Survey> results = new List<Survey>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string command = "SELECT * FROM survey_results;";
                    results = conn.Query<Survey>(command).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return results;
        }

        public bool AddSurvey(Survey survey)
        {
            long id = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    id = connection.Insert(survey);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return !(id == -1);
        }
    }
}
