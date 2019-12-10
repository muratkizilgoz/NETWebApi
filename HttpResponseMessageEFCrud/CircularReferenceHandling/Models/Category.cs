using System.Collections.Generic;

namespace CircularReferenceHandling.Models
{
    public class Category : Base
    {
        public List<Product> Products { get; set; }
    }
}