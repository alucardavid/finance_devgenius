namespace DevGeniusFinance.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("devgeniusadm.MonthlyExpense")]
    public partial class MonthlyExpense
    {
        public int Id { get; set; }

        public string Place { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public int QtdPlots { get; set; }

        public int CurrentPlot { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? ExpenseCategory_Id { get; set; }

        public int? FormOfPayment_Id { get; set; }

        [StringLength(128)]
        public string User_CPF { get; set; }

        public virtual ExpenseCategory ExpenseCategory { get; set; }

        public virtual FormOfPayment FormOfPayment { get; set; }

        public virtual User User { get; set; }
    }
}
