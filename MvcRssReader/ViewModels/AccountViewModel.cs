using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcRssReader.ViewModels
{
    public class AccountViewModel
    {
        [Required(ErrorMessage="Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage="Password is required")]
        public string Password { get; set; }
    }
}