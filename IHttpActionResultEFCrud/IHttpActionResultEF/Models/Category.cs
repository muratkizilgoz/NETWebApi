using System.Collections.Generic;

namespace IHttpActionResultEF.Models
{
    public class Category : Base
    {
        public List<Product> Products { get; set; }
    }
}