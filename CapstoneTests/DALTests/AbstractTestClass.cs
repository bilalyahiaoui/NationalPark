using Capstone.Web.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace CapstoneTests.DALTests
{
    [TestClass]
    public class AbstractTestClass
    {
        private static string connectionString = $"Data Source=.sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";

        public ParkDAO testParkDAO = new ParkDAO(connectionString);

        public TestSurveyDAO testSurveyDAO = new TestSurveyDAO(connectionString);

        public TransactionScope transactionScope;

        [TestInitialize]
        public void Initialize()
        {
            transactionScope = new TransactionScope();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"INSERT into park VALUES ('YOLO', 'Live Fast East Glass', 'Baller', 50000, 210000, 1, 4000, 'Volcanic', 2019, 0,'No Comment', 'Lucas Zacherl', 'Aside from the weekly volcanoe sacrifice on Thursdays, nothing much happens.',666,0);", conn);
                cmd.ExecuteNonQuery(); cmd = new SqlCommand($"INSERT into survey_result VALUES ('YOLO','Test2','Baller','Extremely Active');", conn);
                cmd.ExecuteNonQuery(); cmd = new SqlCommand($"INSERT into weather VALUES ('YOLO', 1, 70, 60, 'cloudy');", conn); cmd.ExecuteNonQuery();
            }
        }

        [TestCleanup] public void Cleanup() { transactionScope.Dispose(); }
    }
}
