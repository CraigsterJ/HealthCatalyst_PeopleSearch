using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleSearchAPI.Models;

namespace PeopleSearchAPI.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly PeopleContext _dbContext;

        public PeopleController(PeopleContext context)
        {
            _dbContext = context;
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
        [HttpGet("{name}")]
        public List<Person> SearchByName(string name)
        {
            var query = from p in _dbContext.People
                        where p.FirstName.Contains(name) || p.LastName.Contains(name)
                        orderby p.LastName
                        select p;
            return query.ToList();
        }

    }
}
