using System.Collections.Generic;
using System.Web.Http;

namespace ConventionBasedRouting.Controllers
{
    public class ValuesController : ApiController
    {
        private static readonly List<string> Names = new List<string>
        {
            "Dusty",
            "Bruce",
            "Kayle"
        };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return Names;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return Names[id];
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            Names.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            Names[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Names.RemoveAt(id);
        }
    }
}