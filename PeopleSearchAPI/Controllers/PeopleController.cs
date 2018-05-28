using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleSearchAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace PeopleSearchAPI.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly PeopleContext _dbContext;

        public PeopleController(PeopleContext context)
        {
            _dbContext = context;
            this.SeedData();
        }
        /// <summary>
        /// For testing only - will check if thre are any records and if none seed some data to make it easier to test and get up and running
        /// </summary>
        private void SeedData()
        {
            if (_dbContext.People.Count() == 0)
            {
                var ppl = new List<Person>(){
                   new Person { FirstName = "Kirk", LastName = "Cousins", Interests = "Vikings, Football, Quarterbacking", Address = "1 Viking Way", Age = 29, City = "Minneapolis", ProfileImage = "cousins.jpg", State = "MN", Zip = "55408" },
                   new Person { FirstName = "Delvin", LastName = "Cook", Interests = "Vikings, Football, Runningbacking", Address = "2 Viking Way", Age = 23, City = "Eden Prairie", ProfileImage = "cook.jpg", State = "MN", Zip = "55408" },
                   new Person { FirstName = "Stephon", LastName = "Diggs", Interests = "Vikings, Football, Wide Receiving", Address = "3 Viking Way", Age = 26, City = "Minneapolis", ProfileImage = "diggs.jpg", State = "MN", Zip = "55408" },
                   new Person { FirstName = "Adam", LastName = "Thelen", Interests = "Vikings, Football, Wide Receiving", Address = "4 Viking Way", Age = 28, City = "Detroit Lakes", ProfileImage = "thelen.jpg", State = "MN", Zip = "55408" },
                   new Person { FirstName = "Anthony", LastName = "Barr", Interests = "Vikings, Football, Stuffing People", Address = "5 Viking Way", Age = 26, City = "Uptown", ProfileImage = "barr.jpg", State = "MN", Zip = "55408" },
                   new Person { FirstName = "Craig", LastName = "Johnson", Interests = "Vikings, Football, Not getting injured", Address = "414 2nd St", Age = 26, City = "Hermosa Beach", ProfileImage = "johnson.jpg", State = "CA", Zip = "90292" }
                };
                _dbContext.People.AddRange(ppl);
                _dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Get testing api (only for testing)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// GetAllPeople in database
        /// </summary>
        /// <returns> IEnumerable<Person> </returns>
        [HttpGet]
        public IEnumerable<Person> GetAllPeople()
        {
            var query = from p in _dbContext.People
                        orderby p.LastName
                        select p;

            return query;
        }
        // GET api/SearchByName/{name}
        [HttpGet("SearchByName")]
        [EnableCors("cors-policy")]
        public List<Person> SearchByName(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                var query = from p in _dbContext.People
                            where p.FirstName.Contains(name) || p.LastName.Contains(name)
                            orderby p.LastName
                            select p;
                return query.ToList();
            }
            else
            {
                return _dbContext.People.ToList();
            }
        }

    }
}
