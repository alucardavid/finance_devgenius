using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevGeniusFinance.Models
{
    public partial class MonthlyExpense
    {
        public override string ToString()
        {
            return $"{Description}";
        }
    }
}