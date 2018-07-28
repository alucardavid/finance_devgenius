using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevGeniusFinance.Entidades
{
    [Table("Account")]
    public class Account
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string UserCPF { get; set; }

        public virtual User User { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}