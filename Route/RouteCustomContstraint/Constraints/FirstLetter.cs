using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace RouteCustomContstraint.Constraints
{
    public class FirstLetter : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            var paramVal = values[parameterName].ToString();
            return paramVal.StartsWith("r") || paramVal.StartsWith("b") || paramVal.StartsWith("y");
        }
    }
}