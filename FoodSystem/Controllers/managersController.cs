using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodSystem;
using FoodSystem.Models;

namespace FoodSystem.Controllers
{
    public class managersController : Controller
    {
        private Model1 db = new Model1();

        // GET: managers
        public ActionResult Index()
        {
            var manager = db.Manager.Include(m => m.restaurant);
            return View(manager.ToList());
        }

        // GET: managers/Details/5
        public ActionResult Details(int? id)
        {
          //  var mname=User.Identity.Name
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manager manager = db.Manager.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // GET: managers/Create
        public ActionResult Create()
        {
            ViewBag.managerID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name");
            return View();
        }

        // POST: managers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "managerID,manager_Name,email")] manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Manager.Add(manager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.managerID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name", manager.managerID);
            return View(manager);
        }

        // GET: managers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manager manager = db.Manager.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            ViewBag.managerID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name", manager.managerID);
            return View(manager);
        }

        // POST: managers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "managerID,manager_Name,email")] manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.managerID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name", manager.managerID);
            return View(manager);
        }

        // GET: managers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            manager manager = db.Manager.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manager manager = db.Manager.Find(id);
            db.Manager.Remove(manager);
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
