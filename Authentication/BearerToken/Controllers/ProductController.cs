using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BearerToken.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        public IEnumerable<string> Get()
        {
            var products = new List<string>()
            {
                "Product 1",
                "Product 2",
                "Product 3"
            };

            return products;
        }
    }
}
