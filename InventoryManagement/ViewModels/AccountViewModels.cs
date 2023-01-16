using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace InventoryManagement.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "user name is mandatory")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "user name is mandatory")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "email is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [System.Web.Mvc.Compare("Password",ErrorMessage = "password does not match")]
        public string ConfirmPassword { get; set; }
    }
}