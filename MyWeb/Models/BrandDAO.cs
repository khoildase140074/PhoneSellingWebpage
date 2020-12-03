using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class BrandDAO
    {
        string conn = MyConnection.Class1.getConnection();

        public List<Brand> GetAllBrands()
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            List<Brand> list = null;
            try
            {
                
                string sql = "Select * From Brand";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                list = new List<Brand>();
                while (reader.Read())
                {
                    Brand b = new Brand(reader["BrandID"].ToString(), reader["BrandName"].ToString());
                    list.Add(b);
                }
            }
            catch (Exception e)
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
            return list;

        }
    }
}