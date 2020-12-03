using MyWeb.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class OrderDAO
    {
        string stringConn = MyConnection.Class1.getConnection();

        public List<OrderDetail> GetListOrderWithCartID(string cartID)
        {
            List<OrderDetail> list = null;
            SqlConnection conn = new SqlConnection(stringConn);
            try
            {

                string sql = "Select DetailID, IDProduct, Quantity, Price, CartID From CartDetail Where CartID = @cartID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@cartID", cartID);
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    OrderDetail detail = new OrderDetail(reader["DetailID"].ToString(), reader["IDProduct"].ToString(), reader["CartID"].ToString(), Convert.ToInt32(reader["Quantity"]), Convert.ToInt32(reader["Price"]));
                    list.Add(detail);
                }

            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return list;
        }


        public List<Order> GetAllCartID(string username)
        {
            List<Order> listCart = null;
            SqlConnection conn = new SqlConnection(stringConn);
            try
            {

                string sql = "Select CartID, CartName, Username, CreatedDate, Status, Payment, Address, Total From Cart Where Username LIKE @Username";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@Username", "%" + username + "%");
                listCart = new List<Order>();
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order(reader["CartID"].ToString(), reader["CartName"].ToString(), reader["Username"].ToString(), Convert.ToDateTime(reader["CreatedDate"].ToString()), reader["Status"].ToString(), reader["Payment"].ToString(), reader["Address"].ToString(), Convert.ToInt32(reader["Total"]));
                    listCart.Add(order);
                }

            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return listCart;
        }

        public List<OrderDetail> GetListOrderWithCartID_ADMIN(string cartID)
        {
            List<OrderDetail> list = null;
            SqlConnection conn = new SqlConnection(stringConn);
            try
            {

                string sql = "Select DetailID, IDProduct, Quantity, Price, CartID From CartDetail Where CartID = @cartID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@cartID", cartID);
                list = new List<OrderDetail>();
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    OrderDetail detail = new OrderDetail(reader["DetailID"].ToString(), reader["IDProduct"].ToString(), reader["CartID"].ToString(), Convert.ToInt32(reader["Quantity"]), Convert.ToInt32(reader["Price"]));
                    list.Add(detail);
                }

            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return list;
        }


        public List<Order> GetAllCartID_ADMIN()
        {
            List<Order> listCart = null;
            SqlConnection conn = new SqlConnection(stringConn);
            try
            {

                string sql = "Select CartID, CartName, Username, CreatedDate, Status, Payment, Address, Total From Cart";
                SqlCommand comm = new SqlCommand(sql, conn);
                listCart = new List<Order>();
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order(reader["CartID"].ToString(), reader["CartName"].ToString(), reader["Username"].ToString(), Convert.ToDateTime(reader["CreatedDate"].ToString()), reader["Status"].ToString(), reader["Payment"].ToString(), reader["Address"].ToString(), Convert.ToInt32(reader["Total"]));
                    listCart.Add(order);
                }

            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return listCart;
        }
        public List<Order> GetAllCartID_ADMINSearch(string cartName)
        {
            List<Order> listCart = null;
            SqlConnection conn = new SqlConnection(stringConn);
            try
            {

                string sql = "Select CartID, CartName, Username, CreatedDate, Status, Payment, Address, Total From Cart Where CartName LIKE @cartName";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@cartName", "%" + cartName + "%");
                listCart = new List<Order>();
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order(reader["CartID"].ToString(), reader["CartName"].ToString(), reader["Username"].ToString(), Convert.ToDateTime(reader["CreatedDate"].ToString()), reader["Status"].ToString(), reader["Payment"].ToString(), reader["Address"].ToString(), Convert.ToInt32(reader["Total"]));
                    listCart.Add(order);
                }

            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return listCart;
        }

        public List<Order> GetAllCartID_ADMIN_Brand(string brandID)
        {
            List<Order> listCart = null;
            SqlConnection conn = new SqlConnection(stringConn);
            try
            {

                string sql = "Select c.CartID, c.CartName, c.Username, c.CreatedDate, c.Status, c.Payment, c.Address, c.Total " + 
                                "From Cart c, CartDetail cd, Product p, Brand b " +
                                "Where c.CartID = cd.CartID " +
                                "and cd.IDProduct = p.IDProduct " +
                                "and p.BrandID = b.BrandID " + 
                                "and b.BrandID = @brandID";  
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@brandID", brandID);
                listCart = new List<Order>();
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order(reader["CartID"].ToString(), reader["CartName"].ToString(), reader["Username"].ToString(), Convert.ToDateTime(reader["CreatedDate"].ToString()), reader["Status"].ToString(), reader["Payment"].ToString(), reader["Address"].ToString(), Convert.ToInt32(reader["Total"]));
                    listCart.Add(order);
                }

            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return listCart;
        }

        public List<Order> GetAllCartID_ADMIN_Category(string categoryID)
        {
            List<Order> listCart = null;
            SqlConnection conn = new SqlConnection(stringConn);
            try
            {

                string sql = "Select c.CartID, c.CartName, c.Username, c.CreatedDate, c.Status, c.Payment, c.Address, c.Total " +
                                "From Cart c, CartDetail cd, Product p, Category ca " +
                                "Where c.CartID = cd.CartID " +
                                "and cd.IDProduct = p.IDProduct " +
                                "and p.CategoryID = ca.CategoryID " +
                                "and ca.CategoryID = @categoryID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@categoryID", categoryID);
                listCart = new List<Order>();
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order(reader["CartID"].ToString(), reader["CartName"].ToString(), reader["Username"].ToString(), Convert.ToDateTime(reader["CreatedDate"].ToString()), reader["Status"].ToString(), reader["Payment"].ToString(), reader["Address"].ToString(), Convert.ToInt32(reader["Total"]));
                    listCart.Add(order);
                }

            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return listCart;
        }
    }
}