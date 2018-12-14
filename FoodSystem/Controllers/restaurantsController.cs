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
    [Authorize(Roles ="Admin")]
    
    public class restaurantsController : Controller
    {
        private Model1 db = new Model1();

        // GET: restaurants
        public ActionResult Index()
        {
            var restaurant = db.Restaurant.Include(r => r.manager);
            return View(restaurant.ToList());
        }

        // GET: restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restaurant restaurant = db.Restaurant.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: restaurants/Create
        public ActionResult Create()
        {
            ViewBag.restaurantID = new SelectList(db.Manager, "managerID", "manager_Name");
            return View();
        }

        // POST: restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "restaurantID,restaurant_Name,restaurant_Address")] restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurant.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.restaurantID = new SelectList(db.Manager, "managerID", "manager_Name", restaurant.restaurantID);
            return View(restaurant);
        }

        // GET: restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restaurant restaurant = db.Restaurant.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.restaurantID = new SelectList(db.Manager, "managerID", "manager_Name", restaurant.restaurantID);
            return View(restaurant);
        }

        // POST: restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "restaurantID,restaurant_Name,restaurant_Address")] restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.restaurantID = new SelectList(db.Manager, "managerID", "manager_Name", restaurant.restaurantID);
            return View(restaurant);
        }

        // GET: restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restaurant restaurant = db.Restaurant.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            restaurant restaurant = db.Restaurant.Find(id);
            db.Restaurant.Remove(restaurant);
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
