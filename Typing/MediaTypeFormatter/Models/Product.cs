﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTypeFormatter.Models
{
    public class Product:Base
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}