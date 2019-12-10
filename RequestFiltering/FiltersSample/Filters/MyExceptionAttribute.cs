using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using FiltersSample.Func;
using FiltersSample.Models;

namespace FiltersSample.Filters
{
    public class MyExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var ex = new ExceptionModel
            {
                Name = actionExecutedContext.Exception.Message,
                Detail = actionExecutedContext.Exception.StackTrace,
                Action = actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                Controller = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName
            };

            //1. Log
            Logger.LogWrite(ex);
            //2. Response
            actionExecutedContext.Response =
                actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, ex);
        }
    }
}