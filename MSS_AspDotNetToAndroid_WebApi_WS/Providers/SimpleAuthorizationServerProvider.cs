using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using MSS_AspDotNetToAndroid_WebApi_WS.Context;
using MSS_AspDotNetToAndroid_WebApi_WS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

// Tuto :
// http://bitoftech.net/2014/06/01/token-based-authentication-asp-net-web-api-2-owin-asp-net-identity/
// et
// http://www.dotnetawesome.com/2016/09/token-based-authentication-in-webapi.html

namespace MSS_AspDotNetToAndroid_WebApi_WS.Providers
{
    
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        //
        private int organizme_type_merchant = 2;

        /*public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }*/

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            //
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            using (AuthenticationRepository _repo = new AuthenticationRepository())
            {
                IdentityUser user = await _repo.FindUser(context.UserName, context.Password);

                using (var db = new GatewayPCIPINContext())
                {
                    if (db != null)
                    {
                        var users = db.AspNetUsers.ToList();
                        //var roles = db.AspNetRoles.ToList();
                        //var users_roles = db.AspNetUserRoles.ToList();
                        var organizations = db.Organizations.ToList();

                        if (users != null && organizations != null && user!=null)
                        {
                            if (!string.IsNullOrEmpty(users.Where(u => u.UserName == context.UserName && u.PasswordHash == context.Password).FirstOrDefault().UserName) && !string.IsNullOrEmpty(organizations.Where(o => o.OrganizationType.Id == organizme_type_merchant).FirstOrDefault().OrganizationType.Type))
                            {
                                //
                                identity.AddClaim(new Claim("sub", context.UserName));
                                identity.AddClaim(new Claim("role", "user_merchant"));
                                identity.AddClaim(new Claim(ClaimTypes.Role, "user_merchant"));
                                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                                //

                                var props = new AuthenticationProperties(new Dictionary<string, string>
                            {
                                {
                                    "userdisplayname", context.UserName
                                },
                                {
                                     "role", "user_merchant"
                                }
                             });

                                var ticket = new AuthenticationTicket(identity, props);
                                context.Validated(ticket);
                            }
                        }else
                        {                                        
                           context.SetError("invalid_grant", "The user name or password is incorrect.");
                           return;
                            
                        }
                    }
                }

                /*if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }*/
            }

            /*var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user_merchant"));*/

            context.Validated(identity);
        }
    }
}