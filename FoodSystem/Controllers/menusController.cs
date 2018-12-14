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
    [Authorize(Roles ="Manager")]
    public class menusController : Controller
    {

        private Model1 db = new Model1();

        // GET: menus
        public ActionResult Index()
        {
            
            
            var menu = db.Menu.Include(m => m.category).Include(m => m.restaurant);
            return View(menu.ToList());
        }

        // GET: menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: menus/Create

        public ActionResult Create()
        {
            string name = User.Identity.Name;
            manager y = db.Manager.Where(x => x.manager_Name == name).FirstOrDefault();
            ViewBag.categoryID = new SelectList(db.Category, "categoryID", "category_Name");
            ViewBag.restaurantID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name");
            return View();
        }

        // POST: menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "menuID,menu_Name,price,restaurantID,categoryID")] menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menu.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.Category, "categoryID", "category_Name", menu.categoryID);
            ViewBag.restaurantID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name", menu.restaurantID);
            return View(menu);
        }

        // GET: menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.Category, "categoryID", "category_Name", menu.categoryID);
            ViewBag.restaurantID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name", menu.restaurantID);
            return View(menu);
        }

        // POST: menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "menuID,menu_Name,price,restaurantID,categoryID")] menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.Category, "categoryID", "category_Name", menu.categoryID);
            ViewBag.restaurantID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name", menu.restaurantID);
            return View(menu);
        }

        // GET: menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            menu menu = db.Menu.Find(id);
            db.Menu.Remove(menu);
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
