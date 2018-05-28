using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using PeopleSearchAPI.Models;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace PeopleSearchAPI.Models
{
    public class PeopleContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options)
            : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Person> People { get; set; }
    }
}
