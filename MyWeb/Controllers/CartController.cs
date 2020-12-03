using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;
using MyWeb.Objects;

namespace MyWeb.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        
        public ActionResult Index()
        {       
            return View();
        }
        OrderDAO dao = new OrderDAO();
        [HttpPost]
        public ActionResult ViewOrder(FormCollection col)
        {
            String username = col["txtUsername"];
            List<Order> model = dao.GetAllCartID(username);
            return View("ViewOrder", model);
        }
        [HttpPost]
        public ActionResult ManageOrder()
        {
            List<Order> model = dao.GetAllCartID_ADMIN();          
            return View("ManageOrder", model);
        }
        [HttpPost]
        public ActionResult SearchOrder(FormCollection col)
        {
            string cartName = col["txtSearch"];
            List<Order> model = dao.GetAllCartID_ADMINSearch(cartName);
            return View("ManageOrder", model);
        }
        [HttpPost]
        public ActionResult SearchOrderBrand(FormCollection col)
        {
            string brandID = col["brandID"];
            List<Order> model = dao.GetAllCartID_ADMIN_Brand(brandID);
            return View("ManageOrder", model);
        }
        [HttpPost]
        public ActionResult SearchOrderCategory(FormCollection col)
        {
            string categoryID = col["categoryID"];
            List<Order> model = dao.GetAllCartID_ADMIN_Category(categoryID);
            return View("ManageOrder", model);
        }
        [HttpPost]
        public ActionResult ManageOrderDetail(FormCollection col)
        {
            string cartID = col["cartID"];
            List<OrderDetail> model = dao.GetListOrderWithCartID_ADMIN(cartID);
            return View("ManageOrderDetail", model);
        }
        [HttpPost]
        public ActionResult AddToCart(FormCollection col)
        {
            string productID = col["id"];
            int price = Convert.ToInt32(col["price"]);
            
            Order cart = Session["CART"] as Order;
            Account acc = Session["Account"] as Account;
            CartDAO cartDao = new CartDAO();
            List<Order> cartList = cartDao.GetAllCarts();
            string idCart = (cartList.Count + 1).ToString();

            if (cart == null)
            {
                
                string address = col["address"];
                string cartName = "Cart of " + acc.FullName;
                string payment = "COD";
                string paymentStatus = "Waiting";
                cart = new Order(idCart, cartName, acc.Username, DateTime.Now, paymentStatus, payment, address, 1);
            }
            
            List<OrderDetail> OrderList = cart.detailList;
            bool isFound = false;
            for (int i = 0; i < OrderList.Count; i++)
            {
                if(OrderList[i].IDProduct.Equals(productID))
                {
                    OrderList[i].Quantity += 1;
                    isFound = true;
                }
            }
            if(!isFound)
            {
                OrderDetail detail = new OrderDetail(productID, idCart, 1, price);
                cart.detailList.Add(detail);
            }
            int total = 0;
            for(int i = 0; i < cart.detailList.Count; i++)
            {
                total += (cart.detailList[i].Price * cart.detailList[i].Quantity);
            }
            cart.Total = total;
            Session["CART"] = cart;

            return Redirect( Url.Action("GetDetail1", "Phone", new { id = productID }));
        }

        [HttpPost]
        public ActionResult ViewCart()
        {
            return View("ViewCart");
        }

        [HttpPost]
        public ActionResult DeleteDetail(FormCollection col)
        {
            string id = col["id"];
            Order cart = Session["CART"] as Order;
            for (int i = 0; i < cart.detailList.Count; i++)
            {
                if (cart.detailList[i].IDProduct.Equals(id))
                {
                    cart.detailList.Remove(cart.detailList[i]);
                }
            }
            int total = 0;
            for (int i = 0; i < cart.detailList.Count; i++)
            {
                total += (cart.detailList[i].Price * cart.detailList[i].Quantity);
            }
            cart.Total = total;
            Session["CART"] = cart;
            return View("ViewCart");
        }

        [HttpPost]
        public ActionResult UpdateQuantity(FormCollection col)
        {
            string id = col["id"];
            string quantity = col["quantity"];
            Order cart = Session["CART"] as Order;
            PhoneDAO dao = new PhoneDAO();
            bool isEnough = true;
            string name = "bủh";
            for(int i = 0; i < cart.detailList.Count; i++)
            {
                if(cart.detailList[i].IDProduct.Equals(id))
                {
                    if(cart.detailList[i].Quantity > dao.GetProductDetail(cart.detailList[i].IDProduct).Quantity)
                    {
                        isEnough = false;
                        name = cart.detailList[i].ProductName;
                    }
                }
            }
            if(!isEnough)
            {
                ViewBag.INSUFF = "There is not enough quantity of " + name + " for you! Please choose another products or decrease the amount!";
            }
            else
            {
                for(int i = 0; i < cart.detailList.Count; i++)
                {
                    if(cart.detailList[i].IDProduct.Equals(id))
                    {
                        cart.detailList[i].Quantity = Convert.ToInt32(quantity);
                    }
                }
                int total = 0;
                for (int i = 0; i < cart.detailList.Count; i++)
                {
                    total += (cart.detailList[i].Price * cart.detailList[i].Quantity);
                }
                cart.Total = total;
                Session["CART"] = cart;     
            }

            return View("ViewCart");

        }

        [HttpPost]
        public ActionResult ConfirmCart()
        {
            Order cart = Session["CART"] as Order;
            PhoneDAO dao = new PhoneDAO();
            bool isEnough = true;
            string name = "bủh";
            CartDAO cartDAO = new CartDAO();
            for (int i = 0; i < cart.detailList.Count; i++)
            {
                    if (cart.detailList[i].Quantity > dao.GetProductDetail(cart.detailList[i].IDProduct).Quantity)
                    {
                        isEnough = false;
                        name = cart.detailList[i].ProductName;
                    }
            }
            if (!isEnough)
            {
                ViewBag.INSUFF = "There is not enough quantity of " + name + " for you! Please choose another products or decrease the amount!";
                return View("ViewCart");
            }
            else
            {
                bool isCartOk = cartDAO.AddCart(cart);
                PhoneDAO phoneDao = new PhoneDAO();
                bool isAllOk = true;
                if(isCartOk)
                {
                    bool[] isDetailsOk = new bool[cart.detailList.Count];
                    bool[] isUpdateOk = new bool[cart.detailList.Count];
                    for(int i = 0; i < isDetailsOk.Length; i++)
                    {
                        isDetailsOk[i] = cartDAO.AddOrder(cart.detailList[i]);
                    }
                    for (int i = 0; i < isDetailsOk.Length; i++)
                    {
                        Product p = new Product(cart.detailList[i].IDProduct, cart.detailList[i].Store - cart.detailList[i].Quantity);
                        isUpdateOk[i] = phoneDao.UpdateProductAfterAddCart(p);
                    }
                    for (int i = 0; i < isDetailsOk.Length; i++)
                    {
                        if(!isDetailsOk[i])
                        {
                            isAllOk = false;
                        }
                    }
                    for (int i = 0; i < isUpdateOk.Length; i++)
                    {
                        if (!isUpdateOk[i])
                        {
                            isAllOk = false;
                        }
                    }
                    if (!isAllOk)
                    {
                        return Redirect(Url.Action("Error", "Phone"));
                    }
                    else
                    {
                        Session.Remove("CART");
                        return Redirect(Url.Action("LoadList", "Phone"));
                    }
                }
                else
                {
                    return Redirect(Url.Action("Error", "Phone"));
                }
            }
        }

        

    }
}