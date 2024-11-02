using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace QLSinhVien
{
    // Lớp này sẽ chịu trách nhiệm kết nối với cơ sở dữ liệu và thực hiện các truy vấn.
    public class DatabaseHelper
    {
        private string connString = "Server=localhost;Database=qlsinhvien;User Id=root;Password=;";

        // Phương thức mở kết nối và trả về MySqlConnection
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }

        // Phương thức để lấy dữ liệu từ bảng users
        public MySqlDataReader GetCustomerData()
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users", conn);
            return cmd.ExecuteReader();
        }

        // Phương thức để kiểm tra đăng nhập và lấy role_id
        public int? CheckLogin(string studentCode, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT role_id FROM users WHERE student_code = @student_code AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@student_code", studentCode);
                cmd.Parameters.AddWithValue("@password", password);

                object result = cmd.ExecuteScalar();
                return result != null ? (int?)Convert.ToInt32(result) : null;
            }
        }


    }
}
