using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevGeniusFinance.Models
{
    public partial class Login
    {
        [Required(ErrorMessage = "CPF is Required")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

    }
}