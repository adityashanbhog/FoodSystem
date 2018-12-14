using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSystem.Controllers
{
    [Authorize(Roles = "Customer")]
    public class past_recordController : Controller
    {
        // GET: past_record
        private Model1 db = new Model1();
        public ActionResult Index()
        {

            var cus1 = User.Identity.Name;
            var cid1 = from c in db.Customer
                       where c.customer_Name == cus1
                       select c.customerID;
            //Session["cus"] = 2;
            int cid = cid1.ToList().FirstOrDefault();
            //  int cid = Int32.Parse(Session["cus"].ToString());
            // db.Order.Find(cid);
            var cus = from c in db.Customer
                      where c.customerID == cid
                      select new p3 { order = c.orders };
            ViewBag.id = cid;
            return View(cus.ToList());

          /*  Session["cus"] = 2;
            int cid = Int32.Parse(Session["cus"].ToString());
            // db.Order.Find(cid);
            var cus = from c in db.Customer
                      where c.customerID == cid
                      select new p3 { order = c.orders };

            return View(cus.ToList());*/
        }
    }
}