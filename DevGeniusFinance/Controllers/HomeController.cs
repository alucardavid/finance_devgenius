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

            // Get all balances
            ViewBag.users = user.Balance.ToList();

            return View();
        }
       
    }

}