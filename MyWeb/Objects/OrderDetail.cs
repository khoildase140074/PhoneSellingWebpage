using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Objects
{
    public class OrderDetail
    {
        PhoneDAO dao = new PhoneDAO();
        public string DetailID { get; set; }
        public string IDProduct { get; set; }
        public string ProductName { get => dao.GetProductDetail(IDProduct).ProductName;}
        public string CartID { get; set; }
        public int Quantity { get; set; }
        public int Price { get ; set; }
        public int Store { get => dao.GetProductDetail(IDProduct).Quantity; }


        public OrderDetail(string detailID, string iDProduct, string cartID, int quantity, int price)
        {
            DetailID = detailID;
            IDProduct = iDProduct;
            CartID = cartID;
            Quantity = quantity;
            Price = price;
        }

        public OrderDetail(string iDProduct, string cartID, int quantity, int price)
        {
            IDProduct = iDProduct;
            CartID = cartID;
            Quantity = quantity;
            Price = price;
        }

        public OrderDetail()
        {
        }
    }
}