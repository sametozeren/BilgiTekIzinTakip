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
    public class MudurlukController : Controller
    {
        private MudurlukManager db = new MudurlukManager();
        private BaskanlikManager baskanlikManager = new BaskanlikManager();
        // GET: Mudurluk
        public ActionResult Index()
        {
            return View(db.List());
        }

        // GET: Mudurluk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mudurluk mudurluk = db.Find(x => x.Id == id);
            if (mudurluk == null)
            {
                return HttpNotFound();
            }
            return View(mudurluk);
        }

        // GET: Mudurluk/Create
        public ActionResult Create()
        {
            ViewBag.BaskanlikId = new SelectList(baskanlikManager.List(),"Id","Isim");

            return View();
        }

        // POST: Mudurluk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mudurluk mudurluk)
        {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (ModelState.IsValid)
            {
                db.Insert(mudurluk);
                return RedirectToAction("Index");
            }

            return View(mudurluk);
        }

        // GET: Mudurluk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mudurluk mudurluk = db.Find(x => x.Id == id);
            if (mudurluk == null)
            {
                return HttpNotFound();
            }
            return View(mudurluk);
        }

        // POST: Mudurluk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mudurluk mudurluk)
        {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (ModelState.IsValid)
            {
                db.Update(mudurluk);
                return RedirectToAction("Index");
            }
            return View(mudurluk);
        }

        // GET: Mudurluk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mudurluk mudurluk = db.Find(x=>x.Id==id);
            if (mudurluk == null)
            {
                return HttpNotFound();
            }
            return View(mudurluk);
        }

        // POST: Mudurluk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           Mudurluk mudurluk = db.Find(x => x.Id == id);
            if (mudurluk != null)
            {
                db.Delete(mudurluk);
            }
            return RedirectToAction("Index");
        }
    }
}
