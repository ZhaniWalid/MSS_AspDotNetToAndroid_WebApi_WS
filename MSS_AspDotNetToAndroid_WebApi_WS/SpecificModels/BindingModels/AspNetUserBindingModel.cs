using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.BindingModels
{
    public class AspNetUserBindingModel
    {
        // 
        public string Id { get; set; }
        //
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string OrganizationTypeName { get; set; }
        //
        public int? isBlocked { get; set; } // = 1 => Bloquer User Merchant | = 0 => Débloquer User Merchant
        //
        //
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public int? Organization_Id { get; set; }
        //
    }
}