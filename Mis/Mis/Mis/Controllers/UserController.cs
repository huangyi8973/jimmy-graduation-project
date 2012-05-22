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
    public class UserController : BaseController
    {
        //
        // GET: /User/
        [UrlAuthorize]
        public ActionResult Index()
        {
            UserBll userBll = new UserBll();
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
            if (vm != null)
            {
                UserBll userBll = new UserBll();
                userBll.Add(vm);

            }
            return RedirectToAction("Index");
        }

        [UrlAuthorize]
        public ActionResult Edit(int id)
        {
            UserViewModel vm = null;
            RoleBll roleBll = new RoleBll();
            List<RoleViewModel> roleViewModels = roleBll.GetList();
            if (id > 0)
            {
                UserBll userBll = new UserBll();
                //获取用户信息的ViewModel
                vm = userBll.GetModel(id);
                //用户保存角色选项
                List<SelectListItem> items = new List<SelectListItem>();
                //遍历角色
                foreach (var roleVm in roleViewModels)
                {
                    SelectListItem item = null;
                    //如果当前的角色是用户所拥有的，就把selected设为true
                    if (vm.RoleIds.Contains(roleVm.RoleId))
                    {
                        item = new SelectListItem
                            {
                                Text = roleVm.RoleName,
                                Value = roleVm.RoleId.ToString(),
                                Selected = true
                            };
                    }
                    else
                    {
                        item = new SelectListItem
                            {
                                Text = roleVm.RoleName,
                                Value = roleVm.RoleId.ToString(),
                                Selected = false
                            };
                    }
                    items.Add(item);
                }

                //roleSelectList = new SelectList(items);
                ViewData["RoleList"] = items;
                return View(vm);
            }
            ViewData["RoleList"] = GetRoleList();
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

        public JsonResult InitUserPassword(int userId)
        {
            UserBll userBll=new UserBll();
            bool result = false;
            if(userId>0)
            {
                result = userBll.initUserPassword(userId);
            }
            return Json(result);
        }

        public override string GetControllerName()
        {
            return "user";
        }
    }
}
