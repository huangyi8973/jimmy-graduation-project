using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mis.Core;
using Mis.Core.Model;

namespace Mis.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [UrlAuthorize(CheckModel = UrlAuthorizeAttribute.Model.LoginCheckOnly)]
        public ActionResult Index()
        {
            
            return View();
        }


    }

}
