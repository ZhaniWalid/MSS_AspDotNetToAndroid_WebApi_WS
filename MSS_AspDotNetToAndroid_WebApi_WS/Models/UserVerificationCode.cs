using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public class UserVerificationCode
    {
        [Key]
        public int IdVerifCode { get; set; }

        /* For the relation '1..*' between  'UserVerificationCode' & 'AspNetUser' */
        [Required]
        public string AspNetUser_fk_Id { get; set; }
        public virtual AspNetUser OwnerCodeAspNetUser { get; set; }
        /* 'AspNetUser OwnerCodeAspNetUser' is the class that will give us the Id of the User 
         * 'string AspNetUser_fk_Id' is where the Id of the User will be Saved */

        [Required]
        public string VerificationCode { get; set; }

        [Required]
        public DateTime DateTimeOfVerifCode { get; set; }

    }
}