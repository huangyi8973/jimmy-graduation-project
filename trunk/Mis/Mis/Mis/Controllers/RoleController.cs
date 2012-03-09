using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mis.Core.Bll;
using Mis.Core.Entity;
using Mis.Core.Model;
using Mis.Core;

namespace Mis.Controllers
{
    [HandleError]
    public class RoleController : BaseController, IBaseController
    {
        //
        // GET: /Role/

        public ActionResult Index()
        {
            RoleBll roleBll = new RoleBll();
            ViewData["RoleList"] = roleBll.GetList();
            GetPremission();
            GetRoleToResourcePremission();
            return View();
        }


        private void GetRoleToResourcePremission()
        {
            string userName = Session["UserName"].ToString();
            Cache cache = new Cache();
            UserCacheModel userCacheModel = cache.GetUserCache(userName);
            var premission = userCacheModel.PremissionList.SingleOrDefault(m => m.Controller.Equals("premission"));
            ViewData["RRPremission"] = premission;
        }

        //
        // GET: /Role/Create
        [UrlAuthorize]
        public ActionResult Add()
        {
            return View();
        }

        //
        // POST: /Role/Add
        [UrlAuthorize]
        [HttpPost]
        public ActionResult Add(RoleViewModel vm)
        {
            try
            {
                RoleBll roleBll = new RoleBll();
                roleBll.Add(vm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Role/Edit/5
        [UrlAuthorize]
        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                RoleBll roleBll = new RoleBll();
                var vm = roleBll.GetModel(id);
                return View(vm);
            }
            return RedirectToAction("Index");

        }

        //
        // POST: /Role/Edit/5
        [UrlAuthorize]
        [HttpPost]
        public ActionResult Edit(RoleViewModel vm)
        {
            try
            {
                RoleBll roleBll = new RoleBll();
                roleBll.Update(vm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Role/Delete/5
        [UrlAuthorize]
        public RedirectToRouteResult Del(int id)
        {
            if (id > 0)
            {
                RoleBll roleBll = new RoleBll();
                roleBll.Del(id);
            }
            return RedirectToAction("Index");
        }
        public override string GetControllerName()
        {
            return "user";
        }


    }
}
