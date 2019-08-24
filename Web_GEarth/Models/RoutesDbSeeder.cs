using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_GEarth.Models
{
    public class RoutesDbSeeder
    {
        public static void Initialize (RoutesDbContext context)
        {
            context.Database.EnsureCreated();
            //Look for any routes.
            if (context.Routes.Any())
            {
                return; // DB has been seeded
            }

            context.Routes.AddRange(
                new Route
                {
                    Title = "Negoiu in august",
                    Location = "Negoiu, Romania",
                    Type = 2
                },
                 new Route
                 {
                     Title = "Moldoveanu toamna",
                     Location = "Moldoveanu, Romania",
                     Type = 2
                 }
            );
            context.SaveChanges();
        }
    }
}
