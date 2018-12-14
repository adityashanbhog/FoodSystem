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
    [Authorize(Roles = "Manager")]
    public class managermenusController : Controller
    {
        private Model1 db = new Model1();

        // GET: managermenus
        [NonAction]
        public int getResid()
        {
            string name = User.Identity.Name;
            var resid = from r in db.Manager
                        where r.manager_Name == name
                        select r.restaurant.restaurantID;
            var resid1 = resid.FirstOrDefault();
            return resid1;
        }
        public ActionResult Index()
        {
            
            int d = getResid();
            var res = from r in db.Restaurant where r.restaurantID == d select new { rname = r.restaurant_Name };
            ViewBag.resName = res;
            var me = from m in db.Menu
                     where m.restaurantID == d
                     select m;
            var men = from m in me
                      join c in db.Category on m.categoryID equals c.categoryID
                      select c.category_Name;
            var men1 = (men.ToList()).Distinct().ToList();
            var menu = from c in men1
                       join m in me on c equals m.category.category_Name into mc
                       select new FoodSystem.p1 { name = c, value = mc };

           // TempData["selectedMenu"] = menu.ToList();
            //var menu = db.Menu.Include(m => m.category).Include(m => m.restaurant);
            return View(menu.ToList());
        }

        // GET: managermenus/Details/5
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

        // GET: managermenus/Create
        public ActionResult Create()
        {

            
            ViewBag.categoryID = new SelectList(db.Category, "categoryID", "category_Name");
            //ViewBag.restaurantID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name");
            return View();
        }

        // POST: managermenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "menuID,menu_Name,price,categoryID")] menu menu)
        {
            if (ModelState.IsValid)
            {
                int resid = getResid();
                menu.restaurantID = resid; 
                db.Menu.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.Category, "categoryID", "category_Name", menu.categoryID);
            //ViewBag.restaurantID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name", menu.restaurantID);
            return View(menu);
        }

        // GET: managermenus/Edit/5
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
          //  ViewBag.restaurantID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name", menu.restaurantID);
            return View(menu);
        }

        // POST: managermenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "menuID,menu_Name,price,categoryID")] menu menu)
        {
            if (ModelState.IsValid)
            {
                int res = getResid();
                menu.restaurantID = res;
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.Category, "categoryID", "category_Name", menu.categoryID);
            ViewBag.restaurantID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name", menu.restaurantID);
            return View(menu);
        }

        // GET: managermenus/Delete/5
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

        // POST: managermenus/Delete/5
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
