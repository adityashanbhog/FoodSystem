using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSystem.Controllers
{
    public class MiddleController : Controller
    {
        // GET: Middle
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Manager"))
            {
                return RedirectToAction("Index", "managermenus");
            }
            else if (User.IsInRole("Customer"))
            {
                return RedirectToAction("Index", "showhotel");
            }
            else if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "adminhomepage");
            }
            else
            {
                return View();
            }
        }
    }
}