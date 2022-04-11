using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SHOPPINGCARTPROJECT.Models;

namespace SHOPPINGCARTPROJECT.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users model) 
        {
            var context = new ShoppingCartDbEntities();
            
                bool valid=context.User.Any(x=>x.EmailId==model.EmailId&&x.Password==model.Password);
                if (valid)
                {
                    var x=context.User.Single(m => m.EmailId == model.EmailId);
                    Session["Id"] = x.Id.ToString();
                    FormsAuthentication.SetAuthCookie(model.EmailId, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid EmailId Or password");
                return View();
            
                
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUp model)
        {

            using (var context=new ShoppingCartDbEntities())
            {
                User user = new User
                {
                    FullName = model.FullName,
                    MobileNumber = model.MobileNumber,
                    RoleId = 1,
                    EmailId = model.EmailId,
                    Gender = model.Gender,
                    Password = model.Password
                };
                //user.Id = model.Id;
                context.User.Add(user);

                context.SaveChanges();
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}