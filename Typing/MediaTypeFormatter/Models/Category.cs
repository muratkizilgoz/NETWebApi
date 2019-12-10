using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTypeFormatter.Models
{
    public class Category:Base
    {
        public List<Product> Products { get; set; }
    }
}