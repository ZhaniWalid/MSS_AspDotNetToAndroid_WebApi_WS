using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.BindingModels
{
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        /* début : added by me email */
        //[Required] => en cas de l'activer j'aurais erreur dans 'Postman' : 
        //    "modelState": {
        //      "model.Email": [
        //       "Le champ Email est requis."
        //      ]
        [Display(Name = "Email")]
        public string Email { get; set; }
        /* fin : added by me email*/

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    // Class Added by me , other class au dessus , default from Asp.Net 

    public class ResetPasswordBindingModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email_ResetPwd")]
        public string Email_ResetPwd { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password_ResetPwd")]
        public string Password_ResetPwd { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword_ResetPwd")]
        [Compare("Password_ResetPwd" /*, ErrorMessage = "The password and confirmation password do not match."*/ ) ]
        public string ConfirmPassword_ResetPwd { get; set; }

        //[Display(Name = "VerificationCode")]
        //public string VerificationCode { get; set; }
    }

    public class ForgotPasswordBindingModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email_ForgetPwd")]
        public string Email_ForgetPwd { get; set; }
    }

    public class VerificationCodeBindingModel
    {
        [Required]
        [Display(Name = "VerificationCode")]
        public string VerificationCode { get; set; }
    }

}
