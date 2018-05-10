﻿using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;
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
                list_AspNetUsersMerchants = (from u in list_AspNetUser
                                             where u.Organization_Id == 42 /*&& u.Id == id_usr*/
                                             select u).ToList();
            }  
         
            return list_AspNetUsersMerchants;
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
            //var usr = new AspNetUser { Id = user.Id, UserName = user.UserName, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, PhoneNumber = user.PhoneNumber };
            //dbf.DataContext.AspNetUsers.Attach(user);

            /*if (   dbf.DataContext.Entry(user).Property(x => x.UserName).IsModified == true 
                || dbf.DataContext.Entry(user).Property(x => x.Email).IsModified == true
                || dbf.DataContext.Entry(user).Property(x => x.FirstName).IsModified == true
                || dbf.DataContext.Entry(user).Property(x => x.LastName).IsModified == true
                || dbf.DataContext.Entry(user).Property(x => x.PhoneNumber).IsModified == true )
            {
                utwk.getRepository<AspNetUser>().Update(user);
                utwk.Commit();

                return true;
            }else
            {
                return false;
            }*/

            //dbf.DataContext.Entry(user).State = EntityState.Modified;

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

        
    }
}