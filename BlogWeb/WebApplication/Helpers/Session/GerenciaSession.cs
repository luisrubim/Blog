using Business.Entitie.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication.Helpers.Session.Base;

namespace WebApplication.Helpers.Session
{
    public class GerenciaSession : GerenciaSessionBase
    {
        public const string nomeSessionToken = "SessionToken";

        public static LoginTokenResult Token
        {
            get
            {
                try
                {
                    return LeComDefault<LoginTokenResult>(nomeSessionToken);
                }
                catch (Exception ex)
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                    return null;
                }
            }
            set
            {
                Atualiza(nomeSessionToken, value);
            }
        }

    }
}