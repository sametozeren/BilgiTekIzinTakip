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
using BilgiTekIzinTakip.WebApp.Filters;
using BilgiTekIzinTakip.WebApp.Models;

namespace BilgiTekIzinTakip.WebApp.Controllers
{
    [Auth]
    public class IzinlerController : Controller
    {
        private IzinlerManager ızinlerManager = new IzinlerManager();
        private IzinTipiManager izinTipiManager = new IzinTipiManager();
        private PersonelManager personelManager = new PersonelManager();
        // GET: Izinler
        public ActionResult Index()
        {
            return View(ızinlerManager.List());
        }

        // GET: Izinler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Izinler izinler = ızinlerManager.Find(x => x.Id == id);
            if (izinler == null)
            {
                return HttpNotFound();
            }
            return View(izinler);
        }

        // GET: Izinler/Create
        public ActionResult Create()
        {
            ViewBag.IzinTuru = new SelectList(izinTipiManager.List(), "Id","IzinTuru");
            ViewBag.Personel = new SelectList(personelManager.List(), "Id", "Ad");
            return View();
        }

        // POST: Izinler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Izinler izinler)
        {
            string[] id = izinler.NameSurname.Split(' ');
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            ModelState.Remove("IzinTipi.IzinTuru");
            ModelState.Remove("IzinTipi.RenkKodu");
            ModelState.Remove("IzinTipi.ModifiedUsername");
            if (ModelState.IsValid)
            {
                Izinler yeni = new Izinler();
                yeni.BaslangicTarihi = izinler.BaslangicTarihi;
                yeni.BitisTarihi = izinler.BitisTarihi;
                yeni.IzinTipiId = izinler.IzinTipi.Id;
                yeni.PersonelId = Convert.ToInt32(id[0]);
                ızinlerManager.Insert(yeni);
                return RedirectToAction("Index");
            }

            return View(izinler);
        }

        // GET: Izinler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Izinler izinler = ızinlerManager.Find(x => x.Id == id);
            if (izinler == null)
            {
                return HttpNotFound();
            }

            ViewBag.IzinTuru = new SelectList(izinTipiManager.List(), "Id","IzinTuru");
            return View(izinler);
        }

        // POST: Izinler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Izinler izinler)
        {
            if (ModelState.IsValid)
            {
                Izinler up = ızinlerManager.Find(x=>x.Id==izinler.Id);
                up.BaslangicTarihi = izinler.BaslangicTarihi;
                up.BitisTarihi = izinler.BitisTarihi;
                up.IzinTipiId = izinler.IzinTipiId;
                ızinlerManager.Update(up);
                return RedirectToAction("Index");
            }
            return View(izinler);
        }

        // GET: Izinler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Izinler izinler = ızinlerManager.Find(x => x.Id == id);
            if (izinler == null)
            {
                return HttpNotFound();
            }
            return View(izinler);
        }

        // POST: Izinler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Izinler izinler = ızinlerManager.Find(x => x.Id == id);
            if (izinler!=null)
            {
                ızinlerManager.Delete(izinler);
            }
            return RedirectToAction("Index");
        }
        public JsonResult GetPerson(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var users = personelManager.List(x=>x.Ad.Contains(term)).Select(s => s.Id + " - " + s.SicilNo+" - "+s.Ad+ " " +s.Soyad).ToList();
                return Json(users, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var users = personelManager.List().Select(s =>s.Id + " - "+ s.SicilNo + " - " + s.Ad + " " + s.Soyad);
                return Json(users, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
