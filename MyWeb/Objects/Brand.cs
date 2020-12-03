using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Brand
    {
        public string BrandID { get; set; }
        public string BrandName { get; set; }

        public Brand(string brandID, string brandName)
        {
            BrandID = brandID;
            BrandName = brandName;
        }

        public Brand()
        {
        }
    }
}