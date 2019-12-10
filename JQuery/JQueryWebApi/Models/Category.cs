using System.Collections.Generic;

namespace JQueryWebApi.Models
{
    public class Category : Base
    {
        public List<Product> Products { get; set; }
    }
}