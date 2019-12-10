using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BasicAuthentication.Func;

namespace BasicAuthentication.Filters
{
    public class MyAuthorizationAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,"Yetkiniz Yok");
            else
            {
                var tokenKey = actionContext.Request.Headers.Authorization.Parameter;
                var user = Encoding.UTF8.GetString(Convert.FromBase64String(tokenKey));
                // Artık nasıl geliyorsa
                var userInfo = user.Split(':');
                var userName = userInfo[0];
                var password = userInfo[1];

                if (Login.User(userName,password))
                    Thread.CurrentPrincipal= new GenericPrincipal(new GenericIdentity(userName),null );
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,"Şifre neredeyse doğru keep going");
                }
                
            }


        }
    }
}