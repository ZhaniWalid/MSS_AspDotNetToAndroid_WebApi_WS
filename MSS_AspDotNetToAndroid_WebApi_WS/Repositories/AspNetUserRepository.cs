using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.ServicePattern;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Repositories
{
    public class AspNetUserRepository : Service<AspNetUser>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public AspNetUserRepository() : base(utwk)
        {
        }

        public void CreateUserMerchant(AspNetUser user)
        {
            utwk.getRepository<AspNetUser>().Add(user);
            utwk.Commit();
        }

        public void DeleteUserMerchant(AspNetUser user)
        {
            utwk.getRepository<AspNetUser>().Delete(user);
            utwk.Commit();
        }

        public void DeleteUserMerchantById(string idUserMerchant)
        {
            var userMerchantToDelete = getAspNetUserById(idUserMerchant);
            DeleteUserMerchant(userMerchantToDelete);
        }

        public List<AspNetUser> getAllAspNetUsers()
        {
            var    list_AspNetUsers = utwk.getRepository<AspNetUser>().GetAll().ToList();
            return list_AspNetUsers;
        }

        public List<AspNetUser> getAllAspNetUsersMerchantsByAdminMerchant(string id_usr)
        {
            var list_AspNetUser = getAllAspNetUsers();
            var list_AspNetUsersMerchants = new List<AspNetUser>();

            if (id_usr.Equals("6081779f-b829-4669-a900-f5746ed97bb5")) // '6081779f-b829-4669-a900-f5746ed97bb5' is the id of 'AdminMonoprix' (Admin Merchant)
            {
                if (list_AspNetUser.Count != 0 && list_AspNetUser != null)
                {
                    list_AspNetUsersMerchants = (from u in list_AspNetUser
                                                 orderby u.UserName
                                                 where u.Organization_Id == 42 /*&& u.Id == id_usr*/
                                                 &&    u.Id != "6081779f-b829-4669-a900-f5746ed97bb5" // All Users Merchants without Admin Merchant
                                                 select new AspNetUser
                                                 {
                                                     //
                                                     Id = u.Id,
                                                     //
                                                     FirstName = u.FirstName,
                                                     LastName = u.LastName,
                                                     Email = u.Email,
                                                     PhoneNumber = u.PhoneNumber,
                                                     UserName = u.UserName,
                                                     Organization_Id = u.Organization_Id,
                                                     //
                                                     isBlocked = u.isBlocked
                                                     //
                                                 }
                                                 )
                                                 .Distinct()
                                                 .ToList();
                }              
            }  
         
            return list_AspNetUsersMerchants;
        }

        public List<Organization> getAllOrganizationsTypes()
        {
            var listAllOrganizationsTypes = utwk.getRepository<Organization>().GetAll().ToList();
            return listAllOrganizationsTypes;
        }

        public string getOrganizationTypeName(List<Organization> list_OrganizationTypes,List<AspNetUser> list_AspNetUsers,int? organizationId)
        {
            var organizationTypeName_ToReturn = (from o in list_OrganizationTypes
                                                 join u in list_AspNetUsers
                                                 on o.Id equals organizationId
                                                 select o.Name).FirstOrDefault();
            return organizationTypeName_ToReturn;
        }

        public AspNetUser getAspNetUserById(string id)
        {
            var list_AspNetUser = getAllAspNetUsers();
            var aspNetUser = list_AspNetUser.FirstOrDefault(user => user.Id == id); // eli ne5dm beha jawha behy
            //var aspNetUser = list_AspNetUser.FirstOrDefault(user => user.Id == id && user.Organization_Id == 42); // mamchetch mli7 : eli ntasti beha 3la ken les users 'marchant' du 'Organization_Id = 42'
            //var aspNetUser = utwk.getRepository<AspNetUser>().GetMany(user => user.Id == id).First();
            return aspNetUser;
        }

        public void updateAsptNetUser(AspNetUser user)
        {     
            utwk.getRepository<AspNetUser>().Update(user);
            utwk.Commit();
        }

        public void updateAspNetUserProfile(string id,string userName,string email,string fName,string lName,string phoneNumber)
        {
            var user = getAspNetUserById(id);
            user.UserName = userName;
            user.Email = email;
            user.FirstName = fName;
            user.LastName = lName;
            user.PhoneNumber = phoneNumber;

            updateAsptNetUser(user);
        }

        public void blockUserMerchantById(string idUserMerchant)
        {
            // Bloquer User Merchant
            var userMerchantToBlock = getAspNetUserById(idUserMerchant);

            if (userMerchantToBlock.isBlocked != 1)
            {
                userMerchantToBlock.isBlocked = 1; // = 1 => Bloquer User Merchant
            }
            // Faire la Mise A Jour
            updateAsptNetUser(userMerchantToBlock);
            
        }

        public void unblockUserMerchantById(string idUserMerchant)
        {
            // Débloquer User Merchant
            var userMerchantToUnblock = getAspNetUserById(idUserMerchant);
            if(userMerchantToUnblock.isBlocked != 0)
            {
                userMerchantToUnblock.isBlocked = 0; // = 0 => Débloquer User Merchant
            }
            // Faire la Mise A jour
            updateAsptNetUser(userMerchantToUnblock);
        }
    }
}