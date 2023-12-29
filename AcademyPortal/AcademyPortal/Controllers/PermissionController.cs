using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcademyPortal.Handler;

namespace AcademyPortal.Controllers
{
    public class PermissionController : Controller
    {
        public ActionResult Index(string UserName)
        {
            Item.items.Add(new Item()
            {
                UserName = UserName
            });
            return View(Item.items);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SavePermission()
        {

            return RedirectToAction("Index");
        }
    }
}