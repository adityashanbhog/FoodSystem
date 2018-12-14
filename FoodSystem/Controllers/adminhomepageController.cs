using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSystem.Controllers
{
    public class adminhomepageController : Controller
    {
        // GET: adminhomepage
        public ActionResult Index()
        {
            return View();
        }
    }
}