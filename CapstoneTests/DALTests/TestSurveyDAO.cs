using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.Web.DAL;
using System.Collections.Generic;
using Capstone.Web.Models;

namespace CapstoneTests.DALTests
{
    //This just isn't working and I've struggled getting it this far with the dependencies and out of place files
    //However, look at the FavoriteParks view for extra code/park pictures.
    [TestClass]
    public class TestSurveyDAO
    {
        private string connectionString;
        public TestSurveyDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        [TestMethod]
        public void GetAllSurveysTest ()
        {
            SurveyDAO test = new SurveyDAO(connectionString);
            List<Survey> testList = new List<Survey>();
            testList = test.GetAllSurveys();
            Assert.IsTrue(testList.Count > 0);
        }
    }
}