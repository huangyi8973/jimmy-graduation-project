using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mis.Core.Bll;
using Mis.Core;
using Mis.Core.Entity;
using Mis.Core.Model;


namespace Mis.Controllers
{
    [HandleError]
    public class UserController : BaseController,IBaseController
    {
        //
        // GET: /User/
        [UrlAuthorize]
        public ActionResult Index()
        {
            UserBll userBll=new UserBll();
            ViewData["UserList"] = userBll.GetList();
            GetPremission();
            return View();
        }

        [UrlAuthorize]
        public ActionResult Add()
        {
            ViewData["RoleList"] = GetRoleList();
            return View();
        }

        [UrlAuthorize]
        [HttpPost]
        public RedirectToRouteResult Add(UserViewModel vm)
        {
            if(vm!=null)
            {
                UserBll userBll=new UserBll();
                userBll.Add(vm);
                
            }
            return RedirectToAction("Index");
        }

        [UrlAuthorize]
        public ActionResult Edit(int id)
        {
            UserViewModel vm = null;
            ViewData["RoleList"] = GetRoleList();
            if (id > 0)
            {
                UserBll userBll = new UserBll();
                vm = userBll.GetModel(id);
                return View(vm);
            }

            return View(new UserViewModel());
        }

        private IEnumerable<SelectListItem> GetRoleList()
        {
            RoleBll roleBll = new RoleBll();
            List<RoleViewModel> roleEntities = roleBll.GetList();
            var roleSelectList = from role in roleEntities
                                 select new SelectListItem
                                 {
                                     Text = role.RoleName,
                                     Value = role.RoleId.ToString()
                                 };
            return roleSelectList;
        }

        [UrlAuthorize]
        [HttpPost]
        public RedirectToRouteResult Edit(UserViewModel vm)
        {
            UserBll userBll = new UserBll();
            if (vm != null)
            {
                userBll.Update(vm);
            }
            return RedirectToAction("Index");
        }

        [UrlAuthorize]
        public RedirectToRouteResult Del(int userId)
        {

            UserBll userBll = new UserBll();
            userBll.Del(userId);
            return RedirectToAction("Index");
        }


        public override string GetControllerName()
        {
            return "user";
        }
    }
}
