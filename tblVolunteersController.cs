using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RolesDemo.Models;

namespace RolesDemo.Controllers
{
    public class tblVolunteersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblVolunteers
        public ActionResult Index()
        {
            var tblVolunteers = db.tblVolunteers.Include(t => t.tblEvents);
            return View(tblVolunteers.ToList());
        }

        // GET: tblVolunteers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVolunteers tblVolunteers = db.tblVolunteers.Find(id);
            if (tblVolunteers == null)
            {
                return HttpNotFound();
            }
            return View(tblVolunteers);
        }

        // GET: tblVolunteers/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.tblEvents, "EventID", "EventName");
            return View();
        }

        // POST: tblVolunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VolunteerID,VolunteerName,ContactDetails,Qualified,EventID")] tblVolunteers tblVolunteers)
        {
            if (ModelState.IsValid)
            {
                db.tblVolunteers.Add(tblVolunteers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.tblEvents, "EventID", "EventName", tblVolunteers.EventID);
            return View(tblVolunteers);
        }

        // GET: tblVolunteers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVolunteers tblVolunteers = db.tblVolunteers.Find(id);
            if (tblVolunteers == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.tblEvents, "EventID", "EventName", tblVolunteers.EventID);
            return View(tblVolunteers);
        }

        // POST: tblVolunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VolunteerID,VolunteerName,ContactDetails,Qualified,EventID")] tblVolunteers tblVolunteers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVolunteers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.tblEvents, "EventID", "EventName", tblVolunteers.EventID);
            return View(tblVolunteers);
        }

        // GET: tblVolunteers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVolunteers tblVolunteers = db.tblVolunteers.Find(id);
            if (tblVolunteers == null)
            {
                return HttpNotFound();
            }
            return View(tblVolunteers);
        }

        // POST: tblVolunteers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVolunteers tblVolunteers = db.tblVolunteers.Find(id);
            db.tblVolunteers.Remove(tblVolunteers);
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
