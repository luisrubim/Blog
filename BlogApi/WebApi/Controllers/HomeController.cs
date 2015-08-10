using Api.Common.Factory;
using Business.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var teste =  BusinessLogicFactory<IUsuarioBL>.Instance.GetAll();

            return View();
        }
    }
}
