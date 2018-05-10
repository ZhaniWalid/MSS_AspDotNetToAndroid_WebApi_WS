using Microsoft.AspNet.Identity;
using MSS_AspDotNetToAndroid_WebApi_WS.Context;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Web;
using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;
using System.Configuration;
using MSS_AspDotNetToAndroid_WebApi_WS.Repositories;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Utils.UserSessionUtils
{
    public class UserSessionTokenManager
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbf);

        private UserSessionTokenRepository _userSessionTokenRepos;

        public static string authTokenUser;

        public UserSessionTokenManager()
        {
            _userSessionTokenRepos = new UserSessionTokenRepository();
        }

        private HttpRequestMessage CurrentRequest
        {
            get
            {
                return (HttpRequestMessage)HttpContext.Current.Items["MS_HttpRequestMessage"];
            }
        }

        /// <returns>The current bearer authorization token from the HTTP headers</returns>
        private string GetCurrentBearerAuthrorizationToken()
        {
            string authToken = null;
            /*string accessToken = User.Claims.FirstOrDefault(c => c.Type == "access_token")?.Value;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl + "/inspections/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);*/

            if (CurrentRequest.Headers.Authorization != null)
            {
                if (CurrentRequest.Headers.Authorization.Scheme == "bearer")
                {
                    authToken = CurrentRequest.Headers.Authorization.Parameter;
                }
            }
            return authToken;
        }

        /*private string GetAccesToken()
        {
            string accessToken = User.Claims.FirstOrDefault(c => c."access_token");

            if (accessToken == "")
                return View("Error");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage responseMessage = await client.GetAsync(inspectionsUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                List<Inspection> inspections = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Inspection>>(responseData);
                return View(inspections);
            }
            return View("Error");
        }
        */
        private string GetCurrentUserId()
        {
            string userId;

            if (HttpContext.Current.User == null)
            {
                return null;
            }
            else
            {
                //userId = HttpContext.Current.GetOwinContext().Authentication.User.Identity.GetUserId();
                userId = HttpContext.Current.User.Identity.GetUserId();
            }
            return userId;
        }


        /*  public string UserId()
          {
              // The user's ID is available in the NameIdentifier claim
              var user = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
              string userId = user.GetClaims(HttpContext.Current.User.Identity.GetUserId()).FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

              return userId;

          }*/

        /* public string UserInformationToken()
         {
             // Retrieve the access_token claim which we saved in the OnTokenValidated event
             var user = GetCurrentUserId();
             string accessToken = user.GetClaims(HttpContext.Current.User.Identity.GetUserId()).FirstOrDefault(c => c.Type == "access_token").Value;
             //string accessToken = User.Claims.FirstOrDefault(c => c.Type == "access_token").Value;

             // If we have an access_token, then retrieve the user's information
               if (!string.IsNullOrEmpty(accessToken))
                {
                    var apiClient = new AuthenticationApiClient(_configuration["auth0:domain"]);
                    var userInfo = await apiClient.GetUserInfoAsync(accessToken);

                    return userInfo;
                }

             return accessToken;
         } */

        /*  public object Claims()
          {
              var user = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

              return user.GetClaims(HttpContext.Current.User.Identity.GetUserId()).Select(c => new
              {
                  Type = c.Type,
                  Value = c.Value
              });
          } */

        /// <summary>
        /// Extends the validity period of the current user's session in the database.
        /// This will configure the user's bearer authorization token to expire after
        /// certain period of time (e.g. 30 minutes, see UserSessionTokenTimeout in Web.config)
        /// </summary>
        public void CreateUserSession(string userName, string authToken)
        {
            /* var db = new GatewayPCIPINContext();

             var users = db.AspNetUsers.ToList();
             var usersSessionsTokens = db.UserSessionTokens.ToList();

             var users2 = uow.getRepository<AspNetUser>().GetAll().ToList();
             var usersSessionsTokens2 = uow.getRepository<UserSessionToken>().GetAll().ToList();

             var userId = users2.First(u => u.Login == username).Id;*/
            var userId = _userSessionTokenRepos.getAspNetUserIdByUserName(userName);
            var userSessionToken = new UserSessionToken()
            {
                OwnerAspNetUser_fk_Id = userId,
                AuthToken = authToken,
                is_LoggedIn_LoggedOut = 1 // 1 => Is Logged In <-> 0 => Is Logged Out 
            };
            userSessionToken.LoginDateTime = DateTime.Now;
            userSessionToken.ExpirationDateTime = DateTime.Now + TimeSpan.FromMinutes(30);

            _userSessionTokenRepos.AddUserSessionToken(userSessionToken);

            //var userId = this.Data.Users.All().First(u => u.UserName == username).Id;
            /*      var userId = users.First(u => u.Login == username).Id;
                  var userSessionToken = new UserSessionToken()
                  {
                      OwnerAspNetUser_fk_Id = userId,
                      AuthToken = authToken,
                      is_LoggedIn_LoggedOut = 1 // 1 => Is Logged In <-> 0 => Is Logged Out 
                  };*/
            // usersSessionsTokens.Add(userSessionToken);

            // Extend the lifetime of the current user's session: current moment + fixed timeout
            //userSessionToken.ExpirationDateTime = DateTime.Now + new DateTime (System.Configuration.ConfigurationManager.GetSection("MSS.MSSolutions.Properties.Settings.UserSessionTokenTimeout").ToString());  
            //Balise MSS.MSSolutions.Properties.Settings.UserSessionTokenTimeout : added by me in web.config' => give 30 minutes de plus;

            //uow.getRepository<UserSessionToken>().Add(userSessionToken);
            //db.SaveChanges();
        }

        /// <summary>
        /// Makes the current user session invalid (deletes the session token from the user sessions).
        /// The goal is to revoke any further access with the same authorization bearer token.
        /// Typically this method is called at "logout".
        /// </summary>
        public void InvalidateUserSession()
        {
            /* var db = new GatewayPCIPINContext();
             var usersSessionsTokens = db.UserSessionTokens.ToList();*/

            //var authToken = UserInformationToken();
            var currentUserId = GetCurrentUserId();
            //var id = CurrentRequest.GetOwinContext().Authentication.User.Identity.GetUserId();

            //authTokenUser = authToken;

            var userSessionToken = _userSessionTokenRepos.getUserSessionTokenByCurrentIdAndAuhtToken(currentUserId);
            var userSessionToken_last = _userSessionTokenRepos.getRecentUserSessionToken(userSessionToken);
            if (userSessionToken_last != null)
            {
                //userSessionToken.is_LoggedIn_LoggedOut = 0; // 1 => Is Logged In <-> 0 => Is Logged Out 
                _userSessionTokenRepos.DeleteUserSessionToken(userSessionToken_last);
                /*usersSessionsTokens.Remove(userSessionToken);
                uow.getRepository<UserSessionToken>().Delete(userSessionToken);
                uow.Commit();        
                db.SaveChanges();*/
            }
        }

        /// <summary>
        /// Re-validates the user session. Usually called at each authorization request.
        /// If the session is not expired, extends it lifetime and returns true.
        /// If the session is expired or does not exist, return false.
        /// certain period of time (e.g. 30 minutes, see UserSessionTokenTimeout in Web.config)
        /// </summary>
        /// <returns>true if the session is valid</returns>
        public bool ReValidateSession()
        {
            /* var db = new GatewayPCIPINContext();
             var usersSessionsTokens = db.UserSessionTokens.ToList();*/

            //string authToken = this.GetCurrentBearerAuthrorizationToken();
            var currentUserId = GetCurrentUserId();

            var userSessionToken = _userSessionTokenRepos.getUserSessionTokenByCurrentIdAndAuhtToken(currentUserId);
            var userSessionToken_last = _userSessionTokenRepos.getRecentUserSessionToken(userSessionToken);
            if (userSessionToken_last == null)
            {
                // User does not have a session with this token --> invalid session
                return false;
            }
            else if (userSessionToken_last.ExpirationDateTime < DateTime.Now)
            {
                // User's session is expired --> invalid session
                return false;
            }
            else
            {

                // Extend the lifetime of the current user's session: current moment + fixed timeout
                //userSessionToken.ExpirationDateTime = DateTime.Now + new DateTime (System.Configuration.ConfigurationManager.GetSection("MSS.MSSolutions.Properties.Settings.UserSessionTokenTimeout").ToString());  
                //Balise MSS.MSSolutions.Properties.Settings.UserSessionTokenTimeout : added by me in web.config ' => give 30 minutes de plus;
                 userSessionToken_last.ExpirationDateTime = DateTime.Now + TimeSpan.FromMinutes(30);
                _userSessionTokenRepos.UpdateUserSessionToken(userSessionToken_last);
                //db.SaveChanges();

                return true;
            }
        }

        public void DeleteExpiredSessions()
        {
            /* var db = new GatewayPCIPINContext();            
             var usersSessionsTokens = db.UserSessionTokens.ToList(); */

            var List_userSessionTokens_Expired = _userSessionTokenRepos.getExpiredUserSessionTokenList();

            if (List_userSessionTokens_Expired.Count != 0)
            {
                /* throw new Exception("No Expired Users Sessions Exist in DataBase");
             }else
             {*/
                foreach (UserSessionToken ust in List_userSessionTokens_Expired)
                {
                    _userSessionTokenRepos.DeleteExpiredUserSessionToken(ust);
                }
            }
        }

        public bool verify_Expired_User_Sessions()
        {
            var List_userSessionTokens_Expired = _userSessionTokenRepos.getExpiredUserSessionTokenList();

            if (List_userSessionTokens_Expired.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool verify_Actual_LoggedIn_Sessions()
        {
            var List_LoggedInSessions = _userSessionTokenRepos.getLoggedInUserSessionTokenList();

            if (List_LoggedInSessions.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
