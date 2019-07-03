using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BilgiTekIzinTakip.Entities;
using BilgiTekIzinTakip.WebApp.Models;

namespace BilgiTekIzinTakip.WebApp.Controllers
{
    public class MudurluksController : Controller
    {
        private BilgiTekIzinTakipWebAppContext db = new BilgiTekIzinTakipWebAppContext();

        // GET: Mudurluks
        public ActionResult Index()
        {
            return View(db.Mudurluks.ToList());
        }

        // GET: Mudurluks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mudurluk mudurluk = db.Mudurluks.Find(id);
            if (mudurluk == null)
            {
                return HttpNotFound();
            }
            return View(mudurluk);
        }

        // GET: Mudurluks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mudurluks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Isim,CreatedOn,ModifiedOn,ModifiedUsername")] Mudurluk mudurluk)
        {
            if (ModelState.IsValid)
            {
                db.Mudurluks.Add(mudurluk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mudurluk);
        }

        // GET: Mudurluks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mudurluk mudurluk = db.Mudurluks.Find(id);
            if (mudurluk == null)
            {
                return HttpNotFound();
            }
            return View(mudurluk);
        }

        // POST: Mudurluks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Isim,CreatedOn,ModifiedOn,ModifiedUsername")] Mudurluk mudurluk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mudurluk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mudurluk);
        }

        // GET: Mudurluks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mudurluk mudurluk = db.Mudurluks.Find(id);
            if (mudurluk == null)
            {
                return HttpNotFound();
            }
            return View(mudurluk);
        }

        // POST: Mudurluks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mudurluk mudurluk = db.Mudurluks.Find(id);
            db.Mudurluks.Remove(mudurluk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
