using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Helpers.Session.Base
{
    public class GerenciaSessionBase
    {
        protected static T Le<T>(string nomeSession)
        {
            return (T)HttpContext.Current.Session[nomeSession];
        }

        protected static T LeComDefault<T>(string nomeSession)
        {
            object valor = HttpContext.Current.Session[nomeSession];

            return valor == null ? default(T) : ((T)valor);
        }

        protected static void Atualiza(string nomeSession, object valor)
        {
            HttpContext.Current.Session[nomeSession] = valor;
        }


        protected static void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }

        protected static void RemoveAll()
        {
            HttpContext.Current.Session.RemoveAll();
        }
    }
}