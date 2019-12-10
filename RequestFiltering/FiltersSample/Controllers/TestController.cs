using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using FiltersSample.Filters;

namespace FiltersSample.Controllers
{
    [MyException]
    [MyAction]
    [MyAuthorization]
    public class TestController : ApiController
    {
        //public void Get()
        //{
        //    throw new Exception("Test Hatası");
        //}

        private static List<string> denemeList = new List<string>();

        public List<string> Get()
        {
            return denemeList;
        }

        public void Post(string value)
        {
            denemeList.Add(value);
        }

        public string UserName()
        {
            return Thread.CurrentPrincipal.Identity.Name;
        }



    }
}