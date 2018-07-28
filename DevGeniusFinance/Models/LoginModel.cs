using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevGeniusFinance.Models
{
    public partial class LoginModel
    {
        [Required]
        [MinLength(10)]
        public string CPF { get; set; }

        [MinLength(3)]
        [Required]
        public string Password { get; set; }

    }
}