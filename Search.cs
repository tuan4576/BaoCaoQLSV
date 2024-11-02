using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhVien
{
    public partial class Search : Form
    {
        private string connString = "Server=localhost;Database=qlsinhvien;User Id=root;Password=;";
        public Search()
        {
            InitializeComponent();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            // Lấy từ khóa từ textBox1
            string keyword = textBox1.Text;

            // Chuỗi truy vấn SQL
            string query = "SELECT student_code, name, birth_year, major, class, gender, batch, email, password " +
                           "FROM users " +
                           "WHERE student_code LIKE @keyword OR name LIKE @keyword";

            // Kết nối đến database và thực hiện truy vấn
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Thêm tham số vào truy vấn
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        // Đổ dữ liệu vào DataTable
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Kiểm tra kết quả tìm kiếm
                        if (dt.Rows.Count == 0)
                        {
                            // Hiển thị thông báo nếu không tìm thấy sinh viên
                            MessageBox.Show("Sinh viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.DataSource = null; // Xóa dữ liệu hiện có trong dataGridView1 nếu cần
                        }
                        else
                        {
                            // Hiển thị dữ liệu lên dataGridView1 nếu có kết quả
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu không phải là số và không phải là phím xóa (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Ngăn không cho ký tự hiển thị trong textBox1
                e.Handled = true;
            }
        }

    }
}
