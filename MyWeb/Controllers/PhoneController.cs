using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class PhoneController : Controller
    {
        PhoneDAO dao = new PhoneDAO();
        BrandDAO dao_Brand = new BrandDAO();
        CategoryDAO dao_Category = new CategoryDAO();
        // GET: Phone
        public ActionResult Index()
        {

            return RedirectToAction("LoadList");
        }

        public ViewResult LoadList()
        {
            int page_Size = 20;
            List<Product> ProList = dao.GetAllProduct();
            string current_P = Request["page"];
            if (current_P == null)
            {
                current_P = "1";
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(current_P, "[0-9]{1,5}"))
            {
                current_P = "1";
            }
            if (current_P.Equals("0"))
            {
                current_P = "1";
            }
            int totalRecord = ProList.Count;

            int total_Page = 1;

            if (totalRecord % page_Size == 0)
            {
                total_Page = totalRecord / page_Size;
            }
            else
            {
                total_Page = (totalRecord / page_Size) + 1;
            }
            if (int.Parse(current_P) > total_Page)
            {
                current_P = "1";
            }
            int current_Page = int.Parse(current_P);
            List<Product> current_List = new List<Product>();
            for (int i = (current_Page - 1) * page_Size; i < (current_Page * page_Size); i++)
            {
                if (i == totalRecord)
                {
                    break;
                }
                else
                {
                    current_List.Add(ProList[i]);
                }
            }
            var model = current_List;
            List<Brand> brand = dao_Brand.GetAllBrands();
            Session["Brand"] = brand;
            List<Category> category = dao_Category.GetAllCategories();
            Session["Category"] = category;
            Session["Page"] = total_Page;
            return View("LoadList", model);
        }

        [HttpPost]
        public ViewResult GetDetail(FormCollection col)
        {
            string id = col["id"];
            var product = dao.GetProductDetail(id);
            ViewBag.ID = id;
            return View("GetDetail", product);

        }

        public ViewResult GetDetailByBanner()
        {
            string id = Request["id"];
            if (id == null)
            {
                id = "1";
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(id, "[0-9]{1,5}"))
            {
                id = "1";
            }
            if (id.Equals("0"))
            {
                id = "1";
            }
            var product = dao.GetProductDetail(id);
            ViewBag.ID = id;
            return View("GetDetail", product);

        }

        public ViewResult GetDetail1(string id)
        {

            var product = dao.GetProductDetail(id);
            ViewBag.ID = id;
            return View("GetDetail", product);

        }

        [HttpPost]
        public ViewResult Edit(FormCollection col)
        {
            string id = col["id"];
            var product = dao.GetProductDetail(id);
            var cateList = dao_Category.GetAllCategories();
            var brandList = dao_Brand.GetAllBrands();
            ViewBag.CateList = cateList;
            ViewBag.BrandList = brandList;

            return View("Edit", product);
        }

        public ViewResult Error(FormCollection col)
        {

            return View();

        }


        [HttpPost]
        public ActionResult Update(FormCollection col)
        {
            bool isValid = true;
            string id = col["id"];
            string name = col["name"];
            if (name == null || name.Equals(""))
            {
                isValid = false;
                ViewBag.NERR = "Invalid name!";
            }
            string priceString = col["price"];
            if (!System.Text.RegularExpressions.Regex.IsMatch(priceString, "[0-9]{1,15}"))
            {
                isValid = false;
                ViewBag.PERR = "Invalid Price!";
            }
            string quantityString = col["quantity"];
            if (!System.Text.RegularExpressions.Regex.IsMatch(quantityString, "[0-9]{1,7}"))
            {
                isValid = false;
                ViewBag.QERR = "Invalid Quantity!";
            }
            string status = col["status"];
            string cateID = col["category"];
            string brandID = col["brand"];
            string img = col["img"];
            if (img == null || img.Equals(""))
            {
                img = "https://previews.123rf.com/images/doomko/doomko1508/doomko150800003/43683599-fun-mobile-phone-cartoon-with-thumbs-up.jpg";
            }
            if (isValid)
            {
                Product p = new Product(id, name, Convert.ToInt32(quantityString), Convert.ToInt32(priceString), status, brandID, cateID, img);
                bool isOk = dao.UpdateProduct(p);
                if (isOk)
                {
                    return GetDetail(col);
                }
                else
                {
                    ViewBag.Error = "Update Failed!";
                    return RedirectToAction("Error");
                }
            }
            else
            {
                return Edit(col);
            }

        }
        [HttpPost]
        public ViewResult CreatePhone(FormCollection col)
        {
            var cateList = dao_Category.GetAllCategories();
            var brandList = dao_Brand.GetAllBrands();
            ViewBag.CateList = cateList;
            ViewBag.BrandList = brandList;
            return View("CreatePhone");
        }

        [HttpPost]
        public ActionResult AddPhone(FormCollection col)
        {
            bool isValid = true;
            string id = (dao.GetAllProduct().Count + 1).ToString();
            string name = col["name"];
            if (name == null || name.Equals(""))
            {
                isValid = false;
                ViewBag.NERR = "Invalid name!";
            }
            string priceString = col["price"];
            if (!System.Text.RegularExpressions.Regex.IsMatch(priceString, "[0-9]{1,15}"))
            {
                isValid = false;
                ViewBag.PERR = "Invalid Price!";
            }
            string quantityString = col["quantity"];
            if (!System.Text.RegularExpressions.Regex.IsMatch(quantityString, "[0-9]{1,7}"))
            {
                isValid = false;
                ViewBag.QERR = "Invalid Quantity!";
            }
            string status = col["status"];
            string cateID = col["category"];
            string brandID = col["brand"];
            string img = col["img"];
            if (img == null || img.Equals(""))
            {
                img = "https://previews.123rf.com/images/doomko/doomko1508/doomko150800003/43683599-fun-mobile-phone-cartoon-with-thumbs-up.jpg";
            }
            if (isValid)
            {
                Product p = new Product(id, name, Convert.ToInt32(quantityString), Convert.ToInt32(priceString), status, brandID, cateID, img);
                bool isOk = dao.AddProduct(p);
                if (isOk)
                {
                    return LoadList();
                }
                else
                {
                    ViewBag.Error = "Create Failed!";
                    return RedirectToAction("Error");
                }
            }
            else
            {
                ViewBag.Name = name;
                ViewBag.Price = priceString;
                ViewBag.Quantity = quantityString;
                ViewBag.Image = img;
                return CreatePhone(col);
            }
        }
        public ActionResult SearchPhone(FormCollection col)
        {
            string phoneName = col["txtSearch"];
            string brandID = col["txtBrandID"];
            string categoryID = col["txtCategoryID"];
            List<Product> model = dao.GetAllPhones_Search(phoneName, brandID, categoryID);
            return View("LoadList", model);
        }


    }
}