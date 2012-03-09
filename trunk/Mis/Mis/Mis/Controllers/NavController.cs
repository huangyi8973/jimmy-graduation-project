using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mis.Core;
using Mis.Core.Model;

namespace Mis.Controllers
{
    public class NavController : Controller
    {
        //
        // GET: /Nav/
        //[UrlAuthorize]
        [ChildActionOnly]
        public ActionResult Index()
        {
            Cache cache = new Cache();
            UserCacheModel userCacheModel = null;
            if (null != Session["UserName"])
            {
                userCacheModel = cache.GetUserCache(Session["UserName"].ToString());
            }
            return PartialView(userCacheModel);
        }

    }
}
