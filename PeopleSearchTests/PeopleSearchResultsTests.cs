using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using PeopleSearchAPI.Controllers;
using PeopleSearchAPI.Models;

namespace PeopleSearchTests
{
    [TestClass]
    public class PeopleSearchResultsTests
    {
        //private string _connection = @"Server=(localdb)\mssqllocaldb;Database=HealthCatalystPeople;Trusted_Connection=True;ConnectRetryCount=0";
        PeopleContext _context;

        public PeopleSearchResultsTests()
        {
            InitContext();
        }
        public void InitContext()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>().UseInMemoryDatabase("people-db");
            var context = new PeopleContext(options.Options);
            _context = context;
        }
        /// <summary>
        /// Check the result to make sure we got more than 0 people back
        /// </summary>
        [TestMethod]
        public void GetAllPeople()
        {
            PeopleController pplController = new PeopleController(_context);
            var result = pplController.GetAllPeople();
            Assert.IsTrue(result.Count() > 0);
        }
        /// <summary>
        /// Do a search on the letter 'C' knowing that we should get 3 results (2 with last name having C and 1 first name)
        /// </summary>
        [TestMethod]
        public void SearchForNamesWithLetterC()
        {
            PeopleController pplController = new PeopleController(_context);
            var result = pplController.SearchByName("C");
            Assert.AreEqual(result.Count(), 3);
        }
    }
}
