﻿using System;
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
    public class SeflikController : Controller
    {
        private SeflikManager db = new SeflikManager();

        // GET: Seflik
        public ActionResult Index()
        {
            return View(db.List());
        }

        // GET: Seflik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seflik seflik = db.Find(x => x.Id == id);
            if (seflik == null)
            {
                return HttpNotFound();
            }
            return View(seflik);
        }

        // GET: Seflik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seflik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seflik seflik)
        {
            if (ModelState.IsValid)
            {
                db.Insert(seflik);
                return RedirectToAction("Index");
            }

            return View(seflik);
        }

        // GET: Seflik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seflik seflik = db.Find(x => x.Id == id);
            if (seflik == null)
            {
                return HttpNotFound();
            }
            return View(seflik);
        }

        // POST: Seflik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Seflik seflik)
        {
            if (ModelState.IsValid)
            {
                db.Update(seflik);
                return RedirectToAction("Index");
            }
            return View(seflik);
        }

        // GET: Seflik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seflik seflik = db.Find(x => x.Id == id);
            if (seflik == null)
            {
                return HttpNotFound();
            }
            return View(seflik);
        }

        // POST: Seflik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seflik seflik = db.Find(x => x.Id == id);

            if (seflik != null)
            {
                db.Delete(seflik);
            }
            return RedirectToAction("Index");
        }
    }
}
