﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter your user name.")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
