using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Cau1.DAL
{
    public class QlbhDAL:DBConnection
    {
        public List<QlbhBEL> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            //SqlCommand cmd = new SqlCommand("select * from  CongNo", conn);
            //SqlDataReader reader = cmd.ExecuteReader();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select_CongNo";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();


            List<QlbhBEL> lstCus = new List<QlbhBEL>();
            
            while (reader.Read())
            {
                QlbhBEL cus = new QlbhBEL();
                cus.Id = int.Parse(reader["makhachhang"].ToString());
                cus.Name = reader["tenkhachhang"].ToString();
                cus.PhoneNumber= int.Parse(reader["sodienthoai"].ToString());
                cus.MS = decimal.Parse(reader["sotienno"].ToString());
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }

        public void EditCustomer(QlbhBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            //SqlCommand cmd = new SqlCommand("update CongNo set tenkhachhang=@tenkhachhang, sodienthoai=@sodienthoai, sotienno=@sotienno where makhachhang=@makhachhang", conn);
            //cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.Id));
            //cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.Name));
            //cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.PhoneNumber));
            //cmd.Parameters.Add(new SqlParameter("@sotienno", cus.MS));
            //cmd.ExecuteNonQuery();
            //conn.Close();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UpdateItem";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = cus.Id;
                cmd.Parameters.Add("@tenkhachhang", SqlDbType.NVarChar).Value = cus.Name;
                cmd.Parameters.Add("@sodienthoai", SqlDbType.NVarChar).Value = cus.PhoneNumber;
                cmd.Parameters.Add("@sotienno", SqlDbType.Decimal).Value = cus.MS;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Sửa thành công !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Có lỗi, hãy kiểm tra lại  !!!" + e);
            }

            finally
            {
                conn.Close();
            }
        }    
    public void DeleteCustomer(QlbhBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            //SqlCommand cmd = new SqlCommand("delete from CongNo where makhachhang=@makhachhang", conn);
            //cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.Id));
            //cmd.ExecuteNonQuery();
            //conn.Close();

            try
            {

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "DeleteItem";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = cus.Id;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Xoá thành công !!!");
            }
            catch (Exception e){   
                Console.WriteLine("Có lỗi, hãy kiểm tra lại !!!" + e);
            }

            finally{
                conn.Close();
            }
        }
        public void NewCustomer(QlbhBEL cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            //SqlCommand cmd = new SqlCommand("insert into CongNo values (@makhachhang,@tenkhachhang,@sodienthoai,@sotienno)", conn);
            //cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.Id));
            //cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.Name));
            //cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.PhoneNumber));
            //cmd.Parameters.Add(new SqlParameter("@sotienno", cus.MS));

            //cmd.ExecuteNonQuery();
            //conn.Close();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "InsertItem";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = cus.Id;
                cmd.Parameters.Add("@tenkhachhang", SqlDbType.NVarChar).Value = cus.Name;
                cmd.Parameters.Add("@sodienthoai", SqlDbType.NVarChar).Value = cus.PhoneNumber;
                cmd.Parameters.Add("@sotienno", SqlDbType.Decimal).Value = cus.MS;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Thêm thành công !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Có lỗi, hãy kiểm tra lại !!!" + e);
            }

            finally
            {
                conn.Close();
            }
        }

    }

}
