﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace QLThuVien
{
    class Conn
    {
        static SqlConnection cnn;
        static SqlDataAdapter da;
        static DataSet ds;
        static SqlCommand cmd;
        static string source;

        public static void openConnection()
        {
            source = @"Data Source=LAPTOP-VAO5KEGK\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
            cnn = new SqlConnection(source);
            try
            {
                cnn.Open();
            }
            catch
            {
                MessageBox.Show("Lỗi", "Không thể kết nối đến cơ sở dữ liệu!!");
                return;
            }
        }

        public static void executeQuery(String sql)
        {
            cmd = new SqlCommand();
            openConnection();
            try
            {
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi", "Không thể thực thi câu lệnh này!!");
                return;
            }

        }

        public static DataSet getDataSet(String sql)
        {

            openConnection();
            da = new SqlDataAdapter(sql, cnn);
            ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds;
        }

        public static DataTable getDataTable(String sql)
        {
            openConnection();
            da = new SqlDataAdapter(sql, cnn);
            ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds.Tables[0];
        }
    }
}
