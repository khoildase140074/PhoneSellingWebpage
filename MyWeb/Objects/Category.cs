using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Category
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

        public Category(string categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }

        public Category()
        {
        }
    }
}