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
    public class MudurlukController : Controller
    {
        private MudurlukManager mudurlukManager = new MudurlukManager();
        private BaskanlikManager baskanlikManager = new BaskanlikManager();
        // GET: Mudurluk
        public ActionResult Index()
        {
            return View(mudurlukManager.List());
        }

        // GET: Mudurluk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mudurluk mudurluk = mudurlukManager.Find(x => x.Id == id);
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
                mudurlukManager.Insert(mudurluk);
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
            Mudurluk mudurluk = mudurlukManager.Find(x => x.Id == id);
            if (mudurluk == null)
            {
                return HttpNotFound();
            }
            ViewBag.BaskanlikId = new SelectList(baskanlikManager.List(), "Id", "Isim"); ;
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
            ModelState.Remove("Baskanlik.Isim");
            ModelState.Remove("Baskanlik.ModifiedUsername");
            if (ModelState.IsValid)
            {
                Mudurluk mud = mudurlukManager.Find(x => x.Id == mudurluk.Id);
                mud.Isim = mudurluk.Isim;
                mud.BaskanlikId = mudurluk.Baskanlik.Id;
                mudurlukManager.Update(mud);
                return RedirectToAction("Index");

            }
            return View(mudurluk);
        }

      
    }
}
