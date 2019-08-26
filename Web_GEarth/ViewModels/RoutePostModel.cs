using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_GEarth.Models;

namespace Web_GEarth.ViewModels
{
    public class RoutePostModel
    {
        public string Title { get; set; }
        public string Location { get; set; }
        [Range(1, 10)]
        public int Type { get; set; }
        public string ActivityType { get; set; }
        public DateTime DateRecorded { get; set; }

        public static Route ToRoute(RoutePostModel route)
        {
            ActivityType activityType = Models.ActivityType.Any;
            if (route.ActivityType == "Hike")
            {
                activityType = Models.ActivityType.Hike;
            }
            else if (route.ActivityType == "Bike")
            {
                activityType = Models.ActivityType.Bike;
            }
            else if (route.ActivityType == "Fligh")
            {
                activityType = Models.ActivityType.Fligh;
            }
            else if (route.ActivityType == "Sail")
            {
                activityType = Models.ActivityType.Sail;
            }

            return new Route
            {
                Title = route.Title,
                Location = route.Location,
                Type = route.Type,
                DateRecorded = route.DateRecorded,
                ActivityType = activityType
            };
        }
    }
}


