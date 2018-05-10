using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MSS_AspDotNetToAndroid_WebApi_WS.Context;
using MSS_AspDotNetToAndroid_WebApi_WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Repositories
{
    public class AuthenticationRepository : IDisposable
    {
        private GatewayPCIPINContext _ctx;
        private UserManager<IdentityUser> _userManager;

        public AuthenticationRepository()
        {
            _ctx = new GatewayPCIPINContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(AspNetUser userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.Login
            };

            var result = await _userManager.CreateAsync(user, userModel.PasswordHash);

            return result;
        }
      
        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);
            
            return user;
        }


        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }

        public void addUserSessionToken(UserSessionToken userSessionToken)
        {

        }
    }
}