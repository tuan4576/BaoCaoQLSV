namespace QLSinhVien
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btAdd = new Button();
            tbid = new TextBox();
            dgvEmployee = new DataGridView();
            label1 = new Label();
            btEdit = new Button();
            btDelete = new Button();
            lb = new Label();
            label2 = new Label();
            tbten = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            cbgioitinh = new ComboBox();
            cbnganh = new ComboBox();
            cblop = new ComboBox();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            tb_birth = new TextBox();
            tbemail = new TextBox();
            label5 = new Label();
            pbImage = new PictureBox();
            label8 = new Label();
            button1 = new Button();
            tbpassword = new TextBox();
            label9 = new Label();
            cbkhoa = new ComboBox();
            label10 = new Label();
            textBox1 = new TextBox();
            btSearch = new Button();
            btXapXep = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // btAdd
            // 
            btAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btAdd.Location = new Point(973, 585);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(94, 40);
            btAdd.TabIndex = 0;
            btAdd.Text = "Thêm";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // tbid
            // 
            tbid.Anchor = AnchorStyles.None;
            tbid.Location = new Point(245, 497);
            tbid.Name = "tbid";
            tbid.Size = new Size(173, 27);
            tbid.TabIndex = 1;
            tbid.KeyPress += tbid_KeyPress;
            tbid.Leave += tbid_Leave;
            tbid.Validating += tbid_Validating;
            // 
            // dgvEmployee
            // 
            dgvEmployee.Anchor = AnchorStyles.None;
            dgvEmployee.BackgroundColor = Color.LightGray;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Location = new Point(245, 87);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.Size = new Size(1129, 358);
            dgvEmployee.TabIndex = 2;
            dgvEmployee.CellClick += dgvEmployee_CellClick;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(559, 16);
            label1.Name = "label1";
            label1.Size = new Size(253, 40);
            label1.TabIndex = 3;
            label1.Text = "Quản lí sinh viên";
            // 
            // btEdit
            // 
            btEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btEdit.Location = new Point(1124, 585);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(94, 40);
            btEdit.TabIndex = 4;
            btEdit.Text = "Sửa";
            btEdit.UseVisualStyleBackColor = true;
            btEdit.Click += btEdit_Click;
            // 
            // btDelete
            // 
            btDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btDelete.Location = new Point(1267, 585);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(94, 40);
            btDelete.TabIndex = 5;
            btDelete.Text = "Xóa";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // lb
            // 
            lb.Anchor = AnchorStyles.None;
            lb.AutoSize = true;
            lb.Location = new Point(245, 464);
            lb.Name = "lb";
            lb.Size = new Size(49, 20);
            lb.TabIndex = 7;
            lb.Text = "MASV";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(245, 546);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 9;
            label2.Text = "Tên";
            // 
            // tbten
            // 
            tbten.Anchor = AnchorStyles.None;
            tbten.Location = new Point(245, 579);
            tbten.Name = "tbten";
            tbten.Size = new Size(173, 27);
            tbten.TabIndex = 8;
            tbten.KeyPress += tbten_KeyPress;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(451, 464);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 11;
            label3.Text = "Năm sinh";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(451, 546);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 13;
            label4.Text = "Giới tính";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(634, 465);
            label6.Name = "label6";
            label6.Size = new Size(53, 20);
            label6.TabIndex = 17;
            label6.Text = "Ngành";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new Point(823, 465);
            label7.Name = "label7";
            label7.Size = new Size(34, 20);
            label7.TabIndex = 19;
            label7.Text = "Lớp";
            // 
            // cbgioitinh
            // 
            cbgioitinh.Anchor = AnchorStyles.None;
            cbgioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbgioitinh.FormattingEnabled = true;
            cbgioitinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cbgioitinh.Location = new Point(451, 579);
            cbgioitinh.Name = "cbgioitinh";
            cbgioitinh.Size = new Size(151, 28);
            cbgioitinh.TabIndex = 20;
            // 
            // cbnganh
            // 
            cbnganh.Anchor = AnchorStyles.None;
            cbnganh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbnganh.FormattingEnabled = true;
            cbnganh.Items.AddRange(new object[] { "Công nghệ thông tin ", "Quản trị khách sạn ", "Ngôn ngữ anh ", "Cơ khí ", "Điện ", "Thực phẩm", "Quản trị kinh doanh", "Maketing" });
            cbnganh.Location = new Point(634, 498);
            cbnganh.Name = "cbnganh";
            cbnganh.Size = new Size(151, 28);
            cbnganh.TabIndex = 21;
            // 
            // cblop
            // 
            cblop.Anchor = AnchorStyles.None;
            cblop.DropDownStyle = ComboBoxStyle.DropDownList;
            cblop.FormattingEnabled = true;
            cblop.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H" });
            cblop.Location = new Point(823, 498);
            cblop.Name = "cblop";
            cblop.Size = new Size(151, 28);
            cblop.TabIndex = 22;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // tb_birth
            // 
            tb_birth.Anchor = AnchorStyles.None;
            tb_birth.Location = new Point(451, 498);
            tb_birth.Name = "tb_birth";
            tb_birth.Size = new Size(151, 27);
            tb_birth.TabIndex = 24;
            tb_birth.KeyPress += tb_birth_KeyPress;
            tb_birth.Leave += tb_birth_Leave;
            // 
            // tbemail
            // 
            tbemail.Anchor = AnchorStyles.None;
            tbemail.Location = new Point(634, 580);
            tbemail.Name = "tbemail";
            tbemail.Size = new Size(165, 27);
            tbemail.TabIndex = 25;
            tbemail.Leave += tbemail_Leave;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(634, 546);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 26;
            label5.Text = "email";
            // 
            // pbImage
            // 
            pbImage.Anchor = AnchorStyles.None;
            pbImage.Location = new Point(62, 400);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(132, 166);
            pbImage.TabIndex = 27;
            pbImage.TabStop = false;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Location = new Point(97, 362);
            label8.Name = "label8";
            label8.Size = new Size(60, 20);
            label8.TabIndex = 28;
            label8.Text = "ảnh 3x4";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(86, 596);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 29;
            button1.Text = "Chọn ảnh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tbpassword
            // 
            tbpassword.Anchor = AnchorStyles.None;
            tbpassword.Location = new Point(1209, 498);
            tbpassword.Name = "tbpassword";
            tbpassword.Size = new Size(165, 27);
            tbpassword.TabIndex = 30;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Location = new Point(1209, 465);
            label9.Name = "label9";
            label9.Size = new Size(70, 20);
            label9.TabIndex = 31;
            label9.Text = "Mật khẩu";
            // 
            // cbkhoa
            // 
            cbkhoa.Anchor = AnchorStyles.None;
            cbkhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbkhoa.FormattingEnabled = true;
            cbkhoa.Items.AddRange(new object[] { "K45", "K46", "K47" });
            cbkhoa.Location = new Point(1014, 496);
            cbkhoa.Name = "cbkhoa";
            cbkhoa.Size = new Size(151, 28);
            cbkhoa.TabIndex = 32;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Location = new Point(1014, 465);
            label10.Name = "label10";
            label10.Size = new Size(43, 20);
            label10.TabIndex = 33;
            label10.Text = "Khóa";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Location = new Point(961, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(244, 27);
            textBox1.TabIndex = 34;
            // 
            // btSearch
            // 
            btSearch.Anchor = AnchorStyles.None;
            btSearch.Location = new Point(1220, 43);
            btSearch.Name = "btSearch";
            btSearch.Size = new Size(94, 29);
            btSearch.TabIndex = 35;
            btSearch.Text = "tìm kiếm";
            btSearch.UseVisualStyleBackColor = true;
            btSearch.Click += btSearch_Click;
            // 
            // btXapXep
            // 
            btXapXep.Anchor = AnchorStyles.None;
            btXapXep.Location = new Point(245, 43);
            btXapXep.Name = "btXapXep";
            btXapXep.Size = new Size(94, 29);
            btXapXep.TabIndex = 36;
            btXapXep.Text = "Xắp xếp";
            btXapXep.UseVisualStyleBackColor = true;
            btXapXep.Click += btXapXep_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1413, 653);
            Controls.Add(btXapXep);
            Controls.Add(btSearch);
            Controls.Add(textBox1);
            Controls.Add(label10);
            Controls.Add(cbkhoa);
            Controls.Add(label9);
            Controls.Add(tbpassword);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(pbImage);
            Controls.Add(label5);
            Controls.Add(tbemail);
            Controls.Add(tb_birth);
            Controls.Add(cblop);
            Controls.Add(cbnganh);
            Controls.Add(cbgioitinh);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbten);
            Controls.Add(lb);
            Controls.Add(btDelete);
            Controls.Add(btEdit);
            Controls.Add(label1);
            Controls.Add(dgvEmployee);
            Controls.Add(tbid);
            Controls.Add(btAdd);
            Name = "Home";
            Text = "Home";
            WindowState = FormWindowState.Maximized;
            Load += Home_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btAdd;
        private TextBox tbid;
        private DataGridView dgvEmployee;
        private Label label1;
        private Button btEdit;
        private Button btDelete;
        private Label lb;
        private Label label2;
        private TextBox tbten;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private ComboBox cbgioitinh;
        private ComboBox cbnganh;
        private ComboBox cblop;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private TextBox tb_birth;
        private TextBox tbemail;
        private Label label5;
        private PictureBox pbImage;
        private Label label8;
        private Button button1;
        private TextBox tbpassword;
        private Label label9;
        private ComboBox cbkhoa;
        private Label label10;
        private TextBox textBox1;
        private Button btSearch;
        private Button btXapXep;
    }
}