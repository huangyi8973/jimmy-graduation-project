using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mis.Core;
using Mis.Core.Model;

namespace Mis.Controllers
{
    [HandleError]
    public class GatewayController : Controller
    {
        //
        // GET: /Gateway/
        
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        [Logging]
        public ActionResult Login(LoginModel loginModel, string url)
        {
            Mis.Core.Login login = new Login();
            if (login.Check(loginModel))
            {
                Session["UserName"] = loginModel.UserName;
                return RedirectToAction("Index", "Home");
            }
            return View(loginModel);
        }

        public RedirectToRouteResult Logout()
        {
            MisSession session = new MisSession();
            session.RemoveUser(System.Web.HttpContext.Current.Session);
            return RedirectToAction("Login");
        }

    }
}
