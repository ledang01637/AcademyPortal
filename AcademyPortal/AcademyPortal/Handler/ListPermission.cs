using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace AcademyPortal.Handler
{
    public class ListPermission
    {
        public int ID { get; set; }
        public string PermisstionName { get; set; }
        public static List<ListPermission> items = new List<ListPermission>();
    }
}