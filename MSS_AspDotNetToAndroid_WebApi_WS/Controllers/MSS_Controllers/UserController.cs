using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using Microsoft.Owin.Security;
using MSS_AspDotNetToAndroid_WebApi_WS.Repositories;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.Context;
using Microsoft.Owin.Testing;
using MSS_AspDotNetToAndroid_WebApi_WS.Utils.UserSessionUtils;
using System.Web.Script.Serialization;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.Owin;
using MSS_AspDotNetToAndroid_WebApi_WS.Utils.AspNetUsersUtils;
using MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.BindingModels;
using MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.PatchRequestsModels_ForUpdate;
using MSS_AspDotNetToAndroid_WebApi_WS.Utils.TransactionsUtils;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Controllers.MSS_Controllers
{
    [UserSessionTokenAuthorize]
    [System.Web.Http.RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private AuthenticationRepository _repo = null;
        private ApplicationUserManager _userManager;

        public static string id_userLoggedIn_static = "", authToken_userLoggedIn_static = "", userName_userLoggedIn_static = "";
        //public static int organization_id_static_toReturn = 0;

        public UserController()
        {
            _repo = new AuthenticationRepository();
        }

        public UserController(ApplicationUserManager userManager,
           ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // POST api/Account/Register
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("User_Register")]
        public async Task<IHttpActionResult> Register(AspNetUser userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }
         
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        [System.Web.Http.Authorize(Roles = "user_merchant")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("authorize")]
        [System.Web.Http.AllowAnonymous]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        //.Where(c => c.Type == ClaimTypes.Role.Where(x=>x.Equals("user_merchant")).ToString())
                        .Select(c => c.Value);
            return Ok("Hello Mr : " + identity.Name + " , Your Role is : " + string.Join(",", roles.ToList()));
        }

        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("shownow")]
        public IHttpActionResult Get()
        {
            return Ok("Now server time is: " + DateTime.Now.ToString());
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Authorize]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("userslist", Name = "GetEmployees")]
        public List<string> GetEmployees()
        {
            using (var db = new GatewayPCIPINContext())
            {
                var users_list = db.AspNetUsers.Select(u => u.Login).ToList();
                for (int i = 0; i < users_list.Count; i++)
                {
                    users_list[i] = "Login : " + users_list[i];
                }
                return users_list;
            }
        }

        ///

        // POST api/user/Login
        /*     [System.Web.Http.HttpPost]
             [System.Web.Http.AllowAnonymous]
             [System.Web.Http.Route("Login")]
             public async Task<IHttpActionResult> LoginUser(AspNetUser model)
             {
                 if (model == null)
                 {
                     return this.BadRequest("Invalid user data");
                 }

                 // Invoke the "token" OWIN service to perform the login (POST /api/token)
                 //var testServer = TestServer.Create<Startup>();
                 HttpClient client = new HttpClient();
                 var requestParams = new List<KeyValuePair<string, string>>
         {
             new KeyValuePair<string, string>("grant_type", "password"),
             new KeyValuePair<string, string>("username", model.UserName),
             new KeyValuePair<string, string>("password", model.PasswordHash)
         };
                 var request = HttpContext.Current.Request;
                 var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                 var tokenServiceUrl = request.Url.GetLeftPart(UriPartial.Authority) + request.ApplicationPath + "/api/Token";
                 var tokenServiceResponse = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);

                 //var tokenServiceResponse = await client.PostAsync(
                  //  "/api/Token", requestParamsFormUrlEncoded);

                 // var tokenServiceResponse = await testServer.HttpClient.PostAsync(
                  //    "/api/Token", requestParamsFormUrlEncoded);

                 return this.ResponseMessage(tokenServiceResponse);
             } */


        // Partie 'Login et Logout' avec UserSessionTokens Saved on Data Base

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager Authentication
        {
            get
            {
                //return Request.GetOwinContext().Authentication;
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        /* debut : Method Login Added by me , works exactly like /Token , but i used it to get value of 'token' and store it in db*/
        // POST api/User/Login 
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("Login")]
        public async Task<IHttpActionResult> LoginUser(LoginUserBindingModel model)
        {
            string res = "";

            if (model == null)
            {
                return BadRequest("Invalid user data");
            }

            // Invoke the "token" OWIN service to perform the login (POST /api/token)
            // Use Microsoft.Owin.Testing.TestServer to perform in-memory HTTP POST request
            var testServer = TestServer.Create<Startup>();
            //var requestParams = new List<KeyValuePair<string, string>>
            var requestParams = new Dictionary<string, string>()
            {
                { "grant_type", "password" },
                { "username", model.Username },
                { "password", model.Password }

               /* new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", model.Username),
                new KeyValuePair<string, string>("password", model.Password)*/
            };

            //var requestString = new Dictionary<string, string>();
            //requestString.(requestParams);

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
            var tokenServiceResponse = await testServer.HttpClient.PostAsync(
                "/Token", requestParamsFormUrlEncoded);

            //jsSerializer.Serialize<Dictionary<string, string>>(requestParams);

            if (tokenServiceResponse.StatusCode == HttpStatusCode.OK)
            {
                // Sucessful login --> create user session in the database
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                var jsSerializer = new JavaScriptSerializer();
                var responseData =
                    jsSerializer.Deserialize<Dictionary<string, string>>(responseString);
                var userSessionTokenManager = new UserSessionTokenManager();

                // this boucle if use to hande the Exception : "Exception Details: System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary."
                if (responseData.ContainsKey("access_token") && responseData.ContainsKey("userName") && responseData.ContainsKey("userID") && responseData.ContainsKey("organizationID") ) // && responseData.ContainsKey("organizationID") 
                {
                    // do Add UserSession
                    var authToken = responseData["access_token"];
                    var userName = responseData["userName"];
                    var userID = responseData["userID"];
                    var organizationID = responseData["organizationID"]; // = 1 : Users Bank , = 42 : Users Marchants & Admin Marchant
                    // Début : partie du plus pour récpurer les valeurs en variables statiques
                    id_userLoggedIn_static = userID;  // id pour l'utiliser aprés la login
                    userName_userLoggedIn_static = userName;
                    authToken_userLoggedIn_static = authToken;
                    // Fin : partie du plus pour récpurer les valeurs en variables statiques            

                    /* Enlever le commentaire pour utiliser 'CreateUserSession' sans faire  le filtre
                     selon 'OrganizationID ' comme dans le ' if () else () ' si dessous*/

                    // userSessionTokenManager.CreateUserSession(userName, authToken); 

                    /* j'ai fais sa pour que seulement les Users qui ont ' OrganizationID = 42 ' 
                     et qui ont des 'Merchants' peuvent se connecter 
                     et enregistrer leur sessions dans la table 'UserSessionToken' */
                    if (organizationID.Equals("42"))
                    {
                        userSessionTokenManager.CreateUserSession(userName, authToken);
                    }else
                    {
                        //return Ok("Only 'Merchants' Can Access Here and Sign In");
                    }
                    /* et si  les Users qui ont ' OrganizationID = 1 ' 
                     et qui sont des 'Banquiers' ne peuvent pas se connecter
                     et enregistrer leur sessions dans la table 'UserSessionToken' */

                    /* if (userName.Equals("AdminMonoprix"))
                     {
                         //Redirect("api/User/ProfileAdminMonoprix");
                         return RedirectToAction("api/User/ProfileAdminMonoprix");
                     }else
                     {
                         Redirect("api/User/Profile");
                     }*/
                    ///
                    //var p = UserProfile.GetProfile();
                    // p.LastVisit = DateTime.Now;
                    /// 
                }

                if (userSessionTokenManager.verify_Expired_User_Sessions() == true)
                {
                    // Cleanup: delete expired sessions fromthe database
                    userSessionTokenManager.DeleteExpiredSessions();
                }
                else
                {
                    res = "User Authenticated Successfuly , No Expired User Sessions into data base to delete";
                    Console.WriteLine(res);
                }
            }

            return ResponseMessage(tokenServiceResponse);
        }

        /* fin : Method Login Added by me , works exactly like /Token , but i used it to get value of 'token' and store it in db*/

        /*  Début Méthode Logout qui efface la session du table UserSessionToken   */
        // POST api/User/Logout
        [System.Web.Http.HttpPost]
        [UserSessionTokenAuthorize]
        [System.Web.Http.Authorize]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("Logout")]
        public IHttpActionResult Logout()
        {
            // This does not actually perform logout! The OWIN OAuth implementation
            // does not support "revoke OAuth token" (logout) by design.
            //var x = CookieAuthenticationDefaults.LogoutPath;

            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);

            //this.Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //this.Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            // Delete the user's session from the database (revoke its bearer token)
            var userSessionTokenManager = new UserSessionTokenManager();

            if (userSessionTokenManager.verify_Actual_LoggedIn_Sessions())
            {
                userSessionTokenManager.InvalidateUserSession();

                var msgSucessLogout = "Logout successful. => Good By Mr : ";
                return Ok(
                         msgSucessLogout + userName_userLoggedIn_static
                //+
                //"User [ ID :" + id_userLoggedIn_static + " | userName : " + userName_userLoggedIn_static + " | has -> auth_token : " + authToken_userLoggedIn_static + " ] ==> Has Been Logged Out Successfully"
                );
            }
            else
            {
                var msgFailedLogout = "Sorry , Logout Failed , You are not even Connected,Please Login Before Logging Out";
                return Ok(msgFailedLogout);
            }

        }
        /*  Fin Méthode Logout qui efface la session du table UserSessionToken  */

        private HttpRequestMessage CurrentRequest
        {
            get
            {
                return (HttpRequestMessage)HttpContext.Current.Items["MS_HttpRequestMessage"];
            }
        }

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

        /* Début Méthode qui Récupére les informations de l'utilisateur*/

        // GET api/User/Profile
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Profile")]
        [UserSessionTokenAuthorize]  // added by me
        [System.Web.Http.Authorize]  // added by me
        [System.Web.Http.AllowAnonymous] // added by me
        public IHttpActionResult GetUserProfile()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate the current user exists in the database
            var aspNetUserManager = new AspNetUserManager();
            //var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            //var currentUserId = GetCurrentUserId();
            //var c = Authentication.User.Identity.GetUserId();
            //var currentUser = _userManager.FindById(currentUserId);
            //var currentUser = this.Data.Users.All().FirstOrDefault(x => x.Id == currentUserId);
            //var currentUserId = User.Identity.GetUserId();
            var currentUser = aspNetUserManager.GetCurrentUserById(id_userLoggedIn_static);
            //var currentUser = await _userManager.FindByIdAsync(id_userLoggedIn_static);

            var userToReturn = new AspNetUser();

            if (currentUser == null)
            {
                var msg = string.Format("User #" + id_userLoggedIn_static + " not found ");
                //var msg2 = "Only 'Marchants' can access here , please try again";
                //var msg3 = string.Format("User #" + id_userLoggedIn_static + " Only 'Marchants' can access here , please try again ");
                
                //return Ok("Invalid user token! Please login again! not found!  => " + msg);
                return BadRequest("Invalid user token! Please login again! not found!  => " + msg);
            }
            else
            {
                /*var u = new ApplicationUser
                {
                    UserName = currentUser.UserName,
                    Email = currentUser.Email                  
                };*/
                userToReturn = new AspNetUser
                {
                    Id = currentUser.Id,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    Email = currentUser.Email,
                    Login = currentUser.Login,
                    UserName = currentUser.UserName,
                    PasswordHash = currentUser.PasswordHash,
                    PhoneNumber = currentUser.PhoneNumber,
                    Organization_Id = currentUser.Organization_Id
                };

                /* var detailsUserToReturn = new List<string>();
                 detailsUserToReturn.Add(userToReturn.Id);
                 detailsUserToReturn.Add(userToReturn.UserName);
                 detailsUserToReturn.Add(userToReturn.Email); */

                //var welcome = "Welcome To MSS  Mr : ";

                var id_toReturn = userToReturn.Id;
                var userName_toReturn = userToReturn.UserName;
                var email_toReturn = userToReturn.Email;
                var firstName_toReturn = userToReturn.FirstName;
                var lastName_toReturn = userToReturn.LastName;
                var password_toReturn = userToReturn.PasswordHash;
                var phoneNumber_toReturn = userToReturn.PhoneNumber;
                var organization_id_toReturn = (int) userToReturn.Organization_Id;

                /* detailsUserToReturn[0] = "Welcome To MSS : "+ userToReturn.UserName;
                 detailsUserToReturn[1] = userToReturn.Email; */

                return Ok(new string[] { id_toReturn, userName_toReturn, email_toReturn, firstName_toReturn, lastName_toReturn, password_toReturn, phoneNumber_toReturn, organization_id_toReturn.ToString() });
            }

            /* var userToReturn = new AspNetUser
             {
                 FirstName = currentUser.FirstName,
                 LastName = currentUser.LastName,
                 Email = currentUser.Email,
                 Login = currentUser.Login,
                 UserName = currentUser.UserName,
                 PasswordHash = currentUser.PasswordHash
             }; */

            /* var userSessionTokenManager = new UserSessionTokenManager();
              switch (userSessionTokenManager.ReValidateSession())
              {
                  case

              } */

        }

        /* Fin Méthode qui Récupére les informations de l'utilisateur*/

      // GET api/User/GetUsersMerchants
      [System.Web.Http.HttpGet]
      [System.Web.Http.Route("GetUsersMerchants")]
      [UserSessionTokenAuthorize]  // added by me
      [System.Web.Http.Authorize]  // added by me
      [System.Web.Http.AllowAnonymous] // added by me
      public IHttpActionResult GetUsersMerchants()
      {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate the current user exists in the database
            var aspNetUserManager = new AspNetUserManager();
            var currentUser = aspNetUserManager.GetCurrentUserById(id_userLoggedIn_static);
            //var userToReturn = new AspNetUser();

            if (currentUser == null)
            {
                var msg = string.Format("User #" + id_userLoggedIn_static + " not found ");
                //var msg2 = "Only 'Marchants' can access here , please try again";
                //var msg3 = string.Format("User #" + id_userLoggedIn_static + " Only 'Marchants' can access here , please try again ");

                //return Ok("Invalid user token! Please login again! not found!  => " + msg);
                return BadRequest("Invalid user token! Please login again! not found!  => " + msg);
            } else {

                var list_UsersMerchantsToReturn = aspNetUserManager.GetAspNetMerchantsUsersByAdminMerchant(currentUser);

                if (list_UsersMerchantsToReturn.Count != 0 && list_UsersMerchantsToReturn != null && currentUser != null)
                {
                    return Ok(list_UsersMerchantsToReturn);
                }           
                else
                {
                    var msgFailed = "Only ' Admin Merchant ' can see list of Users Merchants ";
                    //return Ok(msgFailed);
                    return BadRequest(msgFailed);
                }                              
            }
        }

        // PATCH api/User/ChangePassword
        [System.Web.Http.HttpPatch]
        [UserSessionTokenAuthorize]  // added by me
        [System.Web.Http.Authorize]  // added by me
        [System.Web.Http.AllowAnonymous] // added by me
        [System.Web.Http.Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            //string emailToReceiveChanges = ""; //, email = "" , userID = ""
            //var user = await _userManager.FindByIdAsync(id_userLoggedIn_static);
            // Validate the current user exists in the database
            var aspNetUserManager = new AspNetUserManager();
            var currentUser = aspNetUserManager.GetCurrentUserById(id_userLoggedIn_static);

            if (!ModelState.IsValid && currentUser == null)
            {
                var msgError = "User" + currentUser.UserName + " Not Found";
                return BadRequest(ModelState + msgError);
            }
            
                var testServer = TestServer.Create<Startup>();
                //var requestParams = new List<KeyValuePair<string, string>>
                var requestParams = new Dictionary<string, string>()
              {
                 //{ "email", model.Email},
                 { "oldpassword",model.OldPassword},
                 { "newpassword", model.NewPassword },
                 { "confirmnewpassword", model.ConfirmPassword}
              };

                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                var tokenServiceResponse = await testServer.HttpClient.PostAsync(
                    "", requestParamsFormUrlEncoded);

                //jsSerializer.Serialize<Dictionary<string, string>>(requestParams);

                if (tokenServiceResponse.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                    var jsSerializer = new JavaScriptSerializer();
                    var responseData =
                        jsSerializer.Deserialize<Dictionary<string, string>>(responseString);

                    // this boucle if use to hande the Exception : "Exception Details: System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary."
                    if (/*responseData.ContainsKey("userID") && responseData.ContainsKey("access_token") &&*/ responseData.ContainsKey("oldpassword") && responseData.ContainsKey("newpassword") && responseData.ContainsKey("confirmnewpassword") /*&& responseData.ContainsKey("email" )*/ )
                     {
                        //userID = responseData["userID"];
                        //authToken = responseData["access_token"];
                        //model.Email = responseData["email"];
                        model.OldPassword = responseData["oldpassword"];
                       if (responseData.ContainsKey("newpassword").Equals(responseData.ContainsKey("confirmnewpassword")))
                       {
                        model.NewPassword = responseData["newpassword"];
                       }else
                       {
                        return BadRequest("The Password did not match,please try again");  
                       }                                    
                    }
                }

            IdentityResult result = await UserManager.ChangePasswordAsync(currentUser.Id, model.OldPassword,
                model.NewPassword);

              if (!result.Succeeded)
              {
                //var msgFailedResult = "Updating Password Failed ,because the email : "+ currentUser.Email + " is already used ! we can't complete process of changing password and sending you changes ! Please Try Again With another Email ! "; // last value used here : currentUser.Email
                // i am using this msg and not other msgs : to use it in switch statement in Android
                //msgResult = "False => Update_Password_Failed";
                //return Ok (GetErrorResult(result));

                //return GetErrorResult(result);
                var msgFailedResult = "False => Update_Password_Failed"; 
                return Ok(msgFailedResult);

                // uncomment : return GetErrorResult(result); will give error like this au cas d'erreur :
                /* 
                 {
                   "message": "The request is invalid.",
                     "modelState": {
                       "model.Email": [
                    "Le champ Email est requis." 

                  (  => lorsque en ' ChangePasswordBindingModel ' champs 'Email' 
                    a l'annotation '[Required]' si non pas prblm içi )

                       ],
                       "model.ConfirmPassword": [
                    "The new password and confirmation password do not match." 
                  ],
              "": [
            "Passwords must have at least one non letter or digit character. Passwords must have at least one uppercase ('A'-'Z')."
              
              ( => ce message à mettre dans la partie Android pour éviter de tomber dans le meme piége dans le future ,
                   w m naarfch l erreur ken mnaawd ndécommenti : ' return GetErrorResult(result); '  )
              ]
                    }
                }
                 */
                 // Fin uncomment

            } else
              {             
                  // Début : Sent Email after Chainging Password Successfuly
                  var subject= "   Password Changed Succefssuly";
                  var body   = " <p style='color:black;'><b>  Hi Mr : " + currentUser.FirstName + " " + currentUser.LastName
                             + " , Your Password Has Been Changed Successfuly as followings : </b></p> </br>"
                             + "<p style='color:black;'><b>    Your Email : " + currentUser.Email + "</b></p> </br>" // last value used here : currentUser.Email
                             + "<p style='color:black;'><b> , Your User Name : " + currentUser.UserName + "</b></p> </br>"
                             + "<p style='color:black;'><b> , Your Old Password : " + model.OldPassword + "</b></p> </br>"
                             + "<p style='color:black;'><b> , Your New Password : <mark>" + model.NewPassword + "</mark></b></p> </br>"
                             + "<p style='color:black;'><b> , Date of Changing Password is : <mark>" + DateTime.Now + "</mark></b></p> </br>"
                             + "<p style='color:black;'><b> , Please Save it in secure place to not forget it" + "</b></p> </br> </br>"
                             + "<p style='color:black;'><b> , Thanks" + "</b></p> </br>"
                             + "<p style='color:black;'><b> , Best Reagards" + "</b></p> </br> </br>"
                             + "<h2 style='text-align:center;color:black;'>   MS Solutions 2018 , All Rights Reserved." + "</h2>" ;

                  aspNetUserManager.sendEmailAfterPasswordChanged(currentUser.Email, subject,body);  // last value used here : currentUser.Email

                  //UserManager.SendEmail(currentUser.Id,subject,body);
                  // Fin : Sent Email after Chainging Password Successfuly

                  // var msgCongratulations = "Congratulations => ";
                  // var msgUserName = " User : " + currentUser.UserName + " => ";
                  // var msgEmailSendSuccess = " Please Check Your Email for Changes You Have Made => ";
                  // var msgRedirectLoginScreen = "You Will be Redirecting to Login Screen Now.";
                  // return Ok(msgCongratulations + msgUserName + msgEmailSendSuccess + msgRedirectLoginScreen);

                  var msgSucessResult = "True => Update_Password_Succeed"; // i am using this msg and not other msgs : to use it in if statement in Android
                  return Ok(msgSucessResult);
            }
           
        }


        // this Action Work Perfectly for the Partial Update
        // PATCH api/User/PatchProfileUser
        [System.Web.Http.HttpPatch]  // added by me
        [UserSessionTokenAuthorize]  // added by me
        [System.Web.Http.Authorize]  // added by me
        [System.Web.Http.AllowAnonymous] // added by me
        [System.Web.Http.Route("PatchProfileUser")]
        public IHttpActionResult PatchProfileUser([FromBody] AspNetUserPatchRequest request)
        {
            var aspNetUserManager = new AspNetUserManager();

            //if (request.Id.Equals(id_userLoggedIn_static)){

            var currentUser = aspNetUserManager.GetCurrentUserById(id_userLoggedIn_static);

            if (currentUser == null)
            {
                //var msg = "User Not Found";
                //return NotFound();
                var msgFailed = "Update Failed";
                return Ok(msgFailed);
            }
            else
            {
                currentUser.UserName = request.UserName;
                currentUser.Email = request.Email;
                currentUser.FirstName = request.FirstName;
                currentUser.LastName = request.LastName;
                currentUser.PhoneNumber = request.PhoneNumber;

                aspNetUserManager.UpdateAspNetUser(currentUser);

                var msgSucess = "Update Succeeded";
                return Ok(msgSucess);
            }
        }


        // GET api/User/GetFiltrableTransactions
        [System.Web.Http.HttpGet]  // added by me
        [UserSessionTokenAuthorize]  // added by me
        [System.Web.Http.Authorize]  // added by me
        [System.Web.Http.AllowAnonymous] // added by me
        [System.Web.Http.Route("GetFiltrableTransactions")]
        public IHttpActionResult GetFiltrableTransactions()
        {
            var _transactionsManager = new TransactionsManager();
            var _aspNetUserManager = new AspNetUserManager();

            var currentUser = _aspNetUserManager.GetCurrentUserById(id_userLoggedIn_static);
            var list_GeneralTransactions = _transactionsManager.getGeneralTransactionsData();

            if (list_GeneralTransactions.Count !=0 && list_GeneralTransactions != null && currentUser!= null)
            {             
                return Ok(list_GeneralTransactions);
            }else
            {
                return BadRequest();
            } 
        }

        /*
         
        // GET api/User/GetExtendedFiltrableTransactions
        [System.Web.Http.HttpGet]  // added by me
        [UserSessionTokenAuthorize]  // added by me
        [System.Web.Http.Authorize]  // added by me
        [System.Web.Http.AllowAnonymous] // added by me
        [System.Web.Http.Route("GetExtendedFiltrableTransactions")]
        public IHttpActionResult GetExtendedFiltrableTransactions()
        {
            var _transactionsManager = new TransactionsManager();
            var _aspNetUserManager = new AspNetUserManager();

            var currentUser = _aspNetUserManager.GetCurrentUserById(id_userLoggedIn_static);
            var list_ExtendedTransactions = _transactionsManager.getExtendedTransactionsData();

            if (list_ExtendedTransactions.Count != 0 && list_ExtendedTransactions != null && currentUser != null)
            {
                return Ok(list_ExtendedTransactions);
            }else
            {
                return BadRequest();
            }
        }

        */


        /*  Début : Actions who did not work   */


        // this Action did not worked for the Partial Update , but nst7fdh 3léha la3ala nst79lha
        // POST api/User/UpdateProfileUser
        [System.Web.Http.HttpPatch]
        [UserSessionTokenAuthorize]  // added by me
        [System.Web.Http.Authorize]  // added by me
        [System.Web.Http.AllowAnonymous] // added by me
        [System.Web.Http.Route("UpdateProfileUser")]
        public async Task<IHttpActionResult> UpdateProfileUser(ProfileUserBindingModel model)
        {
            string authToken = "", userID = "" , userName = "", email = "", firstName = "", lastName = "", phoneNumber = ""; //userName = "", email = "", firstName = "", lastName = "", phoneNumber = ""
            var userToUpdate = new AspNetUser();
            //id = id_userLoggedIn_static;
            // Validate the current user exists in the database
            var aspNetUserManager = new AspNetUserManager();
            var currentUser = aspNetUserManager.GetCurrentUserById(id_userLoggedIn_static);

            if (!ModelState.IsValid && currentUser == null)
            {
                var msgError = "User" + currentUser.UserName + " Not Found";
                return BadRequest(ModelState + msgError);
            }

                var testServer = TestServer.Create<Startup>();
                //var requestParams = new List<KeyValuePair<string, string>>
                var requestParams = new Dictionary<string, string>()
               {
                 { "userName", model.Username},
                 { "email",model.Email},
                 { "firstName", model.FirstName},
                 { "lastName", model.LastName},
                 { "phoneNumber", model.PhoneNumber},
               };

                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                var tokenServiceResponse = await testServer.HttpClient.PostAsync(
                    "/Token", requestParamsFormUrlEncoded);

                if (tokenServiceResponse.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                    var jsSerializer = new JavaScriptSerializer();
                    var responseData =
                        jsSerializer.Deserialize<Dictionary<string, string>>(responseString);

                    // this boucle if use to hande the Exception : "Exception Details: System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary."
                    if ( responseData.ContainsKey("userID") && responseData.ContainsKey("access_token") && responseData.ContainsKey("userName") && responseData.ContainsKey("email") && responseData.ContainsKey("firstName") && responseData.ContainsKey("lastName") && responseData.ContainsKey("phoneNumber")) // && responseData.ContainsKey("email")
                    {                        
                        authToken = responseData["access_token"];

                        model.Id = responseData["userID"];
                        model.Username = responseData["userName"];
                        model.Email = responseData["email"];
                        model.FirstName = responseData["firstName"];
                        model.LastName = responseData["lastName"];
                        model.PhoneNumber = responseData["phoneNumber"];

                  /*  currentUser.Id = model.Id;
                    currentUser.UserName = model.Username;
                    currentUser.Email = model.Email;
                    currentUser.FirstName = model.FirstName;
                    currentUser.LastName = model.LastName;
                    currentUser.PhoneNumber = model.PhoneNumber; */

                    }

              

                userToUpdate = new AspNetUser
                   {
                    Id = model.Id,
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber
                };

                userID = userToUpdate.Id;
                userName = userToUpdate.UserName;
                email = userToUpdate.Email;
                firstName = userToUpdate.FirstName;
                lastName = userToUpdate.LastName;
                phoneNumber = userToUpdate.PhoneNumber;

                aspNetUserManager.UpdateAspNetUser(userToUpdate);
                //aspNetUserManager.UpdateProfileUser(userID,userName,email,firstName,lastName,phoneNumber);

                var msgUpdateSuccess = "Update Succeeded";
                return Ok(msgUpdateSuccess);
            }else
            {
                var msgUpdateFailed = "Update Failed";
                return Ok(msgUpdateFailed);
            }
            
                //IdentityResult result = await UserManager.UpdateAsync(currentUser);
                /*if (aspNetUserManager.UpdateAspNetUser(currentUser))
                {
                var msgUpdateSuccess = "Update Succeeded";
                return Ok(msgUpdateSuccess);
                }else
                {
                var msgUpdateFailed = "Update Failed";
                return Ok(msgUpdateFailed);
                }*/    
        }




        // GET api/User/ProfileAdminMonoprix"
        /*
             [System.Web.Http.HttpGet]
             [System.Web.Http.Route("ProfileAdminMonoprix")]
             [UserSessionTokenAuthorize]  // added by me
             [System.Web.Http.Authorize]  // added by me
             [System.Web.Http.AllowAnonymous] // added by me
             public IHttpActionResult GetProfileUserAdminMonoprix()
             {
                 // var p = UserProfile.GetProfile();
                 // if (p != null)
                 // {
                   //   return Ok("Welcome To MSS User Profile Section Mr : " + p.UserName);
                 // }else
                 // {
                   //   return Json("Error Profile didn't Reached");
                  //} 

                 if (!ModelState.IsValid)
                 {
                     return BadRequest(ModelState);
                 }

                 // Validate the current user exists in the database
                 var aspNetUserManager = new AspNetUserManager();
                 //var currentUserId = HttpContext.Current.User.Identity.GetUserId();
                 //var currentUserId = GetCurrentUserId();
                 //var c = Authentication.User.Identity.GetUserId();
                 //var currentUser = _userManager.FindById(currentUserId);
                 //var currentUser = this.Data.Users.All().FirstOrDefault(x => x.Id == currentUserId);
                 //var currentUserId = User.Identity.GetUserId();
                 var currentUser = aspNetUserManager.GetCurrentUserById(id_userLoggedIn_static);
                 var userToReturn = new AspNetUser();

                 if (currentUser == null)
                 {
                     var msg = string.Format("User #" + id_userLoggedIn_static + " Only 'Marchants' can access here , please try again ");
                     return Ok("Invalid user token! Please login again! not found!  => " + msg);
                 }
                 else
                 {
                     //var u = new ApplicationUser
                     //{
                       //  UserName = currentUser.UserName,
                        // Email = currentUser.Email                  
                     //};
                     userToReturn = new AspNetUser
                     {
                         Id = currentUser.Id,
                         FirstName = currentUser.FirstName,
                         LastName = currentUser.LastName,
                         Email = currentUser.Email,
                         Login = currentUser.Login,
                         UserName = currentUser.UserName,
                         PasswordHash = currentUser.PasswordHash,
                         PhoneNumber = currentUser.PhoneNumber,
                         Organization_Id = currentUser.Organization_Id
                     };

                    //  var detailsUserToReturn = new List<string>();
                    //  detailsUserToReturn.Add(userToReturn.Id);
                    //  detailsUserToReturn.Add(userToReturn.UserName);
                    //  detailsUserToReturn.Add(userToReturn.Email); 

                     //var welcome = "Welcome To MSS  Mr : ";

                     var id_toReturn = userToReturn.Id;
                     var userName_toReturn = userToReturn.UserName;
                     var email_toReturn = userToReturn.Email;
                     var firstName_toReturn = userToReturn.FirstName;
                     var lastName_toReturn = userToReturn.LastName;
                     var password_toReturn = userToReturn.PasswordHash;
                     var phoneNumber_toReturn = userToReturn.PhoneNumber;
                     var organization_id_toReturn = (int)userToReturn.Organization_Id;

                   //   detailsUserToReturn[0] = "Welcome To MSS : "+ userToReturn.UserName;
                   //   detailsUserToReturn[1] = userToReturn.Email; 

                     return Ok(new string[] { id_toReturn, userName_toReturn, email_toReturn, firstName_toReturn, lastName_toReturn, password_toReturn, phoneNumber_toReturn, organization_id_toReturn.ToString() });
                 }

             } */



        /*  Fin : Actions who did not work   */

    }
}
