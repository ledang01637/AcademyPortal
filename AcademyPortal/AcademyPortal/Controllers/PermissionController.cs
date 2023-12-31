using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcademyPortal.Handler;
using System.Data;
using System.Globalization;

namespace AcademyPortal.Controllers
{
    public class PermissionController : Controller
    {
        public ActionResult Index()
        {
            String query = "SELECT * FROM academyportal.permission;";
            DataTable dt = DataProvider.Instance.DtExcuteQuery(query);
            Item.items.Clear();
            foreach (DataRow item in dt.Rows)
            {
                Item.items.Add(new Item()
                {
                    ID = item.Field<int>("id"),
                    UserName = item.Field<string>("permission_name").ToString()
                });
            }
            return View(Item.items);
        }
        [HttpPost]
        public ActionResult Create(string UserName)
        {
            DateTime createDate = DateTime.Now;
            String query = "INSERT INTO `academyportal`.`permission`(`permission_name`,`created_at`)VALUES('" + UserName + "','" + createDate + "')";
            int count = DataProvider.Instance.ExcuteNonQuery(query);
            if (count > 0)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Update(int ID,string UserName)
        {
            return View();
        }
    }
}