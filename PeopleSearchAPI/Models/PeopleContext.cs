using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using PeopleSearchAPI.Models;

namespace PeopleSearchAPI.Models
{
    public class PeopleContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
