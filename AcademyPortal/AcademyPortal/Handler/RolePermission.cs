using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcademyPortal.Handler
{
    public class RolePermission
    {
        public int roleID { get; set; }
        public string roleName { get; set; }
        public List<string> permissionName { set; get; }

        public static List<RolePermission> listRolePermissions = new List<RolePermission>();
    }
}