using MSS_AspDotNetToAndroid_WebApi_WS.Context;
using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Repositories
{
    public class UserSessionTokenRepository : Service<UserSessionToken>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        //public static bool existsActualLoginSessions;

        public UserSessionTokenRepository() : base(utwk)
        {
        }

        public void AddUserSessionToken(UserSessionToken ust)
        {
            utwk.getRepository<UserSessionToken>().Add(ust);
            utwk.Commit();
        }

        public void DeleteUserSessionToken(UserSessionToken ust)
        {
            //var userSessionToken = getUserSessionTokenById(ust.Id);
            utwk.getRepository<UserSessionToken>().Delete(ust);
            utwk.Commit();
        }

        public void DeleteExpiredUserSessionToken(UserSessionToken userSessionTokenExpired)
        {
            userSessionTokenExpired = getExpiredUserSessionToken();
            utwk.getRepository<UserSessionToken>().Delete(userSessionTokenExpired);
            utwk.Commit();
        }

        public void UpdateUserSessionToken(UserSessionToken ust)
        {
            utwk.getRepository<UserSessionToken>().Update(ust);
            utwk.Commit();
        }

        public UserSessionToken getUserSessionTokenById(int id)
        {
            var userSessionToken = utwk.getRepository<UserSessionToken>().Get(ust => ust.Id == id);
            return userSessionToken;
        }

        public UserSessionToken getUserSessionTokenByCurrentIdAndAuhtToken(string currentUserId)
        {
            var userSessions = utwk.getRepository<UserSessionToken>().GetAll();
            var last_Owner_id = (from u in userSessions
                                 select u.OwnerAspNetUser_fk_Id).Last();
            /*var userSessionToken_ID = utwk.getRepository<UserSessionToken>().Get(session =>
              session.AuthToken == authToken && session.OwnerAspNetUser_fk_Id == currentUserId).Id;*/
            var userSessionToken = utwk.getRepository<UserSessionToken>().Get(session => last_Owner_id == currentUserId);
            //var userSessionToken = getUserSessionTokenById(userSessionToken_ID);

            return userSessionToken;
        }

        public UserSessionToken getRecentUserSessionToken(UserSessionToken last_recentUserSessionToken)
        {
            var userSessions = utwk.getRepository<UserSessionToken>().GetAll();

            var max_loginDateTime = (from u in userSessions
                                     select u.LoginDateTime).Max();
            var max_expirationDateTime = (from u in userSessions
                                          select u.ExpirationDateTime).Max();
             
            last_recentUserSessionToken = utwk.getRepository<UserSessionToken>().GetMany(ust => max_loginDateTime <= DateTime.Now && DateTime.Now <= max_expirationDateTime).OrderBy(ust => ust.LoginDateTime).Last();
            var last_recentUserSessionTokenByID = getUserSessionTokenById(last_recentUserSessionToken.Id);
            return last_recentUserSessionTokenByID;

            //var recentUserSessionToken = utwk.getRepository<UserSessionToken>().Get(ust => ust.LoginDateTime < DateTime.Now && DateTime.Now < ust.ExpirationDateTime);
            //var getId_recentUserSessionToken = last_recentUserSessionToken.Id;
            /* if (last_recentUserSessionToken!=null)
             {
                 existsActualLoginSessions = true;
             }else
             {
                 existsActualLoginSessions = false;
             }*/
        }

        public List<UserSessionToken> getLoggedInUserSessionTokenList()
        {
            var list = utwk.getRepository<UserSessionToken>().GetAll().ToList();
            return list;
        }

      /*  public bool verif_Exist_Recent_LoginSessions()
        {
            if (existsActualLoginSessions)
            {
                return true;
            }else
            {
                return false;
            }
        }*/

        public UserSessionToken getExpiredUserSessionToken()
        {
            var userSessionTokenExpired = utwk.getRepository<UserSessionToken>().Get(ust => ust.ExpirationDateTime < DateTime.Now);
            return userSessionTokenExpired;
        }

        public List<UserSessionToken> getExpiredUserSessionTokenList()
        {
            var List_userSessionTokens = utwk.getRepository<UserSessionToken>().GetMany(
                session => session.ExpirationDateTime < DateTime.Now).ToList();
         
            return List_userSessionTokens;
        }

        public string getAspNetUserIdByUserName(string userName)
        {
            var AspNetUserId = utwk.getRepository<AspNetUser>().Get(u => u.Login == userName).Id;
            return AspNetUserId;
        } 
    }
}