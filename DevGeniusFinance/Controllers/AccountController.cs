using DevGeniusFinance.DAO;
using DevGeniusFinance.Entidades;
using DevGeniusFinance.Models;
using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace DevGeniusFinance.Controllers
{
    public class AccountController : Controller
    {
        private FinanceContext context;

        public AccountController(FinanceContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(LoginModel login)
        {
            // Verifica se model esta valido
            if (ModelState.IsValid)
            {

                if (WebSecurity.Login(login.CPF, login.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Usuario não cadastrado.");
                    return View();
                }
            }
            else
            {
                // Retorna view login
                return View();
            }
        }

        public ActionResult LogOut()
        {
            WebSecurity.Logout();

            return RedirectToAction("Login");
        }



    }
}