using Capstone.Web.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    //Functions with the query and results generated from GetAllFavoriteParks
    public class FavoriteParksDAO : IFavoriteParksDAO
    {
        private string connectionString;
        public FavoriteParksDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<FavoriteParksViewModel> GetAllFavoriteParks()
        {
            List<FavoriteParksViewModel> results = new List<FavoriteParksViewModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string command = @"SELECT park.parkCode, park.parkName, COUNT(park.parkCode) AS 'surveyCount' FROM park JOIN survey_result ON park.parkCode = survey_result.parkCode GROUP BY park.parkCode, park.parkName ORDER BY COUNT(park.parkCode) desc, park.parkName;";
                    results = conn.Query<FavoriteParksViewModel>(command).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return results;
        }
    }
}
