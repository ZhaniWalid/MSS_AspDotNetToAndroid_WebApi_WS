using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class UserSessionToken
    {
        [Key]
        public int Id { get; set; }

        /* for the relation '1 to 1 between UserSessionToken & AspNetUser' */
        [Required]
        //[ForeignKey]
        public string OwnerAspNetUser_fk_Id { get; set; }
        public virtual AspNetUser OwnerAspNetUser { get; set; }
        /* 'AspNetUser OwnerAspNetUser' is the class that will give us the Id of the User 
         * 'string OwnerAspNetUser_Id' is where the Id of the User will be Saved */

        //public virtual ApplicationUser OwnerUser { get; set; }


        [Required]
        [MaxLength(1024)]
        public string AuthToken { get; set; }

        [Required]
        public DateTime LoginDateTime { get; set; }

        [Required]
        public DateTime ExpirationDateTime { get; set; }

        public int is_LoggedIn_LoggedOut { get; set; } // 1 => is Logged In --- 0 => is Logged Out
    }
}
