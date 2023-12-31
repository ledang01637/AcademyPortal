using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AcademyPortal.Handler
{
    public class DataProvider
    {
        private static DataProvider instance; //Ctr + R + E // Đóng gói
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set => instance = value;
        }
        private DataProvider() { } //hàm tạo không tham số

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        private String Connet = @"Data Source=.;Server = localhost;port=3306;Initial Catalog=AcademyPortal;uid=root;password=ap";
        //"Data Source=.;Initial Catalog = AcademyPortal; Integrated Security = SSPI"

        //Trả về 1 DataTable
        public DataTable DtExcuteQuery(String query)
        {
            using (MySqlConnection Msqlconn = new MySqlConnection(Connet))
            {
                Msqlconn.Open();

                MySqlCommand command = new MySqlCommand(query, Msqlconn);
                MySqlDataAdapter msda = new MySqlDataAdapter(command);
                dt.Clear();
                msda.Fill(dt);
                Msqlconn.Close();
                return dt;
            }
        }
        //Trả về 1 tập hợp các DataTable
        public DataSet DsExcuteQuery(String query)
        {
            using (MySqlConnection Msqlconn = new MySqlConnection(Connet))
            {
                Msqlconn.Open();

                MySqlCommand command = new MySqlCommand(query, Msqlconn);
                MySqlDataAdapter sda = new MySqlDataAdapter(command);

                //Đổi tên Table
                sda.TableMappings.Add("Table", "");
                sda.TableMappings.Add("Table1", "");
                ds.Clear();
                sda.Fill(ds);
                Msqlconn.Close();
                return ds;
            }
        }
        //Trả về số dòng thực thi
        public int ExcuteNonQuery(String query)
        {
            int data = 1;
            using (MySqlConnection Msqlconn = new MySqlConnection(Connet))
            {
                Msqlconn.Open();

                MySqlCommand command = new MySqlCommand(query, Msqlconn);
                MySqlDataAdapter sda = new MySqlDataAdapter(command);
                data = command.ExecuteNonQuery();
                Msqlconn.Close();
                return data;
            }
        }
        //Trả về ô đầu của kết quả // VD: Select Count(*) From...
        public object ExcuteScalar(String query)
        {
            object data = 0;
            using (MySqlConnection Msqlconn = new MySqlConnection(Connet))
            {
                Msqlconn.Open();

                MySqlCommand command = new MySqlCommand(query, Msqlconn);
                MySqlDataAdapter sda = new MySqlDataAdapter(command);
                sda.Fill(dt);
                //sda.Fill(ds.Tables["DangNhap"]);

                data = command.ExecuteScalar();
                Msqlconn.Close();
                return data;
            }
        }
    }
}