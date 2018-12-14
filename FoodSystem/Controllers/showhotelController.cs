using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;

namespace FoodSystem.Controllers
{
    [Authorize(Roles = "Customer")]
    public class showhotelController : Controller
    {
        // GET: showhotel
        private Model1 db = new Model1();

        // GET: showhotel
        public ActionResult Index()
        {
            var hotel = db.Restaurant;
            return View(hotel.ToList());
        }

        public ActionResult menu(int? id)
        {
            var x = (Request["resid"]);
            if (x == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int d = Int32.Parse(Request["resid"]);
            var res = from r in db.Restaurant
                      where r.restaurantID == d
                      select new { rname = r.restaurant_Name };
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

            TempData["selectedMenu"] = menu.ToList();

            //foreach(var i in menu)
            //{
            //    System.Diagnostics.Debug.WriteLine("name is "+i.name);
            //    System.Diagnostics.Debug.WriteLine("value is "+i.value);
            //    foreach (var ii in i.value)
            //    {
            //        if(ii.menu_Name=="")
            //            System.Diagnostics.Debug.WriteLine("null");
            //        else
            //            System.Diagnostics.Debug.WriteLine(ii.menu_Name);
            //    }
            //}


            if (menu == null)
            {
                return HttpNotFound();
            }

            return View(menu.ToList());

        }

    }
}