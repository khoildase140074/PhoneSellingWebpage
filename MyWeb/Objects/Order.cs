using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Objects
{
    public class Order
    {
        public string CartID { get; set; }
        public string CartName { get; set; }
        public string Username { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string Payment { get; set; }
        public string Address { get; set; }
        public int Total { get; set; }
        public List<OrderDetail> detailList { get; set; }
        public string DateGet { get; set; }


        public Order(string cartID, string cartName, string username, DateTime createdDate, string status, string payment, string address, int total)
        {
            CartID = cartID;
            CartName = cartName;
            Username = username;
            CreatedDate = createdDate;
            Status = status;
            Payment = payment;
            Address = address;
            detailList = new List<OrderDetail>();
            DateGet = createdDate.ToString("dd/MM/yyyy");
            Total = total;
        }

        public Order(string cartName, string username, DateTime createdDate, string status, string payment, string address, int total)
        {
            CartName = cartName;
            Username = username;
            CreatedDate = createdDate;
            Status = status;
            Payment = payment;
            Address = address;
            detailList = new List<OrderDetail>();
            Total = total;
        }

        public Order()
        {
            detailList = new List<OrderDetail>();
        }
    }
}