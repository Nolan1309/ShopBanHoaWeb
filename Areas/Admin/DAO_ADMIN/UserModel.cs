using Dapper;
using PagedList;
using ShopBanHoa.Areas.Admin.Models;
using ShopBanHoa.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBanHoa.Areas.Admin.DAO_ADMIN
{
    public class UserModel
    {
        List<User> itemUser = new List<User>();
        DataConnection db = new DataConnection();
        public IPagedList<Account> GetAccount(int page ,int pageSize)
        {
            IPagedList<Account> pagedList;
            using (SqlConnection connection = db.sqlstring())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAccount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var accountsList = new List<Account>();
                        while (reader.Read())
                        {
                            var account = new Account();
                            account.FullName = reader["FullName"].ToString();
                            account.Email = reader["Email"].ToString();                       
                            account.Phone = reader["Phone"].ToString();
                            account.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                            accountsList.Add(account);
                        }
                        pagedList = accountsList.ToPagedList(page, pageSize);
                    }
                }
            }
            return pagedList;
        }
        public IPagedList<Account> GetAccountSearch(string searchstring, int page, int pageSize)
        {
            IPagedList<Account> pagedList;
            using (SqlConnection connection = db.sqlstring())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAccountSearch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@search", searchstring);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var accountsList = new List<Account>();
                        while (reader.Read())
                        {
                            var account = new Account();
                            account.FullName = reader["FullName"].ToString();
                            account.Email = reader["Email"].ToString();
                            account.Phone = reader["Phone"].ToString();
                            account.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                            accountsList.Add(account);
                        }
                        pagedList = accountsList.ToPagedList(page, pageSize);
                    }
                }
            }
            return pagedList;
        }
        //public User GetAccount(int accountID)
        //{
        //    User user = null;

        //    using (SqlConnection connection = db.sqlstring())
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand("sp_GetAccount", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;

        //            command.Parameters.AddWithValue("@AccountID", accountID);

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    user = new User
        //                    {
        //                        AccountID = (int)reader["AccountID"],
        //                        TaiKhoan = (string)reader["TaiKhoan"],
        //                        MatKhau = (string)reader["MatKhau"],
        //                        Phone = (string)reader["Phone"],
        //                        Email = (string)reader["Email"],
        //                        FullName = (string)reader["FullName"]

        //                    };
        //                }
        //            }
        //        }
        //    }

        //    return user;
        //}
        public int Insert(User user)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = db.sqlstring())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_AddAccount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TaiKhoan", user.TaiKhoan);
                    command.Parameters.AddWithValue("@MatKhau", user.MatKhau);
                    command.Parameters.AddWithValue("@Phone", user.Phone);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@FullName", user.FullName);


                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
        public int UpdateAccount(User user)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = db.sqlstring())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_UpdateAccount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AccountID", user.AccountID);
                    command.Parameters.AddWithValue("@TaiKhoan", user.TaiKhoan);
                    command.Parameters.AddWithValue("@MatKhau", user.MatKhau);
                    command.Parameters.AddWithValue("@Phone", user.Phone);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@FullName", user.FullName);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
        public int DeleteAccount(User accountID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = db.sqlstring())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_DeleteAccount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AccountID", accountID.AccountID);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }



    }
}