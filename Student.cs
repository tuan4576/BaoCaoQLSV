using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLSinhVien
{
    public partial class Student : Form
    {
        private string studentCode;
        private string connString = "Server=localhost;Database=qlsinhvien;User Id=root;Password=;";

        public Student(string studentCode)
        {
            this.studentCode = studentCode;
            InitializeComponent();
            LoadStudentInfo();
        }

        private void LoadStudentInfo()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE student_code = @studentCode";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@studentCode", studentCode);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        tbMasv.Text = reader["student_code"].ToString();
                        tbName.Text = reader["name"].ToString();
                        tbClass.Text = reader["class"].ToString();
                        tbYear.Text = reader["birth_year"].ToString();
                        tbMajor.Text = reader["major"].ToString();
                        tbEmail.Text = reader["email"].ToString();
                        tbBatch.Text = reader["batch"].ToString();
                        tbGender.Text = reader["gender"].ToString();
                        tbPassword.Text = reader["password"].ToString();
                        string imageName = reader["photo"].ToString(); // Lấy tên ảnh
                        string fullImagePath = System.IO.Path.Combine(@"D:\1.Home\QLSinhVien\image", imageName);

                        if (System.IO.File.Exists(fullImagePath))
                        {
                            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom; // Thiết lập chế độ hiển thị là Zoom
                            pbPhoto.Image = Image.FromFile(fullImagePath); // Tải hình ảnh vào PictureBox
                        }
                        else
                        {
                            MessageBox.Show("Hình ảnh không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có sinh viên nào được chọn không
            if (string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbYear.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text)) // Kiểm tra mật khẩu
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi sửa!");
                return; // Thoát khỏi phương thức nếu có trường trống
            }

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    // Kiểm tra email trùng lặp
                    string emailCheckQuery = "SELECT COUNT(*) FROM users WHERE email = @new_email AND student_code != @student_code";
                    using (MySqlCommand emailCheckCmd = new MySqlCommand(emailCheckQuery, conn))
                    {
                        emailCheckCmd.Parameters.AddWithValue("@new_email", tbEmail.Text);
                        emailCheckCmd.Parameters.AddWithValue("@student_code", studentCode); // Tránh kiểm tra email của sinh viên hiện tại
                        int emailExists = Convert.ToInt32(emailCheckCmd.ExecuteScalar());

                        if (emailExists > 0)
                        {
                            MessageBox.Show("Email này đã tồn tại. Vui lòng sử dụng email khác!");
                            return; // Thoát khỏi phương thức nếu email đã tồn tại
                        }
                    }

                    // Cập nhật thông tin sinh viên (chỉ cập nhật tên, năm sinh, email, mật khẩu)
                    string query = "UPDATE users SET name = @name, birth_year = @birth_year, email = @new_email, password = @password " +
                                   "WHERE student_code = @student_code";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Thêm tham số từ các trường nhập liệu
                        cmd.Parameters.AddWithValue("@student_code", studentCode); // Sử dụng mã sinh viên từ combobox
                        cmd.Parameters.AddWithValue("@name", tbName.Text);
                        cmd.Parameters.AddWithValue("@birth_year", tbYear.Text);
                        cmd.Parameters.AddWithValue("@new_email", tbEmail.Text);
                        cmd.Parameters.AddWithValue("@password", tbPassword.Text); // Thêm mật khẩu mới

                        int result = cmd.ExecuteNonQuery();

                        // Kiểm tra nếu dữ liệu đã được cập nhật thành công
                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật dữ liệu thành công!");
                            LoadStudentInfo(); // Tải lại dữ liệu để hiển thị thông tin mới
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật dữ liệu thất bại!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
                }
            }
        }
        //------------------------------------


        //====================================================
        private void tbEmail_Leave(object sender, EventArgs e)
        {
            string email = tbEmail.Text;

            // Kiểm tra email phải kết thúc bằng "@gmail.com"
            if (!email.EndsWith("@gmail.com") || email.Length <= "@gmail.com".Length)
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ và phải kết thúc bằng @gmail.com");
                tbEmail.Focus(); // Đưa con trỏ trở lại TextBox
            }
        }

        private void tbYear_Leave(object sender, EventArgs e)
        {
            // Giới hạn tối đa 4 ký tự trong TextBox
            tbYear.MaxLength = 4;
            int year;

            // Định nghĩa khoảng năm hợp lệ
            int minYear = 2000;
            int maxYear = 2006;

            // Kiểm tra nếu độ dài không đủ 4 ký tự hoặc không phải số hoặc ngoài khoảng 2000 đến 2006
            if (tbYear.Text.Length != 4 ||
                !int.TryParse(tbYear.Text, out year) ||
                year < minYear ||
                year > maxYear)
            {
                MessageBox.Show($"Vui lòng nhập năm sinh từ {minYear} đến {maxYear}.");
            }
        }


        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập chữ cái và các phím điều khiển (như Backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
            }
        }
    }
}
