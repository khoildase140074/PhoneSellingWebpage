using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class AccountDAO
    {
        private string conn = MyConnection.Class1.getConnection();
        

        public Account CheckLogin(string username, string password)
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            Account a = null;
            try
            {
                
                string sql = "Select FullName, PhoneNumber, DateOfBirth, Status, Address, RoleID From Account Where Username=@Username AND Password=@Password";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                comm.Parameters.AddWithValue("@Username", username);
                comm.Parameters.AddWithValue("@Password", password);
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    a = new Account(username, reader["FullName"].ToString(), reader["PhoneNumber"].ToString(), Convert.ToDateTime(reader["DateOfBirth"]), reader["Status"].ToString(), reader["Address"].ToString(), reader["RoleID"].ToString());
                }
            }
            catch (Exception e)
            {

                throw;
            }finally
            {
                if(sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return a;
        }


        public List<Account> GetAllAccount()
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            List<Account> list = null;
            try
            {
                
                String sql = "Select * From Account";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                list = new List<Account>();
                while (reader.Read())
                {
                    Account a = new Account(reader["Username"].ToString(), reader["FullName"].ToString(), reader["PhoneNumber"].ToString(), Convert.ToDateTime(reader["DateOfBirth"]), reader["Status"].ToString(), reader["Address"].ToString(), reader["RoleID"].ToString());
                    list.Add(a);
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

        public bool updateAccount(string username, string password, string fullname, string phonenumber, string address, DateTime date)
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            try
            {
                
                string sql = "Update Account Set Password = @Password, Fullname = @Fullname, PhoneNumber = @PhoneNumber, Address = @Address, DateOfBirth = @DateOfBirth From Account Where Username = @Username";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                comm.Parameters.AddWithValue("@Password", password);
                comm.Parameters.AddWithValue("@Fullname", fullname);
                comm.Parameters.AddWithValue("@PhoneNumber", phonenumber);
                comm.Parameters.AddWithValue("@Address", address);
                comm.Parameters.AddWithValue("@Username", username);
                comm.Parameters.AddWithValue("@DateOfBirth", date);
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
        public Account getAccountById(string username)
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            Account a = null;
            try
            {
                string sql = "Select Username,FullName, PhoneNumber, DateOfBirth, Status, Address, RoleID From Account Where Username=@Username";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                comm.Parameters.AddWithValue("@Username", username);
                if (sqlConn.State == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    a = new Account(username, reader["FullName"].ToString(), reader["PhoneNumber"].ToString(), Convert.ToDateTime(reader["DateOfBirth"]), reader["Status"].ToString(), reader["Address"].ToString(), reader["RoleID"].ToString());
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
            return a;
        }

        public bool addAccount(Account a)
        {
            SqlConnection sqlConn = new SqlConnection(conn);
            try
            {
                
                string sql = "Insert Into Account Values(@Username,@Password,@FullName,@PhoneNumber,@Address,@DateOfBirth,@Status,@RoleID)";
                SqlCommand comm = new SqlCommand(sql, sqlConn);
                comm.Parameters.AddWithValue("@Username", a.Username);
                comm.Parameters.AddWithValue("@Password", a.Password);
                comm.Parameters.AddWithValue("@FullName", a.FullName);
                comm.Parameters.AddWithValue("@PhoneNumber", a.PhoneNumber);
                comm.Parameters.AddWithValue("@Address", a.Address);
                comm.Parameters.AddWithValue("@DateOfBirth", a.DateOfBirth);
                comm.Parameters.AddWithValue("@Status", a.Status);
                comm.Parameters.AddWithValue("@RoleID", a.RoleID);
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
    }
}
