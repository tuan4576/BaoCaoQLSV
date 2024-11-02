using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;
namespace QLSinhVien
{
    public partial class Home : Form
    {
        private string connString = "Server=localhost;Database=qlsinhvien;User Id=root;Password=;";

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadStudentData();
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Đặt chế độ chọn hàng
            dgvEmployee.CellClick += dgvEmployee_CellClick; // Kết nối sự kiện
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }

        private void LoadStudentData()
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    // Cập nhật truy vấn để lấy cột password
                    string query = "SELECT student_code, name, birth_year, major, class, batch, gender, email, photo, password FROM users WHERE role_id != 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán dữ liệu cho DataGridView
                    dgvEmployee.DataSource = dt;

                    // Đặt lại tên hiển thị cho các cột
                    dgvEmployee.Columns["student_code"].HeaderText = "Mã sinh viên";
                    dgvEmployee.Columns["name"].HeaderText = "Tên";
                    dgvEmployee.Columns["birth_year"].HeaderText = "Năm sinh";
                    dgvEmployee.Columns["major"].HeaderText = "Ngành";
                    dgvEmployee.Columns["class"].HeaderText = "Lớp";
                    dgvEmployee.Columns["gender"].HeaderText = "Giới tính";
                    dgvEmployee.Columns["batch"].HeaderText = "Khóa";
                    dgvEmployee.Columns["email"].HeaderText = "Email"; // Đặt tên hiển thị cho email
                    dgvEmployee.Columns["photo"].HeaderText = "Ảnh"; // Đặt tên hiển thị cho ảnh
                                                                     // Không cần hiển thị mật khẩu
                    dgvEmployee.Columns["password"].Visible = false; // Ẩn cột mật khẩu
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }



        private void btAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã sinh viên có đủ 10 số hay không
            if (tbid.Text.Length < 10)
            {
                MessageBox.Show("Mã sinh viên phải có đủ 10 số.");
                return; // Thoát khỏi phương thức nếu chưa đủ 10 số
            }

            // Kiểm tra tất cả các trường cần thiết đã được nhập hay chưa
            if (string.IsNullOrWhiteSpace(tbten.Text) ||
                string.IsNullOrWhiteSpace(tb_birth.Text) ||
                string.IsNullOrWhiteSpace(cbnganh.Text) ||
                string.IsNullOrWhiteSpace(cblop.Text) ||
                string.IsNullOrWhiteSpace(cbgioitinh.Text) ||
                string.IsNullOrWhiteSpace(cbkhoa.Text) ||
                string.IsNullOrWhiteSpace(tbemail.Text) ||
                string.IsNullOrWhiteSpace(tbpassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return; // Thoát khỏi phương thức nếu có trường thông tin còn trống
            }

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    // Kiểm tra xem mã sinh viên đã tồn tại hay chưa
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE student_code = @student_code";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@student_code", tbid.Text);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Mã sinh viên đã tồn tại. Vui lòng nhập mã sinh viên khác.");
                            return; // Thoát khỏi phương thức nếu mã sinh viên đã tồn tại
                        }
                    }

                    // Nếu mã sinh viên chưa tồn tại, tiếp tục thêm bản ghi mới
                    string query = "INSERT INTO users (student_code, name, birth_year, major, class, batch, gender, email, photo, password, role_id) " +
                                   "VALUES (@student_code, @name, @birth_year, @major, @class, @batch, @gender, @email, @photo, @password, 0)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@student_code", tbid.Text);
                        cmd.Parameters.AddWithValue("@name", tbten.Text);
                        cmd.Parameters.AddWithValue("@birth_year", tb_birth.Text);
                        cmd.Parameters.AddWithValue("@major", cbnganh.Text);
                        cmd.Parameters.AddWithValue("@class", cblop.Text);
                        cmd.Parameters.AddWithValue("@gender", cbgioitinh.Text);
                        cmd.Parameters.AddWithValue("@batch", cbkhoa.Text);
                        cmd.Parameters.AddWithValue("@email", tbemail.Text);
                        cmd.Parameters.AddWithValue("@password", tbpassword.Text);

                        // Lưu hình ảnh vào thư mục và lấy tên ảnh
                        if (pbImage.ImageLocation != null)
                        {
                            string imageName = System.IO.Path.GetFileName(pbImage.ImageLocation);
                            string destinationPath = System.IO.Path.Combine(@"D:\1.Home\QLSinhVien\image", imageName);
                            System.IO.File.Copy(pbImage.ImageLocation, destinationPath, true);
                            cmd.Parameters.AddWithValue("@photo", imageName);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@photo", DBNull.Value);
                        }

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Thêm dữ liệu thành công!");
                            LoadStudentData(); // Tải lại dữ liệu sau khi thêm

                            // Xóa các trường nhập liệu
                            tbid.Text = "";
                            tbten.Text = "";
                            tb_birth.Text = "";
                            cbnganh.SelectedIndex = -1;
                            cblop.SelectedIndex = -1;
                            cbgioitinh.SelectedIndex = -1;
                            cbkhoa.SelectedIndex = -1;
                            tbemail.Text = "";
                            tbpassword.Text = "";
                            pbImage.Image = null;
                        }
                        else
                        {
                            MessageBox.Show("Thêm dữ liệu thất bại!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"; // Cập nhật bộ lọc
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = dlg.FileName;
            }
        }


        private void btDelete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    // Kiểm tra nếu mã sinh viên tồn tại và lấy tên ảnh
                    string checkQuery = "SELECT photo FROM users WHERE student_code = @student_code";
                    string imagePath = null; // Biến để lưu tên ảnh
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@student_code", tbid.Text);
                        var result = checkCmd.ExecuteScalar();

                        if (result != null)
                        {
                            imagePath = result.ToString(); // Lưu tên ảnh
                        }
                        else
                        {
                            MessageBox.Show("Mã sinh viên không tồn tại. Vui lòng kiểm tra lại.");
                            return; // Thoát khỏi phương thức nếu mã sinh viên không tồn tại
                        }
                    }

                    // Xóa tệp ảnh nếu tồn tại
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        string fullImagePath = System.IO.Path.Combine(@"D:\1.Home\QLSinhVien\image", imagePath);
                        if (System.IO.File.Exists(fullImagePath))
                        {
                            System.IO.File.Delete(fullImagePath); // Xóa tệp ảnh
                        }
                    }

                    // Xóa bản ghi nếu mã sinh viên tồn tại
                    string deleteQuery = "DELETE FROM users WHERE student_code = @student_code";
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@student_code", tbid.Text);

                        int result = deleteCmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Xóa dữ liệu thành công!");
                            LoadStudentData(); // Tải lại dữ liệu sau khi xóa
                            tbid.Text = ""; // Xóa nội dung trong tbid
                        }
                        else
                        {
                            MessageBox.Show("Xóa dữ liệu thất bại!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                }
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng hàng được chọn là hàng hợp lệ
            {
                DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];

                // Hiển thị dữ liệu trong các ô nhập liệu
                tbid.Text = row.Cells["student_code"].Value.ToString();
                tbten.Text = row.Cells["name"].Value.ToString();
                tb_birth.Text = row.Cells["birth_year"].Value.ToString();
                cbnganh.Text = row.Cells["major"].Value.ToString();
                cblop.Text = row.Cells["class"].Value.ToString();
                cbgioitinh.Text = row.Cells["gender"].Value.ToString();
                cbkhoa.Text = row.Cells["batch"].Value.ToString();
                tbemail.Text = row.Cells["email"].Value.ToString(); // Hiển thị email

                // Lấy mật khẩu chỉ khi có
                if (row.Cells["password"].Value != null)
                {
                    tbpassword.Text = row.Cells["password"].Value.ToString(); // Hiển thị mật khẩu
                }

                // Hiển thị ảnh nếu tồn tại
                string imageName = row.Cells["photo"].Value.ToString(); // Lấy tên ảnh
                string fullImagePath = System.IO.Path.Combine(@"D:\1.Home\QLSinhVien\image", imageName);
                // Thiết lập chế độ hiển thị hình ảnh
                pbImage.SizeMode = PictureBoxSizeMode.Zoom; // Thiết lập chế độ hiển thị là Zoom
                if (System.IO.File.Exists(fullImagePath))
                {
                    pbImage.ImageLocation = fullImagePath; // Hiển thị ảnh trong PictureBox
                }
                else
                {
                    pbImage.Image = null; // Xóa ảnh nếu không tồn tại
                }

                // Ngăn không cho chỉnh sửa
                dgvEmployee.ReadOnly = true; // Đặt DataGridView là chỉ đọc
            }
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvEmployee.CurrentRow != null)
            {
                // Kiểm tra các trường nhập liệu có trống hay không
                if (string.IsNullOrWhiteSpace(tbid.Text) ||
                    string.IsNullOrWhiteSpace(tbten.Text) ||
                    string.IsNullOrWhiteSpace(tb_birth.Text) ||
                    string.IsNullOrWhiteSpace(cbnganh.Text) ||
                    string.IsNullOrWhiteSpace(cblop.Text) ||
                    string.IsNullOrWhiteSpace(cbgioitinh.Text) ||
                    string.IsNullOrWhiteSpace(cbkhoa.Text) ||
                    string.IsNullOrWhiteSpace(tbemail.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi sửa!");
                    return; // Thoát khỏi phương thức nếu có trường trống
                }

                // Lấy hàng hiện tại
                DataGridViewRow currentRow = dgvEmployee.CurrentRow;

                // Lấy giá trị hiện tại từ DataGridView
                string currentStudentCode = currentRow.Cells["student_code"].Value.ToString();
                string currentPhoto = currentRow.Cells["photo"].Value.ToString(); // Lấy tên ảnh cũ

                // Kiểm tra xem có ảnh mới được chọn
                string newPhotoName = System.IO.Path.GetFileName(pbImage.ImageLocation); // Lấy tên ảnh mới nếu có

                // Kiểm tra nếu dữ liệu mới khác với dữ liệu cũ hoặc có ảnh mới
                bool isDataChanged = tbid.Text != currentStudentCode ||
                                     tbten.Text != currentRow.Cells["name"].Value.ToString() ||
                                     tb_birth.Text != currentRow.Cells["birth_year"].Value.ToString() ||
                                     cbnganh.Text != currentRow.Cells["major"].Value.ToString() ||
                                     cblop.Text != currentRow.Cells["class"].Value.ToString() ||
                                     cbgioitinh.Text != currentRow.Cells["gender"].Value.ToString() ||
                                     cbkhoa.Text != currentRow.Cells["batch"].Value.ToString() ||
                                     tbemail.Text != currentRow.Cells["email"].Value.ToString();

                if (isDataChanged || !string.IsNullOrEmpty(newPhotoName))
                {
                    using (MySqlConnection conn = GetConnection())
                    {
                        try
                        {
                            conn.Open();

                            // Kiểm tra mã sinh viên tồn tại trước khi cập nhật
                            string checkQuery = "SELECT COUNT(*) FROM users WHERE student_code = @student_code";
                            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@student_code", tbid.Text);
                                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (exists == 0)
                                {
                                    MessageBox.Show("Mã sinh viên không tồn tại!");
                                    return; // Thoát khỏi phương thức nếu mã sinh viên không tồn tại
                                }
                            }

                            // Kiểm tra email trùng lặp
                            string emailCheckQuery = "SELECT COUNT(*) FROM users WHERE email = @new_email AND student_code != @student_code";
                            using (MySqlCommand emailCheckCmd = new MySqlCommand(emailCheckQuery, conn))
                            {
                                emailCheckCmd.Parameters.AddWithValue("@new_email", tbemail.Text);
                                emailCheckCmd.Parameters.AddWithValue("@student_code", tbid.Text); // Tránh kiểm tra email của sinh viên hiện tại
                                int emailExists = Convert.ToInt32(emailCheckCmd.ExecuteScalar());

                                if (emailExists > 0)
                                {
                                    MessageBox.Show("Email này đã tồn tại. Vui lòng sử dụng email khác!");
                                    return; // Thoát khỏi phương thức nếu email đã tồn tại
                                }
                            }

                            // Nếu có ảnh mới và khác với ảnh cũ
                            if (!string.IsNullOrEmpty(newPhotoName) && currentPhoto != newPhotoName)
                            {
                                string oldPhotoPath = System.IO.Path.Combine(@"D:\1.Home\QLSinhVien\image", currentPhoto);
                                if (System.IO.File.Exists(oldPhotoPath))
                                {
                                    System.IO.File.Delete(oldPhotoPath); // Xóa ảnh cũ
                                }
                            }

                            // Cập nhật thông tin sinh viên
                            string query = "UPDATE users SET name = @name, birth_year = @birth_year, major = @major, " +
                                           "class = @class, gender = @gender, batch = @batch, email = @new_email, password = @password " +
                                           (string.IsNullOrEmpty(newPhotoName) ? "" : ", photo = @photo") +
                                           " WHERE student_code = @student_code";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                // Thêm tham số từ các trường nhập liệu
                                cmd.Parameters.AddWithValue("@student_code", tbid.Text);
                                cmd.Parameters.AddWithValue("@name", tbten.Text);
                                cmd.Parameters.AddWithValue("@birth_year", tb_birth.Text);
                                cmd.Parameters.AddWithValue("@major", cbnganh.Text);
                                cmd.Parameters.AddWithValue("@class", cblop.Text);
                                cmd.Parameters.AddWithValue("@gender", cbgioitinh.Text);
                                cmd.Parameters.AddWithValue("@batch", cbkhoa.Text);
                                cmd.Parameters.AddWithValue("@new_email", tbemail.Text);
                                cmd.Parameters.AddWithValue("@password", tbpassword.Text); // Thêm mật khẩu mới
                                // Chỉ thêm tham số photo nếu có ảnh mới
                                if (!string.IsNullOrEmpty(newPhotoName))
                                {
                                    cmd.Parameters.AddWithValue("@photo", newPhotoName);
                                }

                                int result = cmd.ExecuteNonQuery();

                                // Lưu ảnh mới vào thư mục nếu có ảnh mới
                                if (!string.IsNullOrEmpty(newPhotoName))
                                {
                                    string newPhotoPath = System.IO.Path.Combine(@"D:\1.Home\QLSinhVien\image", newPhotoName);
                                    pbImage.Image.Save(newPhotoPath); // Lưu ảnh mới
                                }

                                // Kiểm tra nếu dữ liệu đã được cập nhật thành công
                                if (result > 0)
                                {
                                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                                    LoadStudentData(); // Tải lại dữ liệu để hiển thị thông tin mới
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
                else
                {
                    MessageBox.Show("Không có thay đổi nào để cập nhật!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa!");
            }
        }
        //-------------------------------------------------------

        private void tbid_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Đặt MaxLength cho TextBox để chỉ cho phép tối đa 10 ký tự

        private bool wasMessageShown = false; // Biến để theo dõi trạng thái thông báo

        private void tbid_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra số ký tự trong tbid
            if (tbid.Text.Length < 10)
            {
                // Hiển thị thông báo nếu chưa đủ 10 số và chưa hiển thị trước đó
                if (!wasMessageShown)
                {
                    MessageBox.Show("Vui lòng nhập đủ 10 số.");
                    wasMessageShown = true; // Đánh dấu là đã hiển thị thông báo
                }
            }
            else
            {
                // Xóa thông báo nếu đã đủ 10 số
                wasMessageShown = false; // Đặt lại trạng thái thông báo
            }
        }

        private void tbid_Leave(object sender, EventArgs e)
        {

        }

        private void tb_birth_Leave(object sender, EventArgs e)
        {
            // Giới hạn tối đa 4 ký tự trong TextBox
            tb_birth.MaxLength = 4;
            int year;

            // Định nghĩa khoảng năm hợp lệ
            int minYear = 2000;
            int maxYear = 2006;

            // Kiểm tra nếu độ dài không đủ 4 ký tự hoặc không phải số hoặc ngoài khoảng 2000 đến 2006
            if (tb_birth.Text.Length != 4 ||
                !int.TryParse(tb_birth.Text, out year) ||
                year < minYear ||
                year > maxYear)
            {
                MessageBox.Show($"Vui lòng nhập năm sinh từ {minYear} đến {maxYear}.");
                //tb_birth.Focus(); // Đưa con trỏ trở lại TextBox để người dùng sửa lại
            }
        }

        private void tb_birth_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbten_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập chữ cái và các phím điều khiển (như Backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
            }
        }

        private void tbemail_Leave(object sender, EventArgs e)
        {
            string email = tbemail.Text;

            // Kiểm tra email phải kết thúc bằng "@gmail.com"
            if (!email.EndsWith("@gmail.com") || email.Length <= "@gmail.com".Length)
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ và phải kết thúc bằng @gmail.com");
                tbemail.Focus(); // Đưa con trỏ trở lại TextBox
            }
        }

        private void tbid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tbid.MaxLength = 10;
            // Kiểm tra nếu độ dài của chuỗi nhập vào không đủ 10 ký tự
            if (tbid.Text.Length != 10)
            {
                MessageBox.Show("Vui lòng nhập đúng 10 số.");
                //tbid.Focus(); // Đưa con trỏ trở lại TextBox
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu DataGridView không có dữ liệu
                if (dgvEmployee.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo ứng dụng Excel
                Excel.Application excelApp = new Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // Thêm tiêu đề cho các cột
                for (int i = 1; i < dgvEmployee.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = dgvEmployee.Columns[i - 1].HeaderText;
                }

                // Thêm dữ liệu từ DataGridView vào Excel
                for (int i = 0; i < dgvEmployee.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvEmployee.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvEmployee.Rows[i].Cells[j].Value?.ToString(); // Dùng toán tử ?. để tránh NullReferenceException
                    }
                }

                // Định dạng file và lưu
                string filePath = @"D:\1.Home\QLSinhVien\exported_data.xlsx"; // Đường dẫn và tên file
                excelApp.ActiveWorkbook.SaveAs(filePath);
                excelApp.Columns.AutoFit();
                excelApp.Visible = true;

                // Giải phóng bộ nhớ
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            // Lấy từ khóa từ textBox1
            string keyword = textBox1.Text;

            // Chuỗi truy vấn SQL có thêm cột role_id để kiểm tra
            string query = "SELECT student_code, name, birth_year, major, class, gender, batch, email, password, photo, role_id " +
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
                            dgvEmployee.DataSource = null; // Xóa dữ liệu hiện có trong dataGridView nếu cần
                        }
                        else
                        {
                            // Kiểm tra nếu có sinh viên nào có role_id = 1
                            bool isAdmin = dt.AsEnumerable().Any(row => row.Field<int>("role_id") == 1);

                            if (isAdmin)
                            {
                                // Hiển thị thông báo nếu có tài khoản admin
                                MessageBox.Show("Tài khoản là admin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvEmployee.DataSource = null; // Không hiển thị dữ liệu admin trong DataGridView
                            }
                            else
                            {
                                // Hiển thị dữ liệu lên dataGridView nếu không phải là admin
                                dgvEmployee.DataSource = dt;
                            }
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

        private void btXapXep_Click(object sender, EventArgs e)
        {
            // Chuỗi truy vấn SQL với sắp xếp theo tên và loại bỏ role_id = 1
            string query = "SELECT student_code, name, birth_year, major, class, gender, batch, email, password, photo " +
                           "FROM users " +
                           "WHERE role_id <> 1 " + // Loại bỏ các sinh viên có role_id = 1
                           "ORDER BY name ASC";   // Sắp xếp theo tên tăng dần (A-Z)

            // Kết nối đến database và thực hiện truy vấn
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Đổ dữ liệu vào DataTable
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Kiểm tra kết quả
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu để sắp xếp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvEmployee.DataSource = null; // Xóa dữ liệu hiện có trong dataGridView nếu cần
                        }
                        else
                        {
                            // Hiển thị dữ liệu đã sắp xếp lên dataGridView
                            dgvEmployee.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }


    }
}