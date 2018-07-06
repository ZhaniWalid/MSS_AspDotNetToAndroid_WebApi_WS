using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MSS_AspDotNetToAndroid_WebApi_WS.Repositories;
using MSS_AspDotNetToAndroid_WebApi_WS.Utils.AspNetUsersUtils;
using MSS_AspDotNetToAndroid_WebApi_WS.Utils.StatusCodeUtils;
using MSS_AspDotNetToAndroid_WebApi_WS.Utils.UserSessionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Controllers.MSS_Controllers
{
    //[UserSessionTokenAuthorize]
    [System.Web.Http.RoutePrefix("https://fcm.googleapis.com/fcm/send")]
    public class FirebaseController : ApiController
    {
        private AuthenticationRepository _repo = null;
        private ApplicationUserManager _userManager;

        public FirebaseController()
        {
            _repo = new AuthenticationRepository();
        }

        public FirebaseController(ApplicationUserManager userManager,
           ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

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

        // POST https://fcm.googleapis.com/fcm/send/PostNotifAboutRejectedTrans
        [System.Web.Http.HttpPost]  // added by me
        //[UserSessionTokenAuthorize]  // added by me
        [System.Web.Http.Authorize]  // added by me
        [System.Web.Http.AllowAnonymous] // added by me
        [System.Web.Http.Route("PostNotifAboutRejectedTrans")]
        public IHttpActionResult GetNotificationAboutRejectedTransactions()
        {
            var _statusCodeManager = new StatusCodeManager();
            //var _aspNetUserManager = new AspNetUserManager();

            //var currentUser = _aspNetUserManager.GetCurrentUserById(id_userLoggedIn_static);
            //var resultPushNotif = _statusCodeManager.sendNotificationOfRejectedTransactions();
            var resultJsonNotif = _statusCodeManager.getValuesSentNotificationFromFirebaseCloud();
            //var sent = await _statusCodeManager.sendPushNotifcationToFirebase();

            if (resultJsonNotif != null)
            {
                //var msg = "Notification Sent Success";           
                return Ok(resultJsonNotif);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
