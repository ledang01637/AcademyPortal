using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyPortal.Handler
{
    public class KeyRolePermission
    {
       public int Key { get; set; }
       public string nameKey { get; set; }

       public static List<KeyRolePermission> listKey = new List<KeyRolePermission>();
    }
}