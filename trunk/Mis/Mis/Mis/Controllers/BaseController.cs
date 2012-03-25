using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mis.Core.Model;
using Mis.Core;

namespace Mis.Controllers
{
    public abstract class BaseController : Controller,IBaseController
    {
        //
        // GET: /Base/
        protected void GetPremission()
        {
            string userName = Session["UserName"].ToString();
            Cache cache=new Cache();
            UserCacheModel userCacheModel = cache.GetUserCache(userName);
            var premission = userCacheModel.PremissionList.SingleOrDefault(m => m.Controller.Equals(GetControllerName()));
            ViewData["UserPremission"] = premission;
        }

        public abstract string GetControllerName();
    }
}
