using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.Context;
using System.Data.SqlClient;
using System.Web;
using MSS_AspDotNetToAndroid_WebApi_WS.Utils.UserSessionUtils;
using Microsoft.Owin.Testing;
using System.Net.Http;
using System.Net;
using System.Web.Script.Serialization;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        // added by me 
        public static string id_user_signed_in = "";
        public static string userName_user_signed_in = "";
        public static string get_auth_token = "";
        // fin added by me

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }else  // added by me
            {
                //
                id_user_signed_in = user.Id;
                userName_user_signed_in = user.UserName;
                get_auth_token = context.Options.AccessTokenFormat.ToString();
                //       
                /*        added by me             */

            }  // fin added by me

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);

            //bool isAdminMerchant = await userManager.IsInRoleAsync(user.Id, "Admin Merchant"); // Added by me 

            AuthenticationProperties properties = CreateProperties(user.UserName , user.Email); // ', user.Email' => added by me (added first in method 'CreateProperties' elouta)
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);

            /*       added by me            */
       //     var testServer = TestServer.Create<Startup>();
            // Invoke the "token" OWIN service to perform the login (POST /api/token)
            // Use Microsoft.Owin.Testing.TestServer to perform in-memory HTTP POST request
       /*     var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", context.UserName),
                new KeyValuePair<string, string>("password", context.Password)
            };
            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
            var tokenServiceResponse = await testServer.HttpClient.PostAsync(
                Startup.OAuthOptions.TokenEndpointPath.ToString(), requestParamsFormUrlEncoded);

            if (tokenServiceResponse.StatusCode == HttpStatusCode.OK)
            {
                // Sucessful login --> create user session in the database
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                var jsSerializer = new JavaScriptSerializer();
                var responseData =
                    jsSerializer.Deserialize<Dictionary<string, string>>(responseString);
                get_auth_token = responseData["access_token"];
                var login = responseData["username"];
                var userSessionTokenManager = new UserSessionTokenManager();
                userSessionTokenManager.CreateUserSession(login, get_auth_token);

                // Cleanup: delete expired sessions fromthe database
                userSessionTokenManager.DeleteExpiredSessions();
            }*/
            /*  fin added by me */

            // added by me
            /* using (var db = new GatewayPCIPINContext())
             {
                 var users_tbl = db.AspNetUsers.ToList();
                 //var roles = db.AspNetRoles.ToList();
                 //var users_roles = db.AspNetUserRoles.ToList();
                 var organizations_tbl = db.Organizations.ToList();
                 var tokens_tbl = db.Tokens;

                 if (user != null)
                 {
                     if (tokens_tbl.ToList().Count == 0)
                     { 
                         // nheb nrecuperi les coordonnés taa Token w nssobhom fl bd , kifech ?
                         Console.WriteLine("Welcome Sir : "+user.UserName);
                         //string sql_query = "INSERT INTO" + tokens_tbl + "(fk_id_user,access_token,token_type,expires_in) VALUES (" + user.Id + "," + ticket.Properties.GetHashCode().ToString() + "," + ticket.Identity.AuthenticationType.ToString() + "," + null +"";
                         //string sql_query = "INSERT INTO" + tokens_tbl + "(fk_id_user,access_token,token_type,expires_in) VALUES (@idUser,@accesToken,@tokenType,@ExpirationToken)";
                         user.Id
                          * ticket.Properties.GetHashCode().ToString()
                          * ticket.Identity.AuthenticationType.ToString()
                          * null
                          * 
                         db.Database.ExecuteSqlCommand(sql_query,new SqlParameter("@idUser",user.Id.ToString()));
                         db.Database.ExecuteSqlCommand(sql_query, new SqlParameter("@accesToken", ticket.Properties.GetHashCode().ToString()));
                         db.Database.ExecuteSqlCommand(sql_query, new SqlParameter("@tokenType", ticket.Identity.AuthenticationType.ToString()));
                         db.Database.ExecuteSqlCommand(sql_query, new SqlParameter("@ExpirationToken", null));

                     } else
                     { 
                         tokens_tbl.SqlQuery("UPDATE"+tokens_tbl+ "SET fk_id_user = '"+ user.Id + "' , access_token = '"+ ticket.Properties.GetHashCode().ToString() + "' , token_type = '"+ ticket.Identity.AuthenticationType.ToString() + "' , expires_in = '"+ null + "' WHERE id_token = "+new Token().id_token);
                     }
                 }

             } */
            // fin added by me
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            /*  Début : i Added Additional Parameters to be shown after login in Json Response ( in Postman Client ) */

            var db = new GatewayPCIPINContext(); 

            var users_list = db.AspNetUsers.ToList();
            var user_id_Identity = context.Identity.GetUserId();

            var organanization_id = (from u in users_list
                                     where u.Id == user_id_Identity
                                     select u.Organization_Id).Single();

            var isBlocked = (from u in users_list
                             where u.Id == user_id_Identity
                             select u.isBlocked).Single();

            //var organanization_id = db.AspNetUsers.Select(u => u.Organization_Id).Where(u => user_id_Identity ).Single();

            context.AdditionalResponseParameters.Add("userID", context.Identity.GetUserId()); // added by me to be shown in json response
            context.AdditionalResponseParameters.Add("organizationID", organanization_id); // added by me to be shown in json response
            context.AdditionalResponseParameters.Add("isBlocked", isBlocked); // added by me to be shown in json response

            //get_auth_token = context.Options.AccessTokenProvider.ToString();

            /*  Fin : i Added Additional Parameters to be shown after login in Json Response ( in Postman Client )  */

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName , string email ) // ', string email' => added by me
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName },
                { "Email", email} // this ligne is added by me
            };
            // added by me
            /*if (isAdminMerchant)
            {
                data.Add("isAdminMerchant", "true");
            }*/
            // fin added by me
            return new AuthenticationProperties(data);
        }
    }
}