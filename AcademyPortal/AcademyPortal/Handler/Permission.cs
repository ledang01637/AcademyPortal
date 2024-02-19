using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyPortal.Handler
{
    public class Permission
    {
        public int roleID { get; set; }
        public string permissionName { get; set; }
        public string roleName { get; set; }

        public static List<Permission> permissions = new List<Permission>();
    }
}