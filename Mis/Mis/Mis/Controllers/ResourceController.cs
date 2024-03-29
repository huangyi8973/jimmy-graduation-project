﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mis.Core;
using Mis.Core.Bll;
using Mis.Core.Model;
using Mis.Core.Entity;

namespace Mis.Controllers
{
    public class ResourceController :BaseController
    {
        //
        // GET: /Resource/
        
        public ActionResult Index()
        {
            ResourceBll bll = new ResourceBll();
            ViewData["ResourceList"]= bll.GetList();
            GetPremission();
            return View();
        }


        //
        // GET: /Resource/Create
        [UrlAuthorize]
        public ActionResult Add()
        {
            return View();
        }

        //
        // POST: /Resource/Create
        [UrlAuthorize]
        [HttpPost]
        [Logging]
        public ActionResult Add(ResourceViewModel vm)
        {
            try
            {
                ResourceBll bll = new ResourceBll();
                bll.Add(vm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Resource/Edit/5
        [UrlAuthorize]
        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                ResourceBll bll = new ResourceBll();
                ResourceViewModel vm = bll.GetModel(id);
                return View(vm);
            }
            return RedirectToAction("Index");

        }

        //
        // POST: /Resource/Edit/5
        [UrlAuthorize]
        [HttpPost]
        [Logging]
        public ActionResult Edit(ResourceViewModel vm)
        {
            try
            {
                ResourceBll bll=new ResourceBll();
                bll.Update(vm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Resource/Delete/5
        [UrlAuthorize]
        [Logging]
        public RedirectToRouteResult Del(int id)
        {
            if (id > 0)
            {
                ResourceBll bll = new ResourceBll();
                bll.Del(id);
            }
            return RedirectToAction("Index");
        }

        public override string GetControllerName()
        {
            return "resource";
        }

    }
}
