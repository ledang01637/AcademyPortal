
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyPortal.Handler
{
    public class ListRole
    {
        public int ID { get; set; }
        public string roleName { get; set; }
        public static List<ListRole> roles = new List<ListRole>();
    }
}