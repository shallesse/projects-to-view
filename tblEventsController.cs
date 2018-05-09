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
    public class tblEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblEvents
        public ActionResult Index()
        {
            var tblEvents = db.tblEvents.Include(t => t.tblUsers);
            return View(tblEvents.ToList());
        }

        // GET: tblEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEvents tblEvents = db.tblEvents.Find(id);
            if (tblEvents == null)
            {
                return HttpNotFound();
            }
            return View(tblEvents);
        }

        // GET: tblEvents/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.tblUsers, "User_ID", "User_Name");
            return View();
        }

        // POST: tblEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventName,EventStartDate,EventEndDate,status,EventLocation,EventDesc,User_ID,numVolunteers")] tblEvents tblEvents)
        {
            if (ModelState.IsValid)
            {
                db.tblEvents.Add(tblEvents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_ID = new SelectList(db.tblUsers, "User_ID", "User_Name", tblEvents.User_ID);
            return View(tblEvents);
        }

        // GET: tblEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEvents tblEvents = db.tblEvents.Find(id);
            if (tblEvents == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.tblUsers, "User_ID","User_Name", tblEvents.User_ID);
            return View(tblEvents);
        }

        // POST: tblEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventName,EventStartDate,EventEndDate,status,EventLocation,EventDesc,User_ID,numVolunteers")] tblEvents tblEvents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEvents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.tblUsers, "User_ID", "User_Name", tblEvents.User_ID);
            return View(tblEvents);
        }

        // GET: tblEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEvents tblEvents = db.tblEvents.Find(id);
            if (tblEvents == null)
            {
                return HttpNotFound();
            }
            return View(tblEvents);
        }

        // POST: tblEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEvents tblEvents = db.tblEvents.Find(id);
            db.tblEvents.Remove(tblEvents);
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
