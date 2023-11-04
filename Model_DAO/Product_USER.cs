using ShopBanHoa.Areas.Admin.Models;
using ShopBanHoa.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopBanHoa.Model_DAO
{
    
    public class Product_USER
    {
        DataConnection db = new DataConnection();
        public List<Product> GetAccountList()
        {
            Product sp = null;
            List<Product> listds = new List<Product>();
            using (SqlConnection connection = db.sqlstring())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("select * from SanPham", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sp = new Product();

                            sp.MaSP = Convert.ToInt32(reader["MaSP"]);
                            sp.MaDM = Convert.ToInt32(reader["MaDM"]);
                            sp.TenSP = reader["TenSP"].ToString();
                            sp.AnhSP = reader["AnhSP"].ToString();
                            sp.GiaSP = Convert.ToInt32(reader["GiaSP"]);
                            sp.TrangThai = Convert.ToInt32(reader["TrangThai"]);

                            //sp.BestSeller = Convert.ToInt32(reader["BestSeller"]);
                           
                            DateTime dateTime = Convert.ToDateTime(reader["CreateDate"]);
                            sp.CreateDate = dateTime.Date;
                            DateTime dateTime1 = Convert.ToDateTime(reader["NgaySua"]);
                            sp.NgaySua = dateTime1.Date;
                            sp.MotaSP = reader["MotaSP"].ToString();
                            sp.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                            listds.Add(sp);
                        }
                    }
                }
            }

            return listds; ;
        }
    }
    
}