using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BilgiTekIzinTakip.BusinessLayer;
using BilgiTekIzinTakip.Entities;
using BilgiTekIzinTakip.WebApp.Models;

namespace BilgiTekIzinTakip.WebApp.Controllers
{
    public class IzinTipiController : Controller
    {
        private IzinTipiManager IzinTipiManager = new IzinTipiManager();

        // GET: IzinTipi
        public ActionResult Index()
        {
            return View(IzinTipiManager.List());
        }

        // GET: IzinTipi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzinTipi izinTipi = IzinTipiManager.Find(x => x.Id == id);
            if (izinTipi == null)
            {
                return HttpNotFound();
            }
            return View(izinTipi);
        }

        // GET: IzinTipi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IzinTipi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IzinTipi izinTipi)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                IzinTipiManager.Insert(izinTipi);
                return RedirectToAction("Index");
            }

            return View(izinTipi);
        }

        // GET: IzinTipi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzinTipi izinTipi = IzinTipiManager.Find(x => x.Id == id);
            if (izinTipi == null)
            {
                return HttpNotFound();
            }
            return View(izinTipi);
        }

        // POST: IzinTipi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IzinTipi izinTipi)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                IzinTipi tip = IzinTipiManager.Find(x=>x.Id==izinTipi.Id);
                tip.IzinTuru = izinTipi.IzinTuru;
                tip.RenkKodu = izinTipi.RenkKodu;
                IzinTipiManager.Update(tip);
                return RedirectToAction("Index");
            }
            return View(izinTipi);
        }
    }
}
