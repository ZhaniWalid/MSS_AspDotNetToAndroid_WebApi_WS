using Microsoft.AspNet.Identity;
using MSS_AspDotNetToAndroid_WebApi_WS.Controllers.MSS_Controllers;
using MSS_AspDotNetToAndroid_WebApi_WS.Providers;
using MSS_AspDotNetToAndroid_WebApi_WS.Utils.UserSessionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Controllers
{
    [System.Web.Http.Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        [System.Web.Http.Authorize]  // added by me to check liaison avec client Android MSS aprés login
        [HttpGet]  //  added by me to check liaison avec client Android MSS aprés login
        [AllowAnonymous] //  added by me to check liaison avec client Android MSS aprés login 
        [Route("api/values")] // added by me to check liaison avec client Android MSS aprés login
        public IEnumerable<string> Get()
        {
            // added by me
            
           string value1, value2, value3;
           /*
            if (User.Identity.IsAuthenticated)
            {
                value1 = "ID User Connected : "+ ApplicationOAuthProvider.id_user_signed_in;
                //value1 = HttpContext.Current.User.Identity.GetUserId(); //User.Identity.GetUserId();
                value2 = "User Name User Connected : "+ApplicationOAuthProvider.userName_user_signed_in;
                //value2 = HttpContext.Current.Request.LogonUserIdentity.Name;
            }
            else
            {
                value1 = "Value 1 : ID User didn't catch his values";
                value2 = "Value 2 : User Name didn't catch his values";
            }
            // find added by me
            */

            //return new string[] { "value1", "value2" }; => default return of the method
         /*   using (var client = new HttpClient())
            {
                var token = "access_token";
                client.DefaultRequestHeaders.Add("Authorization", string.Concat("bearer ", token));
                var response = client.GetAsync("http://localhost:83/api/Values").Result;
                values = response.Content.ReadAsStringAsync().Result;
            }*/


            value1 = "ID User Connected : " + UserController.id_userLoggedIn_static;
            //value1 = HttpContext.Current.User.Identity.GetUserId(); //User.Identity.GetUserId();
            value2 = "Login Succeeded , Welcome To MS Solutions Mr : " + UserController.userName_userLoggedIn_static;
            value3 = "Your Access_Token is :"+ UserController.authToken_userLoggedIn_static;
        
            return new string[] { value1, value2, value3}; // => my own return 

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
