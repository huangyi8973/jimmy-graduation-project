using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mis.Core.Bll;
using Mis.Core.Model;
using Mis.Core;

namespace Mis.Controllers
{
    public class PremissionController : BaseController
    {
        //
        // GET: /RoleToResource/
        [UrlAuthorize]
        public ActionResult Index(int roleId)
        {
            RoleBll roleBll = new RoleBll();
            ResourceBll resourceBll = new ResourceBll();
            GetPremission();
            ViewData["RoleInfo"] = roleBll.GetModel(roleId);
            ViewData["PremissionList"] = resourceBll.GetPremissionByRoleId(roleId);
            GetPremission();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id">角色ID</param>
        /// <returns></returns>
        [UrlAuthorize]
        public ActionResult Add(int Id)
        {
            ResourceBll rBll = new ResourceBll();
            ViewData["ResourceItems"] = rBll.GetResourceWithoutRoleId(Id).Select(m => new SelectListItem
                                                                                  {
                                                                                      Text = m.ResourceName,
                                                                                      Value = m.Id.ToString()
                                                                                  });
            return View(new RoleToResourceViewModel { RoleId = Id });
        }

        [Logging]
        [UrlAuthorize]
        [HttpPost]
        public RedirectToRouteResult Add(RoleToResourceViewModel vm)
        {
            ResourceBll resourceBll = new ResourceBll();
            resourceBll.PremissionAdd(vm);
            return RedirectToAction("Index", new { roleId = vm.RoleId });
        }

        [UrlAuthorize]
        [Logging]
        public RedirectToRouteResult Del(int id)
        {
            ResourceBll resourceBll = new ResourceBll();
            int roleId = resourceBll.GetPremissionModel(id).RoleId;
            resourceBll.PremissionDel(id);
            return RedirectToAction("Index", new { roleId = roleId });
        }

        [UrlAuthorize]
        public ActionResult Edit(int id)
        {
            ResourceBll resourceBll = new ResourceBll();
            var vm = resourceBll.GetPremissionViewModelById(id);
            return View(vm);
        }

        [HttpPost]
        [Logging]
        [UrlAuthorize]
        public RedirectToRouteResult Edit(RoleToResourceViewModel vm)
        {
            ResourceBll resourceBll = new ResourceBll();
            resourceBll.PremissionUpdate(vm);
            return RedirectToAction("Index", new { roleId = vm.RoleId });
        }

        public override string GetControllerName()
        {
            return "premission";
        }
    }
}
