namespace DevGeniusFinance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("devgeniusadm.VariableExpense")]
    public partial class VariableExpense
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public decimal Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public int? FormOfPayment_Id { get; set; }

        [StringLength(128)]
        public string User_CPF { get; set; }

        public string Place { get; set; }

        public virtual FormOfPayment FormOfPayment { get; set; }

        public virtual User User { get; set; }
    }
}
