using MSS_AspDotNetToAndroid_WebApi_WS.Infrastructure;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using MSS_AspDotNetToAndroid_WebApi_WS.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Repositories
{
    public class UserVerificationCodeRepository : Service<UserVerificationCode>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public UserVerificationCodeRepository() : base(utwk)
        {
        }

        public void AddNewVerificationCode(UserVerificationCode uvc)
        {
            utwk.getRepository<UserVerificationCode>().Add(uvc);
            utwk.Commit();
        }

        public void DeleteVerificationCode(UserVerificationCode uvc)
        {
            utwk.getRepository<UserVerificationCode>().Delete(uvc);
            utwk.Commit();
        }

        public List<UserVerificationCode> getAllVerificationCodes()
        {
            var     list_VerificationCodes = utwk.getRepository<UserVerificationCode>().GetAll().ToList();
            return  list_VerificationCodes;
        }

        public string getTheLastVerificationCodeByIdUser(string idUser)
        {
            var list_VerificationCodes = getAllVerificationCodes();

            var recent_DateTimeOfVerifCode = (from d in list_VerificationCodes
                                              select d.DateTimeOfVerifCode).Max();

            //var recent_IdUser = (from u in list_VerificationCodes select u.AspNetUser_fk_Id).Last();

            var verifCode = (from vc in list_VerificationCodes
                             where vc.AspNetUser_fk_Id.Equals(idUser)
                             && vc.DateTimeOfVerifCode.Equals(recent_DateTimeOfVerifCode)
                             select vc.VerificationCode).Last();

            //var verifCode = utwk.getRepository<UserVerificationCode>().GetMany(vc => vc.AspNetUser_fk_Id == idUser && vc.DateTimeOfVerifCode == recent_DateTimeOfVerifCode).LastOrDefault().VerificationCode;
            return verifCode;
        }
    }
}