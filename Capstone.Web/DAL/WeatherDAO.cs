using Capstone.Web.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherDAO : IWeatherDAO
    {
        private string connectionString;
        public WeatherDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetWeathers(string parkCode)
        {
            List<Weather> results = new List<Weather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //TODO Filter by parkcode
                    string command = $"SELECT * FROM weather where parkCode = '{parkCode}';";
                    results = conn.Query<Weather>(command).ToList();

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
