using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string RoleID { get; set; }
        public string DOB { get; set; }

        public string DOBEditing { get; set; }

        public Account(string username, string fullName, string phoneNumber, DateTime dateOfBirth, string status, string address, string roleID)
        {
            Username = username;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Status = status;
            Address = address;
            RoleID = roleID;
            DOB = dateOfBirth.ToString("dd/MM/yyyy");
            DOBEditing = dateOfBirth.ToString("yyyy-MM-dd");
        }

        public Account(string username, string password, string fullName, string phoneNumber, DateTime dateOfBirth, string status, string address, string roleID)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Status = status;
            Address = address;
            RoleID = roleID;
        }

        public Account()
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}