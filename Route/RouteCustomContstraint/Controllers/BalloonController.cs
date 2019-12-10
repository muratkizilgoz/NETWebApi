using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RouteCustomContstraint.Models;

namespace RouteCustomContstraint.Controllers
{
    [RoutePrefix("api/balon")]
    public class BalloonController : ApiController
    {
        private static readonly List<Balloon> Balloons = new List<Balloon>
        {
            new Balloon {Id = 1, Color = "Red"},
            new Balloon {Id = 2, Color = "Blue"},
            new Balloon {Id = 3, Color = "Yellow"}
        };

        [Route("")]
        public IEnumerable<Balloon> Get()
        {
            return Balloons;
        }

        [Route("{id:int}")]
        public Balloon Get(int id)
        {
            return Balloons.FirstOrDefault(x => x.Id == id);
        }

        //Nullable Optional and default value
        [Route("opt/{id:decimal=1}")]
        public Balloon Get(decimal id)
        {
            return Balloons.FirstOrDefault(x => x.Id == id);
        }

        [Route("{color:alpha:firstLetter}")]
        public Balloon Get(string color)
        {
            return Balloons.FirstOrDefault(x => x.Color.ToLower() == color.ToLower());
        }
    }
}