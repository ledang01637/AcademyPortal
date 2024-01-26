using AcademyPortal.Handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace AcademyPortal.Controllers
{
    public class RoleController : Controller
    {
        public ActionResult Index()
        {
            String query = "SELECT * FROM academyportal.permission WHERE is_deleted = 0;";
            DataTable dt = DataProvider.Instance.DtExcuteQuery(query);
            ListPermission.items.Clear();
            foreach (DataRow item in dt.Rows)
            {
                ListPermission.items.Add(new ListPermission()
                {
                    ID = item.Field<int>("id"),
                    PermisstionName = item.Field<string>("permission_name").ToString()
                });
            }
            String query1 = "SELECT * FROM academyportal.role WHERE is_deleted = 0 ";
            DataTable dt1 = DataProvider.Instance.DtExcuteQuery(query1);
            ListRole.roles.Clear();
            foreach (DataRow item in dt1.Rows)
            {
                ListRole.roles.Add(new ListRole()
                {
                    ID = item.Field<int>("id"),
                    roleName = item.Field<string>("name").ToString()
                });
            }
            String query2 = "select role_permission.id,role.name,permission_name from permission inner join role_permission on role_permission.permission_id = permission.id inner join role on role.id = role_permission.role_id; ";
            DataTable dt2 = DataProvider.Instance.DtExcuteQuery(query2);
            foreach(var item in dt2.Rows)
            {
                string a = item.ToString();
            }
            RolePermission rolePermission = new RolePermission();
            rolePermission.listRoles = ListRole.roles;
            rolePermission.listPermissions = ListPermission.items;

            return View(rolePermission);
        }
        [HttpPost]
        public ActionResult CreateRolePermission(string[] permissionName_, string roleName_)
        {
            DateTime createDate = DateTime.Now;

            var arrayPermissionName = permissionName_;
            string roleName = roleName_;
            int idRole = 0;
            if (arrayPermissionName != null && roleName != null)
            {
                string query0 = "INSERT INTO `academyportal`.`role`(`name`,`is_deleted`,`created_at`) VALUES ('" + roleName + "', " + 0 + ", '" + createDate + "')";
                int count = DataProvider.Instance.ExcuteNonQuery(query0);
                if(count > 0)
                {
                    String query1 = "SELECT id FROM `academyportal`.`role` WHERE name like '" + roleName + "'";
                    DataTable dt1 = DataProvider.Instance.DtExcuteQuery(query1);
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt1.Rows)
                        {
                            idRole = row.Field<int>("id");
                        }
                    }
                }
                foreach (var item in arrayPermissionName)
                {
                    String query = "SELECT id FROM `academyportal`.`permission` WHERE permission_name like '" + item + "'";
                    DataTable dt = DataProvider.Instance.DtExcuteQuery(query);
                    foreach (DataRow row in dt.Rows)
                    {
                        idPermission.permissionID.Add(row.Field<int>("id"));
                    }
                }
                if(idRole > 0 && idPermission.permissionID.Count > 0)
                {
                    foreach (var item in idPermission.permissionID)
                    {
                        string query3 = "INSERT INTO `academyportal`.`role_permission` (`role_id`,`permission_id`,`created_at`) VALUES (" + idRole + ", " + item + ", '" + createDate + "')";
                        DataProvider.Instance.ExcuteNonQuery(query3);
                    }
                }   
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveView(string[] permissionName_,string roleName_)
        {
            return View();
        }
    }
}