using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace AcademyPortal.Handler
{
    public class Item
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public static List<Item> items = new List<Item>();
    }
}