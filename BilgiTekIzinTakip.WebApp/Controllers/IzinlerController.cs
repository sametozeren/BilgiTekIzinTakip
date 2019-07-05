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
    public class IzinlerController : Controller
    {
        private IzinlerManager ızinlerManager = new IzinlerManager();
        private IzinTipiManager izinTipiManager = new IzinTipiManager();

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
            return View();
        }

        // POST: Izinler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Izinler izinler)
        {
        
            if (ModelState.IsValid)
            {
                ızinlerManager.Insert(izinler);
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

                ızinlerManager.Update(izinler);
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
    }
}
