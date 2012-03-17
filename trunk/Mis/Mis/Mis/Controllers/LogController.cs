using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mis.Core;
using Mis.Core.Bll;

namespace Mis.Controllers
{
    public class LogController :BaseController
    {
        //
        // GET: /Log/
        [UrlAuthorize]
        public ActionResult Index()
        {
            LogBll bll=new LogBll();
            GetPremission();
            ViewData["LogList"] = bll.GetList();
            return View();
        }

        [UrlAuthorize]
        [Logging]
        public ActionResult Del()
        {
            LogBll bll=new LogBll();
            bll.Clean();
            return RedirectToAction("Index");
        }



        public override string GetControllerName()
        {
            return "log";
        }

    }
}
