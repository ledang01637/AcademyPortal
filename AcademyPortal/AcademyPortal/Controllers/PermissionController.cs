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
            List<Item> ListItem = new List<Item>();
            Item item = new Item();
            Item item2 = new Item();
            Item item3 = new Item();
            item.UserName = UserName;
            item2.UserName = "c";
            item3.UserName = "d";
            ListItem.Add(item);
            ListItem.Add(item2);
            ListItem.Add(item3);
            return View(ListItem);
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