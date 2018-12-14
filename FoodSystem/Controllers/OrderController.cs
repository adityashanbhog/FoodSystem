using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSystem.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult submit()
        {
            Model1 m1 = new Model1();
            var username1 = User.Identity.Name;
            var idselect = from c in m1.Customer
                           where c.customer_Name == username1
                           select c;
            var abc = idselect.FirstOrDefault();
            int d2 = abc.customerID;

            Models.order o = new Models.order();
          //  o.orderID = ;
            o.customerID = d2;
            db.Order.Add(o);
            db.SaveChanges();

            var o2 = from o1 in db.Order
                     where o1.orderID == o.orderID
                     select o1;
            var odr = o2.ToList().FirstOrDefault();
            var x = (IEnumerable<p1>)TempData["selectedMenu"];
            List<Models.detail> d1 = new List<Models.detail>();

            int sum = 0;
            foreach (p1 i in x)
            {
                foreach (var j in i.value)
                {

                    if (Request[j.menu_Name].ToString() != "0")
                    {
                        Models.detail d = new Models.detail();
                        d.name = j.menu_Name;
                        d.price = Int32.Parse(j.price);
                        d.quantity = Int32.Parse(Request[j.menu_Name]);
                        d.order = odr;
                       // d.order.orderID = o.orderID;
                        db.Detail.Add(d);
                        db.SaveChanges();
                        d1.Add(d);
                        sum += (d.quantity * d.price);
                        ViewBag.total = sum;
                        Session["amount"] = sum;
                        // o.details.Add(d);
                    }
                }
            }
            //ICollection<db.Detail>
            //   o.details.Add(d);
            odr.details = d1;
            //db.Order.U(o);
            db.SaveChanges();
            Session["oid"] = odr.orderID;
            var order = from oo in db.Order
                        where oo.orderID == o.orderID
                        select new p2 { detail = oo.details };

            var a1 = order.ToList();
            TempData["re"] = "true";
            return View(a1);
        }
        
    }
   
   
}