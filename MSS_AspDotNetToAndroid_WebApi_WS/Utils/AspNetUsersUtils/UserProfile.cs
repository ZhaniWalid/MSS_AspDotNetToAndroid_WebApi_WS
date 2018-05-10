using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Utils.AspNetUsersUtils
{
    public class UserProfile : ProfileBase
    {
        public static UserProfile GetProfile()
        {
            return HttpContext.Current.Profile as UserProfile;
        }

        [SettingsAllowAnonymous(true)]
        public DateTime? LastVisit
        {
            get { return base["LastVisit"] as DateTime?; }
            set { base["LastVisit"] = value; }
        }

        public static UserProfile GetProfile(string userID)
        {
            return Create(userID) as UserProfile;
        }
    }
}