using DevGeniusFinance.Models;
using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DevGeniusFinance.Controllers
{
    public class AccountController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallBack");

                return uriBuilder.Uri;
            }
        }
        private Finance db = new Finance();

        [AllowAnonymous]
        public ActionResult LoginWithFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "235786330527401",
                //cliente_secret = "a1eb15237e15d3a3103438525dda9709",
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = "227854638040731",
                client_secret = "45b32444b4e665d984d671f20ae836f3",
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            Session["AccessToken"] = accessToken;
            fb.AccessToken = accessToken;

            dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,age_range");
            string email = me.email;
            TempData["email"] = me.email;
            TempData["first_name"] = me.first_name;
            TempData["lastname"] = me.last_name;
            TempData["picture"] = me.picture.data.url;

            if (email.Contains("d_pereira@outlook.com.br"))
            {
                FormsAuthentication.SetAuthCookie(email, false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            // Verifica se model esta valido
            if (ModelState.IsValid)
            {
                // Retorna password da base de dados
                var user = (from userTmp in db.User where userTmp.CPF == login.CPF select userTmp).FirstOrDefault();

                if (user == null)
                {
                    ModelState.AddModelError(String.Empty, "Usuario não cadastrado.");
                    return View();
                }

                // Verifica se password corresponde ao da base de dados
                if (user.PassWord == login.Password)
                {
                    FormsAuthentication.SetAuthCookie(login.CPF, false);
                    Session["nome"] = user.Name;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Retorna view login
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
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }



    }
}