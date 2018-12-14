using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSystem.Controllers
{
    [Authorize(Roles = "Customer")]
    public class billController : Controller
    {
        // GET: bill
        Model1 db = new Model1();
        public ActionResult Index()
        {
            var aa = TempData["re"];
            if (aa == null)
            {
                //ViewBag.ErrorMessage = "Not Valid Request";
                return RedirectToAction("Error");
            }
            else
            {
                Models.bill b = new Models.bill();
                int s = Int32.Parse(Session["oid"].ToString());
                // var o = (Models.order)TempData["oid"];
                //int s = o.orderID;
                var oo = from o1 in db.Order
                         where o1.orderID == s
                         select o1;
                var odr = oo.ToList().FirstOrDefault();
                b.order = odr;
                b.amount = Int32.Parse(Session["amount"].ToString());
                b.paymentmode = "CASH";
                db.Bill.Add(b);
                Models.bill bill = db.Bill.Find(b.billID);
                db.SaveChanges();
                return View(bill);
            }
        }
        public ActionResult Error()
        {
            return View();
        }

    }
   
}