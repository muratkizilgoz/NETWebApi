using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RouteContstraint.Models;

namespace RouteContstraint.Controllers
{
    //Kısıtlama parametre tiplerini belirt.
    [RoutePrefix("api/brand")]
    public class BrandController : ApiController
    {
        private static readonly List<Brand> Brands = new List<Brand>
        {
            new Brand {Id = 1, Name = "Msi"},
            new Brand {Id = 2, Name = "Asus"}
        };

        public IEnumerable<Brand> Get()
        {
            return Brands;
        }

        [Route("{id:int}")]
        public Brand Get(int id)
        {
            return Brands.FirstOrDefault(x => x.Id == id);
        }

        [Route("{name:alpha}")]
        public Brand Get(string name)
        {
            return Brands.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}