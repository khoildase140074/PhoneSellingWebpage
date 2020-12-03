using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyConnection;
using System.Data;
using System.Data.SqlClient;
namespace MyWeb.Models
{
    
    public class PhoneDAO
    {
        private string conn = MyConnection.Class1.getConnection();
        public List<Product> GetAllProduct() 
        {
            List<Product> list = null;
            SqlConnection sqlConn = new SqlConnection(conn);
            try
            {
                
                string sql = "Select * From Product";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                if(sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                list = new List<Product>();
                while(reader.Read())
                {
                    Product p = new Product(reader["IDProduct"].ToString(), reader["ProductName"].ToString(), Convert.ToInt32(reader["Quantity"]), Convert.ToInt32(reader["Price"]), reader["Status"].ToString(), reader["BrandID"].ToString(), reader["CategoryID"].ToString(), reader["Image"].ToString());
                    list.Add(p);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return list;

        }


        public Product GetProductDetail(string id)
        {
            Product p = null;
            SqlConnection sqlConn = new SqlConnection(conn);
            try
            {
                
                string sql = "Select * From Product Where IDProduct = @ID";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                comm.Parameters.AddWithValue("@ID", id);
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    p = new Product(id, reader["ProductName"].ToString(), Convert.ToInt32(reader["Quantity"]), Convert.ToInt32(reader["Price"]), reader["Status"].ToString(), reader["BrandID"].ToString(), reader["CategoryID"].ToString(), reader["Image"].ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return p;

        }

        public bool UpdateProduct(Product p)
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            try
            {
                
                string sql = "Update Product Set ProductName = @Name, Quantity = @Quantity, Price = @Price, Status = @Status, BrandID = @Brand, CategoryID = @cate, Image = @Img Where  IDProduct= @ID";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                comm.Parameters.AddWithValue("@Name", p.ProductName);
                comm.Parameters.AddWithValue("@Quantity", p.Quantity);
                comm.Parameters.AddWithValue("@Price", p.Price);
                comm.Parameters.AddWithValue("@Status", p.Status);
                comm.Parameters.AddWithValue("@Brand", p.BrandID);
                comm.Parameters.AddWithValue("@cate", p.CategoryID);
                comm.Parameters.AddWithValue("@Img", p.Image);
                comm.Parameters.AddWithValue("@ID", p.IDProduct);
                if(sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                return comm.ExecuteNonQuery() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        public bool UpdateProductAfterAddCart(Product p)
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            try
            {
                
                string sql = "Update Product Set Quantity = @Quantity Where  IDProduct= @ID";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                comm.Parameters.AddWithValue("@Quantity", p.Quantity);
                comm.Parameters.AddWithValue("@ID", p.IDProduct);
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                return comm.ExecuteNonQuery() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }


        public bool AddProduct(Product p)
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            try
            {
                
                string sql = "Insert Into Product Values(@ID, @Name, @Quantity, @Price, @Status, @Brand, @cate, @Img)";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                comm.Parameters.AddWithValue("@Name", p.ProductName);
                comm.Parameters.AddWithValue("@Quantity", p.Quantity);
                comm.Parameters.AddWithValue("@Price", p.Price);
                comm.Parameters.AddWithValue("@Status", p.Status);
                comm.Parameters.AddWithValue("@Brand", p.BrandID);
                comm.Parameters.AddWithValue("@cate", p.CategoryID);
                comm.Parameters.AddWithValue("@Img", p.Image);
                comm.Parameters.AddWithValue("@ID", p.IDProduct);
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                return comm.ExecuteNonQuery() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }
        public List<Product> GetAllPhones_Search(string phoneName, string brandID, string categoryID)
        {
            List<Product> list = null;
            SqlConnection sqlConn = new SqlConnection(conn);
            try
            {
                
                string sql = "Select * From Product p Where p.ProductName LIKE @PhoneName and p.BrandID LIKE @BrandID and p.CategoryID LIKE @CategoryID";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                comm.Parameters.AddWithValue("@PhoneName", "%" + phoneName + "%");
                comm.Parameters.AddWithValue("@BrandID", "%" + brandID + "%");
                comm.Parameters.AddWithValue("@CategoryID", "%" + categoryID + "%");
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                list = new List<Product>();
                while (reader.Read())
                {
                    Product p = new Product(reader["IDProduct"].ToString(), reader["ProductName"].ToString(), Convert.ToInt32(reader["Quantity"]), Convert.ToInt32(reader["Price"]), reader["Status"].ToString(), reader["BrandID"].ToString(), reader["CategoryID"].ToString(), reader["Image"].ToString());
                    list.Add(p);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return list;

        }
    }
}