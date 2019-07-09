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
    public class PersonelsController : Controller
    {

        private PersonelManager personel2 = new PersonelManager();
        // GET: Personels
        public ActionResult Index()
        {
            var personels = personel2.List();
            return View(personels.ToList());
        }

        //// GET: Personels/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Personel personel = db.Personels.Find(id);
        //    if (personel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(personel);
        //}

        //// GET: Personels/Create
        //public ActionResult Create()
        //{
        //    ViewBag.BaskanlikId = new SelectList(db.Baskanliks, "Id", "Isim");
        //    ViewBag.MudurlukId = new SelectList(db.Mudurluks, "Id", "Isim");
        //    ViewBag.SeflikId = new SelectList(db.Sefliks, "Id", "Isim");
        //    return View();
        //}

        //// POST: Personels/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,SicilNo,Ad,Soyad,Email,DahiliNumarasi,KullaniciAdi,Sifre,IsAdmin,BaskanlikId,MudurlukId,SeflikId,CreatedOn,ModifiedOn,ModifiedUsername")] Personel personel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Personels.Add(personel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.BaskanlikId = new SelectList(db.Baskanliks, "Id", "Isim", personel.BaskanlikId);
        //    ViewBag.MudurlukId = new SelectList(db.Mudurluks, "Id", "Isim", personel.MudurlukId);
        //    ViewBag.SeflikId = new SelectList(db.Sefliks, "Id", "Isim", personel.SeflikId);
        //    return View(personel);
        //}

        //// GET: Personels/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Personel personel = db.Personels.Find(id);
        //    if (personel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.BaskanlikId = new SelectList(db.Baskanliks, "Id", "Isim", personel.BaskanlikId);
        //    ViewBag.MudurlukId = new SelectList(db.Mudurluks, "Id", "Isim", personel.MudurlukId);
        //    ViewBag.SeflikId = new SelectList(db.Sefliks, "Id", "Isim", personel.SeflikId);
        //    return View(personel);
        //}

        //// POST: Personels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,SicilNo,Ad,Soyad,Email,DahiliNumarasi,KullaniciAdi,Sifre,IsAdmin,BaskanlikId,MudurlukId,SeflikId,CreatedOn,ModifiedOn,ModifiedUsername")] Personel personel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(personel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.BaskanlikId = new SelectList(db.Baskanliks, "Id", "Isim", personel.BaskanlikId);
        //    ViewBag.MudurlukId = new SelectList(db.Mudurluks, "Id", "Isim", personel.MudurlukId);
        //    ViewBag.SeflikId = new SelectList(db.Sefliks, "Id", "Isim", personel.SeflikId);
        //    return View(personel);
        //}

        //// GET: Personels/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Personel personel = db.Personels.Find(id);
        //    if (personel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(personel);
        //}

        //// POST: Personels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Personel personel = db.Personels.Find(id);
        //    db.Personels.Remove(personel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
