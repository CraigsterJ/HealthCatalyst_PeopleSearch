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
            //TODO - HOOK this up to real call from angular
            // - DOES the database get created? Otherwise how do I set it up?
            // - SET UP MIGRATION TO SEED THE DATA!
            // - UNIT TEST the search and maybe something else just for a sample
            using (var db = new PeopleContext())
            {
                // For testing - see if database will get created
                var query = from p in db.People
                            orderby p.LastName
                            select p;

                return query;
            }
        }
        // GET api/SearchByName/{name}
        [HttpGet("{name}")]
        public List<Person> SearchByName(string name)
        {
            using (var db = new PeopleContext())
            {
                // For testing - see if database will get created
                var query = from p in db.People
                            where p.FirstName.Contains(name) || p.LastName.Contains(name)
                            orderby p.LastName
                            select p;

                return query.ToList();
            }
        }

    }
}
