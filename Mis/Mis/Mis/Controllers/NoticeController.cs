using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mis.Core.Bll;
using Mis.Core;
using Mis.Core.Model;

namespace Mis.Controllers
{
    public class NoticeController : BaseController
    {
        [UrlAuthorize]
        public ActionResult Index()
        {
            NoticeBll noticeBll=new NoticeBll();
            ViewData["NoticeList"] = noticeBll.GetList();
            GetPremission();
            return View();
        }

        [UrlAuthorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [UrlAuthorize]
        public RedirectToRouteResult Add(NoticeViewModel vm)
        {
            NoticeBll noticeBll=new NoticeBll();
            vm.UserName = Session["UserName"].ToString();
            vm.CreateTime = DateTime.Now.ToString();
            noticeBll.Add(vm);
            return RedirectToAction("Index");
        }


        [UrlAuthorize]
        public RedirectToRouteResult Del(int id)
        {
            NoticeBll noticeBll=new NoticeBll();
            noticeBll.Del(id);
            return RedirectToAction("Index");
        }
        
        [UrlAuthorize]
        public ActionResult Detail(int id)
        {
            NoticeBll noticeBll=new NoticeBll();
            var vm = noticeBll.GetModel(id);
            return View(vm);
        }


        public override string GetControllerName()
        {
            return "notice";
        }

    }
}
