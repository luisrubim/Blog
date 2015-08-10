using Api.ServiceHttpClient;
using Business.Entitie;
using Business.Entitie.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Helpers.Session;

namespace WebApplication.Controllers
{
    public class UsuarioController : Controller
    {
        protected IUsuarioServiceHttpClient serviceUsuario;

        public UsuarioController()
        {
            serviceUsuario = ServiceHttpClientFactory<IUsuarioServiceHttpClient>.Instance;
            serviceUsuario.SetParametros(WebConfigurationManager.AppSettings["Url_Api"], GerenciaSession.Token);
        }

        #region Get

         [AllowAnonymous]
        public ActionResult Logar(string returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }

         [AllowAnonymous]
         public ActionResult DesLogar()
         {
             FormsAuthentication.SignOut();

             return RedirectToAction("Index", "Post");
         }


        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        #endregion

        #region Post

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Logar(Usuario entity)
        {
            LoginTokenResult token = serviceUsuario.Logar(entity.Email,entity.Senha);

            var returnUrl = TempData["ReturnUrl"];

            if (token != null)
            {
                FormsAuthentication.SetAuthCookie(token.NomeUsuario, true);
                FormsAuthenticationTicket ticket1 = new FormsAuthenticationTicket(1, token.NomeUsuario, DateTime.Now, DateTime.Now.AddMinutes(60), true, "HR");
                HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket1));
                Response.Cookies.Add(cookie1);

                GerenciaSession.Token = token;

                if (returnUrl != null && !String.IsNullOrEmpty(returnUrl.ToString()))
                    return Redirect(returnUrl.ToString());
                else
                    return RedirectToAction("Index", "Post"); 
            }
            
            ModelState.AddModelError("", "Usuário ou senha incorreta.");
            return View(entity);
        }

        [HttpPost]
        public ActionResult Registrar(Usuario entity)
        {
            entity = serviceUsuario.Save(entity);

            return RedirectToAction("Index", "Post");
        }

        #endregion

    }
}
