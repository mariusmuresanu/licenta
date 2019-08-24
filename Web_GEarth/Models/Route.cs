using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_GEarth.Models
{
    public enum ActivityType
    {
        Any,
        Hike,
        Bike,
        Fligh,
        Sail
    }

    public class Route
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        [Range(1, 10)]
        public int Type { get; set; }
        [EnumDataType(typeof(ActivityType))]
        public ActivityType ActivityType { get; set; }
        public DateTime DateRecorded { get; set; }
        
    }
}
