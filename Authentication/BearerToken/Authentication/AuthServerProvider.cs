using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace BearerToken.Authentication
{
    public class AuthServerProvider:OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //CORS
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin",new[] { "*" });

            if (context.UserName=="test"&&context.Password=="test")
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim("userName",context.UserName));
                identity.AddClaim(new Claim("role","Test"));

                context.Validated(identity);
            }
            else
            {
                context.SetError("Login error","password almost match, keep going..");
            }
          
        }
    }
}