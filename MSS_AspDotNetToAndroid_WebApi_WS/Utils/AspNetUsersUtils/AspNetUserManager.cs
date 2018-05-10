using Microsoft.AspNet.Identity;
using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Utils.AspNetUsersUtils
{
    public class AspNetUserManager
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbf);

        private AspNetUserRepository _aspNetUserRepos;

        public AspNetUserManager()
        {
            _aspNetUserRepos = new AspNetUserRepository();
        }

        private HttpRequestMessage CurrentRequest
        {
            get
            {
                return (HttpRequestMessage)HttpContext.Current.Items["MS_HttpRequestMessage"];
            }
        }

        private string GetCurrentBearerAuthrorizationToken()
        {
            string authToken = null;

            if (CurrentRequest.Headers.Authorization != null)
            {
                if (CurrentRequest.Headers.Authorization.Scheme == "bearer")
                {
                    authToken = CurrentRequest.Headers.Authorization.Parameter;
                }
            }
            return authToken;
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

        public AspNetUser GetCurrentUserById(string id)
        {
            var user = _aspNetUserRepos.getAspNetUserById(id);
            return user;
        }

        public void UpdateAspNetUser(AspNetUser user)
        {
            /* if (_aspNetUserRepos.updateAsptNetUser(user))
             {
                 return true;
             }else
             {
                 return false;
             } */

            _aspNetUserRepos.updateAsptNetUser(user);
        }

        public void UpdateProfileUser(string id, string userName, string email, string fName, string lName, string phoneNumber)
        {
            _aspNetUserRepos.updateAspNetUserProfile(id,userName,email,fName,lName,phoneNumber);
        }

        public List<AspNetUser> GetAspNetMerchantsUsersByAdminMerchant(AspNetUser usr)
        {
            var id_usr = usr.Id;
            var list_merchantsUsers = _aspNetUserRepos.getAllAspNetUsersMerchantsByAdminMerchant(id_usr);
            var l = new List<AspNetUser>();

            if (list_merchantsUsers.Count != 0 && list_merchantsUsers != null)
            {
                l =  (from u in list_merchantsUsers
                      orderby u.UserName
                      select new AspNetUser
                     {
                         Id = u.Id,
                         FirstName = u.FirstName,
                         LastName = u.LastName,
                         Email = u.Email,
                         UserName = u.UserName,
                         PhoneNumber = u.PhoneNumber
                     }
                     ).ToList();               
            }

            return l;                                
        }

        // Début : Méthode Send Email after Password Changed developped by me 
        public void sendEmailAfterPasswordChanged(string toRecipient, string subject, string body)
        {
            // SmtpClient : gmail
            var SmtpServer = new SmtpClient("smtp.gmail.com");

            // Specify the e-mail sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            var from = new MailAddress("validos11@gmail.com");

            // Set destinations for the e-mail message.
            var to = new MailAddress(toRecipient);

            // Specify the message content.
            var mailMessage = new MailMessage(from, to);

            mailMessage.Subject = subject;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = body;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            // Specify the credentials of the Sender
            var emailSender = "validos11@gmail.com";
            var passwordSender = "googleTech14isTheBest";

            SmtpServer.Port = 587; //25
            SmtpServer.Credentials = new System.Net.NetworkCredential(emailSender, passwordSender);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mailMessage);
        }
        // Fin : Méthode Send Email after Password Changed developped by me 

    }
}