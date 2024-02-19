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
            //Permission
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

            //Role
            String query2 = "select role.id,role.name from academyportal.role_permission inner join academyportal.role on academyportal.role.id = academyportal.role_permission.role_id group by role.id";
            DataTable dt2 = DataProvider.Instance.DtExcuteQuery(query2);
            ListRole.roles.Clear();
            if (dt2.Rows.Count > 0)
            {
                foreach (DataRow key in dt2.Rows)
                {
                    KeyRolePermission.listKey.Add(new KeyRolePermission() 
                    {
                        Key = key.Field<int>("id"),
                        nameKey = key.Field<string>("name")
                    });
                }
            }

            //RolePermission
            String query3 = "select * from academyportal.role_permission";
            DataTable dt3 = DataProvider.Instance.DtExcuteQuery(query3);
            Role.roles.Clear();
            //GetRole in RolePermission
            foreach (var item in KeyRolePermission.listKey)
            {
                foreach(DataRow data in dt3.Rows)
                {
                    if(item.Key == data.Field<int>("role_id"))
                    {
                        Role.roles.Add(new Role() {
                        
                            roleID = item.Key,
                            roleName = item.nameKey,
                            permissionID = data.Field<int>("permission_id")
                        });
                    }
                }
            }

            //GetPermission in RolePermission
            
            foreach (var item in Role.roles)
            {
                foreach(var item1 in ListPermission.items)
                {
                    if(item.permissionID == item1.ID)
                    {
                        Permission.permissions.Add(new Permission()
                        {
                            roleID = item.roleID,
                            roleName = item.roleName,
                            permissionName = item1.PermisstionName
                        });
                    }
                }
            }

            var roleID = Permission.permissions.GroupBy(
                         a => a.roleID,
                         a => a.permissionName, 
                         (key, g) => new { roleID = key, permissionName = g.ToList()});

            //GroupByRoleName
            RolePermission.listRolePermissions.Clear();
            foreach (var item in roleID)
            {
                foreach(var item1 in KeyRolePermission.listKey)
                {
                    if(item.roleID == item1.Key)
                    {
                        RolePermission.listRolePermissions.Add(new RolePermission()
                        {
                            roleID = item.roleID,
                            roleName = item1.nameKey,
                            permissionName = item.permissionName
                        });
                    }
                }
            }

            ViewRolePermission view = new ViewRolePermission();
            view.listPermissions = ListPermission.items;
            view.rolePermissions = RolePermission.listRolePermissions;
            return View(view);
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
                IDPermission.permissionID.Clear();
                foreach (var item in arrayPermissionName)
                {
                    String query = "SELECT id FROM `academyportal`.`permission` WHERE permission_name like '" + item + "'";
                    DataTable dt = DataProvider.Instance.DtExcuteQuery(query);
                    foreach (DataRow row in dt.Rows)
                    {
                        IDPermission.permissionID.Add(row.Field<int>("id"));
                    }
                }
                if(idRole > 0 && IDPermission.permissionID.Count > 0)
                {
                    foreach (var item in IDPermission.permissionID)
                    {
                        string query3 = "INSERT INTO `academyportal`.`role_permission` (`role_id`,`permission_id`,`created_at`) VALUES (" + idRole + ", " + item + ", '" + createDate + "')";
                        DataProvider.Instance.ExcuteNonQuery(query3);
                    }
                }   
            }
            return RedirectToAction("Index");
        }
    }
}