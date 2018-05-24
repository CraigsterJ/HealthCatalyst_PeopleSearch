using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PeopleSearchAPI.Models;

namespace PeopleSearchAPI.Models
{
    public class PeopleInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PeopleContext>
    {
        protected override void Seed(PeopleContext context)
        {
            var people = new List<Person>
            {
            new Person{FirstName="Kirk",LastName="Cousins",Interests="Vikings, Football, Quarterbacking", Address="1 Viking Way", Age=29, City="Minneapolis", ProfileImage="cousins.jpg", State="MN", Zip="55408"},
            new Person{FirstName="Delvin",LastName="Cook",Interests="Vikings, Football, Runningbacking", Address="2 Viking Way", Age=23, City="Eden Prairie", ProfileImage="cook.jpg", State="MN", Zip="55408"},
            new Person{FirstName="Stephon",LastName="Diggs",Interests="Vikings, Football, Wide Receiving", Address="3 Viking Way", Age=26, City="Minneapolis", ProfileImage="diggs.jpg", State="MN", Zip="55408"},
            new Person{FirstName="Adam",LastName="Thelen",Interests="Vikings, Football, Wide Receiving", Address="4 Viking Way", Age=28, City="Detroit Lakes", ProfileImage="thelen.jpg", State="MN", Zip="55408"},
            new Person{FirstName="Anthony",LastName="Barr",Interests="Vikings, Football, Stuffing People", Address="5 Viking Way", Age=26, City="Uptown", ProfileImage="barr.jpg", State="MN", Zip="55408"},
            new Person{FirstName="Craig",LastName="Johnson",Interests="Vikings, Football, Not getting injured", Address="414 2nd St", Age=26, City="Hermosa Beach", ProfileImage="johnson.jpg", State="CA", Zip="90292"}
            };

            people.ForEach(s => context.People.Add(s));
            context.SaveChanges();
        }
    }
}
