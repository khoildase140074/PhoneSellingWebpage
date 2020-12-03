using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Product
    {
        public string IDProduct { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string BrandID { get; set; }
        public string CategoryID { get; set; }
        public string Image { get; set; }

        public Product(string iDProduct, string productName, int quantity, int price, string status, string brandID, string categoryID, string Image)
        {
            IDProduct = iDProduct;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Status = status;
            BrandID = brandID;
            CategoryID = categoryID;
            this.Image = Image;
        }

        public Product(string iDProduct, int quantity)
        {
            IDProduct = iDProduct;
            Quantity = quantity;
        }

        public Product()
        {
        }
    }
}