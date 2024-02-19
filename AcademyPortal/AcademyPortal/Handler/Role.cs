using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyPortal.Handler
{
    public class Role
    {
        public int roleID { get; set; }
        public int permissionID { get; set; }
        public string roleName { get; set; }
        
        public static List<Role> roles = new List<Role>();
    }
}