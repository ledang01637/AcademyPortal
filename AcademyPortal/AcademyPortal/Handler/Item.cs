using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyPortal.Handler
{
    public class Item
    {
        public string UserName { get; set; }
        public static List<Item> items = new List<Item>();
    }
}