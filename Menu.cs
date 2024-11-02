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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void quảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var HomeForm = new Home();
            AddForm(HomeForm);
        }
        private void AddForm(Form f)
        {
            this.Content.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.Content.Controls.Add(f);
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một instance của Form1
            Form1 form1 = new Form1();

            // Hiển thị Form1
            form1.Show();

            // Đóng form hiện tại
            this.Close();
        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SearchForm = new Search();
            AddForm(SearchForm);
        }
    }
}
