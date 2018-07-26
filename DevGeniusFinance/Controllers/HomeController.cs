using DevGeniusFinance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DevGeniusFinance.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly Finance dbContext = new Finance(); 

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            // Get current user logged
            var user = dbContext.User.Find(User.Identity.Name);
            var monthPendingMonthlyExpense = user.MonthlyExpense.Where(m => m.Status == "Pendente").Min(m => m.DueDate.ToString("yyyyMM"));

            // Get all balances
            ViewBag.users = user.Balance.OrderBy(b => b.Description).ToList();

            // Get Sum of monthly expenses pending
            ViewBag.monthlyExpenseTotal = user.MonthlyExpense
                .Where(m => m.Status == "Pendente" && m.DueDate.ToString("yyyyMM") == monthPendingMonthlyExpense)
                .Sum(m => m.Value);

            return View();
        }
       
    }

}