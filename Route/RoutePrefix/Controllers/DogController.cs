using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RoutePrefix.Models;

namespace RoutePrefix.Controllers
{
    [RoutePrefix("api/kopek")]
    public class DogController : ApiController
    {
        private static readonly List<Dog> Dogs = new List<Dog>
        {
            new Dog {Id = 1, Name = "Dusty"},
            new Dog {Id = 2, Name = "Lassie"}
        };

        [Route("")]
        public IEnumerable<Dog> Get()
        {
            return Dogs;
        }

        [Route("{id}")]
        public Dog Get(int id)
        {
            return Dogs.FirstOrDefault(x => x.Id == id);
        }

        //Prefix gecersiz
        [HttpGet]
        [Route("~/api/test")]
        public string Test()
        {
            return "Tesk Ok";
        }

        [Route("{id}")]
        public void Delete(int id)
        {
            var d = Dogs.FirstOrDefault(x => x.Id == id);
            Dogs.Remove(d);
        }
    }
}