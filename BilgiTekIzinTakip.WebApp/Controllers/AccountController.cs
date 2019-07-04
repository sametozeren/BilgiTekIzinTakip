using BilgiTekIzinTakip.BusinessLayer;
using BilgiTekIzinTakip.BusinessLayer.Result;
using BilgiTekIzinTakip.Core.DataAccess;
using BilgiTekIzinTakip.Entities;
using BilgiTekIzinTakip.Entities.ValueObjects;
using BilgiTekIzinTakip.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BilgiTekIzinTakip.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private PersonelManager personelManager = new PersonelManager();
        public ActionResult Index()
        {
            return View();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {            
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Personel> res = personelManager.LoginUser(model);

                if (res.Errors.Count > 0)
                {
                    // Hata koduna göre özel işlem yapmamız gerekirse..
                    // Hatta hata mesajına burada müdahale edilebilir.
                    // (Login.cshtml'deki kısmında açıklama satırı şeklinden kurtarınız)
                    //
                    //if (res.Errors.Find(x => x.Code == ErrorMessageCode.UserIsNotActive) != null)
                    //{
                    //    ViewBag.SetLink = "http://Home/Activate/1234-4567-78980";
                    //}

                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                    return View(model);
                }

                CurrentSession.Set<Personel>("login", res.Result); // Session'a kullanıcı bilgi saklama..
                return RedirectToAction("Index");   // yönlendirme..
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }


        public ActionResult AccessDenied()
        {
            return View();
        }


        public ActionResult HasError()
        {
            return View();
        }
    }
}