using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using FoodSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace FoodSystem.Controllers
{
    
    [Authorize(Roles ="Admin")]
    public class AddManagerController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AddManagerController()
        {
        }

        public AddManagerController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;

        }



        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }





        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/Register
        
        public ActionResult Register()
        {
            Model1 db = new Model1();
            ViewBag.managerID = new SelectList(db.Restaurant, "restaurantID", "restaurant_Name");
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(managertemp model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.registerviewmodel.UserName, Email = model.registerviewmodel.Email };
                var result = await UserManager.CreateAsync(user, model.registerviewmodel.Password);
                if (result.Succeeded)
                {
                    ApplicationDbContext context = new ApplicationDbContext();
                    // await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    var userStore = new UserStore<ApplicationUser>(context);
                    var UserManager = new UserManager<ApplicationUser>(userStore);
                    UserManager.AddToRole(user.Id, "Manager");
                    manager m = new manager();
                    m.manager_Name = model.registerviewmodel.UserName;
                    m.email = model.registerviewmodel.Email;
                     var aa=Request["managerID"];
                    m.managerID = Int32.Parse(aa);
                    Model1 m1 = new Model1();
                    m1.Manager.Add(m);
                    m1.SaveChanges();
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "AddManager");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }





        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

    }
}