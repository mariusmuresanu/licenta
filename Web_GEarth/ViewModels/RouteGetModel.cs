using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_GEarth.Models;

namespace Web_GEarth.ViewModels
{
    public class RouteGetModel
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public int Type { get; set; }
        public int NumberOfComments { get; set; }

        public static RouteGetModel FromRoute(Route route)
        {
            return new RouteGetModel
            {
                Title = route.Title,
                Location = route.Location,
                Type = route.Type,
                NumberOfComments = route.Comments.Count
            };
        }
    }
}
