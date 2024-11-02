using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient; // Sử dụng MySQL
namespace QLSinhVien
{
    public partial class Form1 : Form
    {
        private BusinessAccessLayer businessAccessLayer;
        public Form1()
        {
            InitializeComponent();
            //InitializePictureBox();
            businessAccessLayer = new BusinessAccessLayer();
        }
        private void Form11_Load(object sender, EventArgs e)
        {
            try
            {
                var reader = businessAccessLayer.GetAllCustomers();
                while (reader.Read())
                {
                    // Xử lý dữ liệu đọc được từ bảng customer
                    Console.WriteLine(reader["column_name"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentCode = tbname.Text;
            string password = tbpassword.Text;

            if (businessAccessLayer.Login(studentCode, password, out int roleId))
            {
                if (roleId == 1)
                {
                    Menu menu = new Menu();
                    menu.Show();
                }
                else
                {
                    Student student = new Student(studentCode);
                    student.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mã sinh viên hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            // Vẽ nền
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 20; // Bán kính bo góc
                path.StartFigure();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
                path.AddArc(0, Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
            }
        }

        private void tbname_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Nếu không phải là số và không phải là phím điều khiển (như backspace), thì hủy sự kiện
                e.Handled = true;

                // Hiển thị thông báo cho người dùng
                MessageBox.Show("Chỉ nhập số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //private void InitializePictureBox()
        //{
        //    // Tạo pbAdmin và đặt thuộc tính cơ bản
        //    pbAdmin = new PictureBox();
        //    pbAdmin.Size = new System.Drawing.Size(300, 300); // Đặt kích thước PictureBox
        //    pbAdmin.Location = new System.Drawing.Point(50, 50); // Đặt vị trí của PictureBox trên form
        //    pbAdmin.SizeMode = PictureBoxSizeMode.StretchImage; // Đặt chế độ co giãn hình ảnh

        //    // Đặt đường dẫn tới hình ảnh
        //    pbAdmin.ImageLocation = @"D:\1.Home\C#\QLSinhVien\image\admin.png";

        //    // Thêm pbAdmin vào Form
        //    this.Controls.Add(pbAdmin);
        //}


    }
}
