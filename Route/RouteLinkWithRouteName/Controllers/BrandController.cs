using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RouteLinkWithRouteName.Models;

namespace RouteLinkWithRouteName.Controllers
{
    [RoutePrefix("api/brand")]
    public class BrandController : ApiController
    {
        private static readonly List<Brand> Brands = new List<Brand>
        {
            new Brand {Id = 1, Name = "Msi"},
            new Brand {Id = 2, Name = "Asus"},
            new Brand {Id = 3, Name = "Dell"}
        };

        public IEnumerable<Brand> Get()
        {
            return Brands;
        }

        [Route("{id:int}", Name = "GetById")]
        public Brand Get(int id)
        {
            return Brands.FirstOrDefault(x => x.Id == id);
        }

        [Route("add")]
        public HttpResponseMessage Post(Brand brand)
        {
            brand.Id = Brands.Max(x => x.Id) + 1;
            Brands.Add(brand);

            var response = Request.CreateResponse(HttpStatusCode.Created);
            //response.Headers.Location = new Uri($"{Request.RequestUri}/{brand.Id}");
            response.Headers.Location = new Uri(Url.Link("GetById", new {id = brand.Id}));
            return response;
        }
    }
}