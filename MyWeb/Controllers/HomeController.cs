using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        AccountDAO dao = new AccountDAO();
        Account acc = new Account();
        // GET: Home
        BrandDAO BrandDao = new BrandDAO();
        CategoryDAO CategoryDao = new CategoryDAO();
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult checkLogin(FormCollection col)
        {
            bool isValid = true;
            string username = col["username"];
            string password = col["password"];
            if(username == null || username.Equals(""))
            {
                isValid = false;
                ViewBag.UERR = "Please input Username!";
            }
            if(username == null || username.Equals(""))
            {
                isValid = false;
                ViewBag.PERR = "Please input Password!";
            }
            if(isValid)
            {
                Account acc = dao.CheckLogin(username, password);              
                if (acc != null)
                {
                    Session["Account"] = acc;
                    return RedirectToAction("LoadList", "Phone");
                }
                else
                {
                    ViewBag.Error = "Invalid Username / Password";
                    return Index();
                }
            }
            else
            {   
                
                ViewBag.USERNAME = username;
                return Index();
            }
            
        }

        [HttpPost]
        public ActionResult Logout()
        {
            if(Session != null)
            {
                Session.Abandon();
            }
             return RedirectToAction("LoadList", "Phone");
        }

        [HttpPost]
        public ViewResult CreateAccount(FormCollection col)
        {
            return View("CreateAccount");
        }

        [HttpPost]
        public ActionResult Create(FormCollection col)
        {
            string id = col["id"];
            string password = col["password"];
            string fullname = col["fullname"];
            string phonenumber = col["phonenumber"];
            string address = col["address"];
            string dateStr = col["date"];
            DateTime date = DateTime.Parse(dateStr);
            string status = "active";
            string roleID = "2";
            Account acc = new Account(id, password, fullname, phonenumber, date, status, address, roleID);
            dao.addAccount(acc);
            return Index();
        }

        [HttpPost]
        public ViewResult ManageAccount(FormCollection col)
        {

            var model = dao.GetAllAccount();
            return View("ManageAccount", model);
        }
        [HttpPost]
        public ViewResult UpdateAccount(FormCollection col)
        {
            string id = col["id"];
            var account = dao.getAccountById(id);
            return View("UpdateAccount", account);

        }
        [HttpPost]
        public ActionResult Update(FormCollection col)
        {
            bool isValid = true;
            string id = col["id"];
            string password = col["password"];
            Account currAccount = Session["Account"] as Account;
            if(currAccount == null)
            {
                return RedirectToAction("LoadList", "Phone");
            }
            else
            {
                if (password == null)
                {
                    isValid = false;
                    ViewBag.PASSERR = "Password Can't Be Null!";
                }
                string fullname = col["fullname"];
                if (fullname == null)
                {
                    isValid = false;
                    ViewBag.NERR = "FullName Can't Be Null!";
                }
                string phonenumber = col["phonenumber"];
                if (!System.Text.RegularExpressions.Regex.IsMatch(phonenumber, "[0-9]{9}"))
                {
                    isValid = false;
                    ViewBag.PERR = "Invalid PhoneNumber!";
                }
                string address = col["address"];
                if (address == null)
                {
                    isValid = false;
                    ViewBag.AERR = "Address Can't Be Null!";
                }
                string dateStr = col["date"];
                DateTime date = DateTime.Parse(dateStr);
                if (isValid)
                {
                    dao.updateAccount(id, password, fullname, phonenumber, address, date);
                    if (currAccount.RoleID.Equals("1"))
                    {
                        return ManageAccount(col);
                    }
                    else
                    {
                        return RedirectToAction("LoadList", "Phone");
                    }


                }
                else
                {
                    return UpdateAccount(col);
                }
            }
        }
            

    }
}
