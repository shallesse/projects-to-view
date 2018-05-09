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
    public class tblBookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblBookings
        [Authorize]
        public ActionResult Index()
        {
            var tblBookings = db.tblBookings.Include(t => t.tblUsers);
            return View(tblBookings.ToList());
        }

        // GET: tblBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBookings tblBookings = db.tblBookings.Find(id);
            if (tblBookings == null)
            {
                return HttpNotFound();
            }
            




            return View(tblBookings);
        }
        public ActionResult Download(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBookings tblBookings = db.tblBookings.Find(id);
            if (tblBookings == null)
            {
                return HttpNotFound();
            }
            int booking = tblBookings.Booking_ID;
            string Name = tblBookings.Email;
            string Num = tblBookings.Number_Of_People;
            DateTime date = tblBookings.Date;
            String order = "Booking ID: " + booking.ToString()+"\n" + "Name: "+Name+"\n" +"Number Of Poeple: "+ Num +"\n" + "Date: " +date;
            var byteArray = Encoding.ASCII.GetBytes(Name);
            var stream = new MemoryStream(byteArray);
            return File(stream, "text/plain", "Booking.txt");
        }
        // GET: tblBookings/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.tblUsers, "User_ID", "User_Name");
            return View();
        }

        // POST: tblBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking_ID,Number_Of_People,Time,Date,Reference_Code,Email,User_ID")] tblBookings tblBookings)
        {
            if (ModelState.IsValid)
            {
                tblBookings.User_ID = User.Identity.Name;
                db.tblBookings.Add(tblBookings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_ID = new SelectList(db.tblUsers, "User_ID", "User_Name", tblBookings.User_ID);
            return View(tblBookings);
        }

        // GET: tblBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBookings tblBookings = db.tblBookings.Find(id);
            if (tblBookings == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.tblUsers, "User_ID", "User_Name", tblBookings.User_ID);
            return View(tblBookings);
        }

        // POST: tblBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_ID,Number_Of_People,Time,Date,Reference_Code,Email,User_ID")] tblBookings tblBookings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBookings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.tblUsers, "User_ID", "User_Name", tblBookings.User_ID);
            return View(tblBookings);
        }

        // GET: tblBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBookings tblBookings = db.tblBookings.Find(id);
            if (tblBookings == null)
            {
                return HttpNotFound();
            }
            return View(tblBookings);
        }

        // POST: tblBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBookings tblBookings = db.tblBookings.Find(id);
            db.tblBookings.Remove(tblBookings);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MyBooking()
        {
            var temp = (from booking in db.tblBookings
                        where booking.User_ID == User.Identity.Name
                        select booking).ToList();
            return View(temp);
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
