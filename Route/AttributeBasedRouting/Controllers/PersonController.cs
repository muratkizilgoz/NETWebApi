using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AttributeBasedRouting.Models;

namespace AttributeBasedRouting.Controllers
{
    public class PersonController : ApiController
    {
        private static readonly List<Person> Persons = new List<Person>
        {
            new Person {Id = 1, Name = "Bruce"},
            new Person {Id = 2, Name = "Kayle"}
        };

        public IEnumerable<Person> Get()
        {
            return Persons;
        }

        public Person Get(int id)
        {
            return Persons.FirstOrDefault(x => x.Id == id);
        }

        //[Route("api/person/salary/{id}")]
        [Route("api/person/{id}/salary/")]
        [HttpGet]
        public IEnumerable<string> PersonSalary(int id)
        {
            switch (id)
            {
                case 1:
                    return new List<string> {"1 ₺"};
                case 2:
                    return new List<string> {"2 ₺"};
                default:
                    return null;
            }
        }
    }
}