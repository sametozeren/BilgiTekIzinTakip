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
    public class BaskanlikController : Controller
    {
        private BaskanlikManager db = new BaskanlikManager();

        // GET: Baskanlik
        public ActionResult Index()
        {
            return View(db.List());
        }

        // GET: Baskanlik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baskanlik baskanlik = db.Find(x => x.Id == id);

            if (baskanlik == null)
            {
                return HttpNotFound();
            }
            return View(baskanlik);
        }

        // GET: Baskanlik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Baskanlik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Baskanlik baskanlik)
        {
            if (ModelState.IsValid)
            {
                db.Insert(baskanlik);
                return RedirectToAction("Index");
            }

            return View(baskanlik);
        }

        // GET: Baskanlik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baskanlik baskanlik = db.Find(x => x.Id == id);

            if (baskanlik == null)
            {
                return HttpNotFound();
            }
            return View(baskanlik);
        }

        // POST: Baskanlik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Baskanlik baskanlik)
        {
            if (ModelState.IsValid)
            {
                db.Update(baskanlik);
                return RedirectToAction("Index");
            }
            return View(baskanlik);
        }

        // GET: Baskanlik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baskanlik baskanlik = db.Find(x => x.Id == id);

            if (baskanlik == null)
            {
                return HttpNotFound();
            }
            return View(baskanlik);
        }

        // POST: Baskanlik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Baskanlik baskanlik = db.Find(x => x.Id == id);
            if (baskanlik != null)
            {
                db.Delete(baskanlik);
            }
            return RedirectToAction("Index");
        }

       
    }
}
