using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using Mis.Core.Model;

namespace Mis.Core
{
    public class UrlAuthorizeAttribute : AuthorizeAttribute
    {
        private Model checkModel;

        public Model CheckModel
        {
            get { return checkModel; }
            set { checkModel = value; }
        }

        public enum Model
        {
            All, LoginCheckOnly
        }

        public UrlAuthorizeAttribute()
        {
            checkModel = Model.All;
        }

        public UrlAuthorizeAttribute(Model checkModel)
        {
            this.checkModel = checkModel;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            MisSession session = new MisSession();
            HttpContextBase httpContextBase = filterContext.HttpContext;
            if (!session.SessionStateCheck(httpContextBase.Session))
            {
                filterContext.Result = new RedirectResult("~/Gateway/Login");
                return;
            }

            //判断验证模式
            if (checkModel.Equals(Model.All))
            {
                //have logined
                Cache cache = new Cache();
                if (httpContextBase.Session != null)
                {
                    UserCacheModel userCacheModel = cache.GetUserCache(httpContextBase.Session["UserName"].ToString());
                    Premission premission = new Premission();
                    if (userCacheModel != null)
                    {
                        if (!premission.Check(userCacheModel, httpContextBase.Request.Path))
                        {
                            filterContext.Result = new RedirectResult("~/Gateway/Login");
                            return;
                        }
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("~/Gateway/Login");
                        return;
                    }
                }
            }
        }


    }
}
