﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstMvcApp.Models;
using FirstMvcApp.Repositories;

namespace FirstMvcApp.Controllers
{
    public class CompetenciesController : Controller
    {
        CompetencyRepository db = new CompetencyRepository();
        CompetencyHeaderRepository headersDb = new CompetencyHeaderRepository();

        // GET: Competencies
        public ActionResult Index()
        {
            var competencies = db.Competencies.Include(c => c.CompetencyHeader);
            return View(competencies.ToList());
        }

        // GET: Competencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = db.Find(id.Value);
            if (competency == null)
            {
                return HttpNotFound();
            }
            return View(competency);
        }

        // GET: Competencies/Create
        public ActionResult Create()
        {
            ViewBag.CompetencyHeaderId = new SelectList(headersDb.CompetencyHeaders, "CompetencyHeaderId", "Name");
            return View();
        }

        // POST: Competencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetencyId,Name,CompetencyHeaderId")] Competency competency)
        {
            if (ModelState.IsValid)
            {
                db.InsertOrUpdate(competency);
                return RedirectToAction("Index");
            }

            ViewBag.CompetencyHeaderId = new SelectList(headersDb.CompetencyHeaders, "CompetencyHeaderId", "Name", competency.CompetencyHeaderId);
            return View(competency);
        }

        // GET: Competencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = db.Find(id.Value);
            if (competency == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetencyHeaderId = new SelectList(headersDb.CompetencyHeaders, "CompetencyHeaderId", "Name", competency.CompetencyHeaderId);
            return View(competency);
        }

        // POST: Competencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyId,Name,CompetencyHeaderId")] Competency competency)
        {
            if (ModelState.IsValid)
            {
                db.InsertOrUpdate(competency);
                return RedirectToAction("Index");
            }
            ViewBag.CompetencyHeaderId = new SelectList(headersDb.CompetencyHeaders, "CompetencyHeaderId", "Name", competency.CompetencyHeaderId);
            return View(competency);
        }

        // GET: Competencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = db.Find(id.Value);
            if (competency == null)
            {
                return HttpNotFound();
            }
            return View(competency);
        }

        // POST: Competencies/Delete/5 
        // There's an exception when confirm delete. But isit a good isead to delete?
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Competency cpt)
        {
            db.Delete(cpt);
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
