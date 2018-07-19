using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevGeniusFinance.Models
{
    public partial class User
    {
        private readonly Finance dbContext = new Finance();

        public override string ToString() => $"{Name}";

        public List<Balance> GetBalances() => dbContext.Balance.Where(b => b.User_CPF == CPF).ToList();
        
    }
}