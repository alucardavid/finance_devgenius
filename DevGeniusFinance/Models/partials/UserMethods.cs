using DevGeniusFinance.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevGeniusFinance.Entidades
{
    public partial class User
    {
        private readonly FinanceContext dbContext = new FinanceContext();

        public override string ToString() => $"{Name}";

        public List<Balance> GetBalances() => dbContext.Balance.Where(b => b.User_CPF == CPF).ToList();
        
    }
}