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

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = true;
            //check user is in session(user have logined)
            MisSession session = new MisSession();
            if (!session.SessionStateCheck(httpContext.Session))
            {
                result = false;
            }
            //check authorize model(loginOnly,all)
            if (checkModel.Equals(Model.All))
            {
                //have logined
                Cache cache = new Cache();
                if (httpContext.Session != null&&httpContext.Session["UserName"]!=null)
                {
                    UserCacheModel userCacheModel = cache.GetUserCache(httpContext.Session["UserName"].ToString());
                    Premission premission = new Premission();
                    if (userCacheModel != null)
                    {
                        //check premission
                        if (!premission.Check(userCacheModel, httpContext.Request.Path))
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                filterContext.Result = new RedirectResult("~/Gateway/Login");
                return;
            }
        }


    }
}
