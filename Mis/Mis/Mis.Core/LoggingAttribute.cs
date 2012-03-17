using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Mis.Core.Dal;
using Mis.Core.Entity;

namespace Mis.Core
{
    public class LoggingAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogDao logDao=new LogDao();
            LogEntity entity=new LogEntity();
            entity.LogTime = DateTime.Now;
            entity.Message = this.Log(filterContext.RouteData);
            entity.UserName = filterContext.HttpContext.Session["UserName"].ToString();
            logDao.Add(entity);
        }
        private string Log(RouteData routeData)
        {
            return string.Format("controller:{0},action:{1}", routeData.Values["controller"], routeData.Values["action"]);

        }
    }
}
