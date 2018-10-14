using Microsoft.AspNet.Identity;
using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.Repositories;
using MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
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

        public AspNetUser GetAspNetUserByEmail(string email)
        {
            var user = _aspNetUserRepos.getAspNetUserByEmail(email);
            return user;
        }

        public bool isUserExistByEmail(string email)
        {
            bool exist;

            if (!_aspNetUserRepos.isEmailExist(email))
            {
                exist = false;
            }else
            {
                exist = true;
            }

            return exist;
        }

        public string GetId_AspNetUserByEmail(string email)
        {
           var idUser = _aspNetUserRepos.getIdAspNetUserByEmail(email);
           return idUser;
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

        public List<AspNetUserBindingModel> GetAspNetMerchantsUsersByAdminMerchant(AspNetUser usr)
        {
            var id_usr = usr.Id;
            var returnedListMerchantsUsers = _aspNetUserRepos.getAllAspNetUsersMerchantsByAdminMerchant(id_usr);
            var returnedListListOrganiztionTypes = _aspNetUserRepos.getAllOrganizationsTypes();

            var list_merchantsUsers = new List<AspNetUserBindingModel>();

            string Id_ToReturn = " ";
            string FirstName_ToReturn = " ",LastName_ToReturn = " ",Email_ToReturn = " ",PhoneNumber_ToReturn = " ",UserName_ToReturn = " ";
            int? OrganizationId_ToReturn = 0, isBlocked_ToReturn = 0;
            string OrganizationTypeName_ToReturn = " ";

            if (returnedListMerchantsUsers.Count != 0 && returnedListMerchantsUsers != null)
            {
                foreach (AspNetUser user in returnedListMerchantsUsers)
                {
                    //
                    Id_ToReturn = user.Id;
                    //
                    FirstName_ToReturn = user.FirstName;
                    LastName_ToReturn = user.LastName;
                    Email_ToReturn = user.Email;
                    PhoneNumber_ToReturn = user.PhoneNumber;
                    UserName_ToReturn = user.UserName;
                    OrganizationId_ToReturn = user.Organization_Id;
                    //
                    isBlocked_ToReturn = user.isBlocked; // = 1 => Bloquer User Merchant | = 0 => Débloquer User Merchant
                    //

                    if (returnedListListOrganiztionTypes.Count != 0 && returnedListListOrganiztionTypes != null)
                    {
                        OrganizationTypeName_ToReturn =
                                      _aspNetUserRepos
                                      .getOrganizationTypeName(returnedListListOrganiztionTypes,returnedListMerchantsUsers,OrganizationId_ToReturn);
                    }

                    list_merchantsUsers.Add(new AspNetUserBindingModel
                    {
                        //
                        Id = Id_ToReturn,
                        //
                        FirstName = FirstName_ToReturn,
                        LastName = LastName_ToReturn,
                        Email = Email_ToReturn,
                        PhoneNumber = PhoneNumber_ToReturn,
                        UserName = UserName_ToReturn,
                        OrganizationTypeName = OrganizationTypeName_ToReturn,
                        //
                        isBlocked = isBlocked_ToReturn, // = 1 => Bloquer User Merchant | = 0 => Débloquer User Merchant
                        //
                        Organization_Id = OrganizationId_ToReturn // zeyda raw juste akéka 7atitha bsh nzid nthabet beha
                    }
                    );

                    list_merchantsUsers.OrderBy(u => u.UserName)
                                       .GroupBy(u => u.OrganizationTypeName)
                                       .Distinct();   
                }
             }

            return list_merchantsUsers;

            /*
             * 
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
            */
        }

        public void BlockUserMerchantByAdminMerchant(string idUserToBlock)
        {
            //var id_user = user.Id;
            _aspNetUserRepos.blockUserMerchantById(idUserToBlock); // = 1 => Bloquer User Merchant
        }

        public void UnblockUserMerchantByAdminMerchant(string idUserToUnblock)
        {
            //var id_user = user.Id;
            _aspNetUserRepos.unblockUserMerchantById(idUserToUnblock); // = 0 => Débloquer User Merchant
        }

        public void CreateUserMerchantByAdminMerchant(AspNetUser user)
        {
            _aspNetUserRepos.CreateUserMerchant(user);
        }

        public void DeleteUserMerchantByAdminMerchant(string idUserToDelete)
        {
            _aspNetUserRepos.DeleteUserMerchantById(idUserToDelete);
        }

        public string securityStamp_RandomGenerator_StringFormat(int length)
        {
            var list_AspNetUsers = _aspNetUserRepos.getAllAspNetUsers();
            var list_securityStamps = list_AspNetUsers.Select(v => v.SecurityStamp).ToList();

            Random random = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789 -";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            string autoGeneratedSecurityStamp = builder.ToString();
            string GeneratedSecurityStamp = " ";

            for (int i = 0; i < list_securityStamps.Count; i++)
            {
                if (!autoGeneratedSecurityStamp.Equals(list_securityStamps[i]))
                {
                    GeneratedSecurityStamp = autoGeneratedSecurityStamp;
                }
                else
                {
                    GeneratedSecurityStamp = null;
                }
            }

            return GeneratedSecurityStamp;
        }

        public string Id_RandomGenerator_StringFormat(int length)
        {
            var list_AspNetUsers = _aspNetUserRepos.getAllAspNetUsers();
            var list_id = list_AspNetUsers.Select(v => v.Id).ToList();

            Random random = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789 -";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            string autoGeneratedId = builder.ToString();
            string GeneratedId = " ";

            for (int i=0; i < list_id.Count; i++)
            {
                if (!autoGeneratedId.Equals(list_id[i]))
                {
                    GeneratedId = autoGeneratedId;
                }else
                {
                    GeneratedId = null;
                }
            }

            return GeneratedId;
        }

        // Début : Méthode Send Email after Some Change ( like Password Changed developped by me )
        public void sendEmail(string toRecipient, string subject, string body)
        {
            // SmtpClient : gmail
            var SmtpServer = new SmtpClient("smtp.gmail.com");

            // Specify the e-mail sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            var from = new MailAddress("#####");

            // Set destinations for the e-mail message.
            var to = new MailAddress(toRecipient);

            // Specify the message content.
            var mailMessage = new MailMessage(from, to);

            mailMessage.Subject = subject;
            mailMessage.SubjectEncoding = Encoding.UTF8;
            mailMessage.Body = body;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            // Specify the credentials of the Sender
            var emailSender = "#####";
            var passwordSender = "#####";

            SmtpServer.Port = 587; //25
            SmtpServer.Credentials = new System.Net.NetworkCredential(emailSender, passwordSender);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mailMessage);
        }
        // Fin : Méthode Send Email after Some Change ( like Password Changed developped by me ) 

    }
}
