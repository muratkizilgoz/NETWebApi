using System.Collections.Generic;
using System.Web.Http;

namespace ActionBasedRouting.Controllers
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
        [HttpGet]
        public IEnumerable<string> AllNames()
        {
            return Names;
        }

        // GET api/values/5
        [HttpGet]
        public string Name(int id)
        {
            return Names[id];
        }

        // POST api/values
        [HttpPost]
        public void AddName([FromBody] string value)
        {
            Names.Add(value);
        }

        // PUT api/values/5
        [HttpPut]
        public void UpdateName(int id, [FromBody] string value)
        {
            Names[id] = value;
        }

        // DELETE api/values/
        [HttpDelete]
        public void DeleteName(int id)
        {
            Names.RemoveAt(id);
        }
    }
}