using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            this.AspNetUserClaims = new List<AspNetUserClaim>();
            this.AspNetUserLogins = new List<AspNetUserLogin>();
            this.Tokens = new List<Token>();
            //this.UserSessionTokens = new List<UserSessionToken>();
            this.AspNetUsers1 = new List<AspNetUser>();
            this.AspNetUsers = new List<AspNetUser>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public int? Organization_Id { get; set; }
        public int IsFirstConnection { get; set; }
        public Nullable<int> OrganismIdentity_Id { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual OrganismIdentity OrganismIdentity { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
       
        public virtual ICollection<AspNetUser> AspNetUsers1 { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        /* debut : added by me to manage the 'Tokens on db' for the relation '1 to 1 between UserSessionToken & AspNetUser' */
        //public virtual UserSessionToken AspNetUserSessionToken { get; set; }
        public virtual ICollection<UserSessionToken> AspNetUserSessionTokens { get; set; }
        /*fin : added by me to manage the 'Tokens on db' for the relation '1 to 1 between UserSessionToken & AspNetUser'  */

        // added by me
        public int? isBlocked { get; set; } // = 1 => Bloquer User Merchant | = 0 => Débloquer User Merchant
        // fin added by me
    }
}
