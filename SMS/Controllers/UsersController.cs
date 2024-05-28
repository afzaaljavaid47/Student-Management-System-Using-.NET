using SMS.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SMS.Controllers
{
    [AllowAnonymous]
    public class UsersController : Controller
    {
        Operations operations = null;
        public UsersController() 
        {
            operations= new Operations();
        }
        // GET: Users
        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users user)
        {
            if (ModelState.IsValid)
            {
                if (operations.ValidateUser(user))
                {
                    FormsAuthentication.SetAuthCookie(user.username, false);
                    return RedirectToAction("List", "Student");
                }
                ModelState.AddModelError("", "Invalid User name or password");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Users user)
        {
            if (ModelState.IsValid)
            {
                int id = operations.AddUser(user);
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}