using System;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using FiltersSample.Func;
using FiltersSample.Models;

namespace FiltersSample.Filters
{
    public class MyActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var arg = new StringBuilder();
            foreach (var argument in actionContext.ActionArguments)
            {
                arg.Append($"{argument.Key} = {argument.Value} - ");
            }

            var action = new ActionModel()
            {
                Name = "Before",
                Action = actionContext.ActionDescriptor.ActionName,
                Controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName,
                CreatedDate = DateTime.Now,
                Detail = arg.ToString()
            };

            Logger.LogWrite(action);

            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var action = new ActionModel()
            {
                Name = "After",
                Action = actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                Controller = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                CreatedDate = DateTime.Now,
                Detail = (actionExecutedContext.Response.Content as ObjectContent)?.ObjectType.FullName

            };
            Logger.LogWrite(action);
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}