﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_GEarth.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Important { get; set; }
    }
}
