using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RolesDemo.Models;
using System.Text;
using System.IO;

namespace RolesDemo.Controllers
{
    public class tblUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblStaffs
        public ActionResult Index()
        {
            return View(db.tblUsers.ToList());
        }

        

        // GET: tblStaffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblStaff = db.tblUsers.Find(id);
            if (tblStaff == null)
            {
                return HttpNotFound();
            }
            return View(tblStaff);
        }

        // GET: tblStaffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblStaffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,User_Name,Contact_Details")] tblUsers tblStaff)
        {
            if (ModelState.IsValid)
            {
                db.tblUsers.Add(tblStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblStaff);
        }

        // GET: tblStaffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblStaff = db.tblUsers.Find(id);
            if (tblStaff == null)
            {
                return HttpNotFound();
            }
            return View(tblStaff);
        }

        // POST: tblStaffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,User_Name,Contact_Details")] tblUsers tblStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblStaff);
        }

        // GET: tblStaffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers tblStaff = db.tblUsers.Find(id);
            if (tblStaff == null)
            {
                return HttpNotFound();
            }
            return View(tblStaff);
        }

        // POST: tblStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUsers tblStaff = db.tblUsers.Find(id);
            db.tblUsers.Remove(tblStaff);
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
