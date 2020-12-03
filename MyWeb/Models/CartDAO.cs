using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyConnection;
using MyWeb.Objects;
using System.Data.SqlClient;

namespace MyWeb.Models
{
    public class CartDAO
    {
        string stringConn = MyConnection.Class1.getConnection();

        
        public List<OrderDetail> GetListDetail()
        {
            SqlConnection conn = new SqlConnection(stringConn);
            List<OrderDetail> list = null;
            
            try
            {
                
                string sql = "Select DetailID, IDProduct, Quantity, Price, CartID From CartDetail";
                SqlCommand comm = new SqlCommand(sql, conn);
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


        public List<Order> GetAllCarts()
        {
            List<Order> list = null;
            SqlConnection conn = new SqlConnection(stringConn);
            try
            {
                
                string sql = "Select CartID, CartName, Username, CreatedDate, Status, Payment, Address, Total From Cart";
                SqlCommand comm = new SqlCommand(sql, conn);
                list = new List<Order>();
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order(reader["CartID"].ToString(), reader["CartName"].ToString(), reader["Username"].ToString(), Convert.ToDateTime(reader["CreatedDate"].ToString()),reader["Status"].ToString(), reader["Payment"].ToString(), reader["Address"].ToString(), Convert.ToInt32(reader["Total"]));
                    list.Add(order);
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

        public bool AddCart(Order order)
        {
            SqlConnection conn = new SqlConnection(stringConn);
            try
            {
                string sql = "Insert Into Cart Values(@ID, @Name, @Username, @Created, @Status, @Payment, @Address, @Total)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ID", order.CartID);
                comm.Parameters.AddWithValue("@Name", order.CartName);
                comm.Parameters.AddWithValue("@Username", order.Username);
                comm.Parameters.AddWithValue("@Created", order.CreatedDate);
                comm.Parameters.AddWithValue("@Status", order.Status);
                comm.Parameters.AddWithValue("@Payment", order.Payment);
                comm.Parameters.AddWithValue("@Address", order.Address);
                comm.Parameters.AddWithValue("@Total", order.Total);
                if(conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                return comm.ExecuteNonQuery() > 0;

            }
            catch (Exception)
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
        }


        public bool AddOrder(OrderDetail detail)
        {
            SqlConnection conn = new SqlConnection(stringConn);
            try
            {
                string sql = "Insert Into CartDetail (IDProduct, Quantity, Price, CartID) Values(@Pro, @Quantity, @Price, @CartID)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@Pro", detail.IDProduct);
                comm.Parameters.AddWithValue("@Quantity", detail.Quantity);
                comm.Parameters.AddWithValue("@Price", detail.Price);
                comm.Parameters.AddWithValue("@CartID", detail.CartID);
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                return comm.ExecuteNonQuery() > 0;

            }
            catch (Exception)
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
        }
    }
}