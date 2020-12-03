using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Role
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }

        public Role(string roleID, string roleName)
        {
            RoleID = roleID;
            RoleName = roleName;
        }

        public Role()
        {
        }
    }
}