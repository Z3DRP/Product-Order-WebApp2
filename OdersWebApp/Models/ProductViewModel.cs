﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdersWebApp.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public string Image { get; set; }
    }
}