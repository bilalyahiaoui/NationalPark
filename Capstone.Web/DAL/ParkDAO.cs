using Capstone.Web.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkDAO : IParkDAO
    {
        private string connectionString;
        public ParkDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Park> GetAllParks()
        {
            List<Park> result = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string cmd = "SELECT * FROM park;";
                    result = conn.Query<Park>(cmd).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public Park GetDetails(string code)
        {
            Park result = new Park();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string cmd = "SELECT * from park where parkCode = @parkCode;";
                    result = conn.Query<Park>(cmd, new { @parkCode = code }).FirstOrDefault();
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
