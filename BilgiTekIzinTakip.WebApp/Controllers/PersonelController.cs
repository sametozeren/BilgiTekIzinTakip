using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BilgiTekIzinTakip.BusinessLayer;
using BilgiTekIzinTakip.Entities;
using BilgiTekIzinTakip.WebApp.Filters;
using BilgiTekIzinTakip.WebApp.Models;

namespace BilgiTekIzinTakip.WebApp.Controllers
{
    [Auth]
    public class PersonelController : Controller
    {
        private PersonelManager personelManager = new PersonelManager();
        private BaskanlikManager baskanlikManager = new BaskanlikManager();
        private MudurlukManager mudurlukManager = new MudurlukManager();
        private SeflikManager seflikManager = new SeflikManager();


        // GET: Personel
        public ActionResult Index()
        {
            return View(personelManager.List());
        }

        // GET: Personel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = personelManager.Find(x => x.Id == id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personel/Create
        public ActionResult Create()
        {

            ViewBag.BaskanlikId = new SelectList(baskanlikManager.List(), "Id", "Isim");
            ViewBag.MudurlukId = new SelectList(mudurlukManager.List(), "Id", "Isim");
            ViewBag.SeflikId = new SelectList(seflikManager.List(), "Id", "Isim");
            return View();
        }

        // POST: Personel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personel personel)
        {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            ModelState.Remove("KullaniciAdi");
            ModelState.Remove("Sifre");
            if (ModelState.IsValid)
            {
                personelManager.Insert(personel);
                return RedirectToAction("Index");
            }

            return View(personel);
        }

        // GET: Personel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = personelManager.Find(x => x.Id == id);
            if (personel == null)
            {
                return HttpNotFound();
            }

            ViewBag.BaskanlikId = new SelectList(baskanlikManager.List(), "Id", "Isim");
            ViewBag.MudurlukId = new SelectList(mudurlukManager.List(), "Id", "Isim");
            ViewBag.SeflikId = new SelectList(seflikManager.List(), "Id", "Isim");
            return View(personel);
        }

        // POST: Personel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Personel personel)
        {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            ModelState.Remove("KullaniciAdi");
            ModelState.Remove("Sifre");
            ModelState.Remove("Baskanlik.Isim");
            ModelState.Remove("Mudurluk.Isim");
            ModelState.Remove("Seflik.Isim");
            ModelState.Remove("Baskanlik.ModifiedUsername");
            ModelState.Remove("Mudurluk.ModifiedUsername");
            ModelState.Remove("Seflik.ModifiedUsername");
            if (ModelState.IsValid)
            {
                Personel per = personelManager.Find(x=>x.Id==personel.Id);
                if (per!=null)
                {
                    if (personel.Sifre!=null)
                    {
                        string hash = Crypto.HashPassword(personel.Sifre);
                        per.Sifre = hash;
                    }
                    per.SicilNo = personel.SicilNo;
                    per.Ad = personel.Ad;
                    per.Soyad = personel.Soyad;
                    per.MudurlukId = personel.Mudurluk.Id;
                    per.BaskanlikId = personel.Baskanlik.Id;
                    per.SeflikId = personel.Seflik.Id;
                    per.Email = personel.Email;
                    per.DahiliNumarasi = personel.DahiliNumarasi;
                    per.KullaniciAdi = personel.KullaniciAdi;
                    per.IsAdmin = personel.IsAdmin;
                }
                personelManager.Update(per);
                return RedirectToAction("Index");
            }
            return View(personel);
        }

        // GET: Personel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = personelManager.Find(x => x.Id == id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personel personel = personelManager.Find(x => x.Id == id);

            if (personel != null)
            {
                personelManager.Delete(personel);
            }
            return RedirectToAction("Index");
        }

       
    }
}
