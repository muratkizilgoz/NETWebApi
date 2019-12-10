using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BasicAuthentication.Filters;

namespace BasicAuthentication.Controllers
{
    [MyAuthorization]
    public class TestController : ApiController
    {
        private static List<string> testList = new List<string>()
        {
            "test1",
            "test2"
        };

        public List<string> Get()
        {
            return testList;
        }
    }
}
