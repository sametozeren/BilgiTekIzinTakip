using BilgiTekIzinTakip.BusinessLayer;
using BilgiTekIzinTakip.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgiTekIzinTakip.WebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            Test test = new Test();
            return View();
        }
    }
}