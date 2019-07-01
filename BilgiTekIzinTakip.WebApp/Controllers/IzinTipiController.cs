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
       private IzinTipiManager db = new IzinTipiManager();

        // GET: IzinTipi
        public ActionResult Index()
        {
            return View(db.List());
        }

        // GET: IzinTipi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzinTipi izinTipi = db.Find(x => x.Id == id);
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
            if (ModelState.IsValid)
            {
                db.Insert(izinTipi);
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
            IzinTipi izinTipi = db.Find(x => x.Id == id);
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
            if (ModelState.IsValid)
            {
                db.Update(izinTipi);
                return RedirectToAction("Index");
            }
            return View(izinTipi);
        }

        // GET: IzinTipi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IzinTipi izinTipi = db.Find(x => x.Id == id);
            if (izinTipi == null)
            {
                return HttpNotFound();
            }
            return View(izinTipi);
        }

        // POST: IzinTipi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IzinTipi izinTipi = db.Find(x => x.Id == id);
            if (izinTipi != null)
            {
                db.Delete(izinTipi);
            }
            return RedirectToAction("Index");
        }

        
    }
}
