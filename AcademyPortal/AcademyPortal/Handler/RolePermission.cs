using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyPortal.Handler
{
    public class RolePermission
    {
        public int Id { get; set; }
        public string roleName { get; set; }
        public string permissionName { get; set; }
        public static List<RolePermission> rolePermissions = new List<RolePermission>();
        public List<ListRole> listRoles { get; set; }
        public List<ListPermission> listPermissions { get; set; }
    }
}