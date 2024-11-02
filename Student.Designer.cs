namespace QLSinhVien
{

    partial class Student
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
            label1 = new Label();
            tbMasv = new TextBox();
            pbPhoto = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            tbName = new TextBox();
            label4 = new Label();
            tbEmail = new TextBox();
            label5 = new Label();
            tbPassword = new TextBox();
            label6 = new Label();
            tbYear = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            tbBatch = new TextBox();
            label10 = new Label();
            btEdit = new Button();
            button3 = new Button();
            tbClass = new TextBox();
            tbMajor = new TextBox();
            tbGender = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(96, 44);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 0;
            label1.Text = "Ảnh";
            // 
            // tbMasv
            // 
            tbMasv.Anchor = AnchorStyles.None;
            tbMasv.Enabled = false;
            tbMasv.Location = new Point(310, 80);
            tbMasv.Name = "tbMasv";
            tbMasv.Size = new Size(184, 27);
            tbMasv.TabIndex = 1;
            // 
            // pbPhoto
            // 
            pbPhoto.Anchor = AnchorStyles.None;
            pbPhoto.Location = new Point(96, 80);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(175, 203);
            pbPhoto.TabIndex = 3;
            pbPhoto.TabStop = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(310, 44);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 4;
            label2.Text = "Mã sinh viên";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(310, 132);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 6;
            label3.Text = "Tên";
            // 
            // tbName
            // 
            tbName.Anchor = AnchorStyles.None;
            tbName.Location = new Point(310, 168);
            tbName.Name = "tbName";
            tbName.Size = new Size(184, 27);
            tbName.TabIndex = 5;
            tbName.KeyPress += tbName_KeyPress;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(853, 132);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 8;
            label4.Text = "Email";
            // 
            // tbEmail
            // 
            tbEmail.Anchor = AnchorStyles.None;
            tbEmail.Location = new Point(853, 168);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(184, 27);
            tbEmail.TabIndex = 7;
            tbEmail.Leave += tbEmail_Leave;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(562, 44);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 10;
            label5.Text = "Mật khẩu";
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.None;
            tbPassword.Location = new Point(562, 80);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(184, 27);
            tbPassword.TabIndex = 9;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(562, 132);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 12;
            label6.Text = "Năm sinh";
            // 
            // tbYear
            // 
            tbYear.Anchor = AnchorStyles.None;
            tbYear.Location = new Point(562, 168);
            tbYear.Name = "tbYear";
            tbYear.Size = new Size(184, 27);
            tbYear.TabIndex = 11;
            tbYear.KeyPress += tbYear_KeyPress;
            tbYear.Leave += tbYear_Leave;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new Point(562, 220);
            label7.Name = "label7";
            label7.Size = new Size(53, 20);
            label7.TabIndex = 13;
            label7.Text = "Ngành";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Location = new Point(310, 220);
            label8.Name = "label8";
            label8.Size = new Size(34, 20);
            label8.TabIndex = 15;
            label8.Text = "Lớp";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Location = new Point(853, 44);
            label9.Name = "label9";
            label9.Size = new Size(43, 20);
            label9.TabIndex = 18;
            label9.Text = "Khóa";
            // 
            // tbBatch
            // 
            tbBatch.Anchor = AnchorStyles.None;
            tbBatch.Enabled = false;
            tbBatch.Location = new Point(853, 80);
            tbBatch.Name = "tbBatch";
            tbBatch.Size = new Size(184, 27);
            tbBatch.TabIndex = 17;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Location = new Point(853, 220);
            label10.Name = "label10";
            label10.Size = new Size(65, 20);
            label10.TabIndex = 19;
            label10.Text = "Giới tính";
            // 
            // btEdit
            // 
            btEdit.Location = new Point(954, 517);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(132, 43);
            btEdit.TabIndex = 21;
            btEdit.Text = "Sửa thông tin";
            btEdit.UseVisualStyleBackColor = true;
            btEdit.Click += btEdit_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1134, 517);
            button3.Name = "button3";
            button3.Size = new Size(95, 43);
            button3.TabIndex = 22;
            button3.Text = "Đăng xuất";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tbClass
            // 
            tbClass.Anchor = AnchorStyles.None;
            tbClass.Enabled = false;
            tbClass.Location = new Point(310, 257);
            tbClass.Name = "tbClass";
            tbClass.Size = new Size(184, 27);
            tbClass.TabIndex = 23;
            // 
            // tbMajor
            // 
            tbMajor.Anchor = AnchorStyles.None;
            tbMajor.Enabled = false;
            tbMajor.Location = new Point(562, 267);
            tbMajor.Name = "tbMajor";
            tbMajor.Size = new Size(184, 27);
            tbMajor.TabIndex = 24;
            // 
            // tbGender
            // 
            tbGender.Anchor = AnchorStyles.None;
            tbGender.Enabled = false;
            tbGender.Location = new Point(853, 267);
            tbGender.Name = "tbGender";
            tbGender.Size = new Size(184, 27);
            tbGender.TabIndex = 25;
            // 
            // Student
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1412, 619);
            Controls.Add(tbGender);
            Controls.Add(tbMajor);
            Controls.Add(tbClass);
            Controls.Add(button3);
            Controls.Add(btEdit);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(tbBatch);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(tbYear);
            Controls.Add(label5);
            Controls.Add(tbPassword);
            Controls.Add(label4);
            Controls.Add(tbEmail);
            Controls.Add(label3);
            Controls.Add(tbName);
            Controls.Add(label2);
            Controls.Add(pbPhoto);
            Controls.Add(tbMasv);
            Controls.Add(label1);
            Name = "Student";
            Text = " Sinh viên";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pbPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbMasv;
        private PictureBox pbPhoto;
        private Label label2;
        private Label label3;
        private TextBox tbName;
        private Label label4;
        private TextBox tbEmail;
        private Label label5;
        private TextBox tbPassword;
        private Label label6;
        private TextBox tbYear;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox tbBatch;
        private Label label10;
        private Button btEdit;
        private Button button3;
        private TextBox tbClass;
        private TextBox tbMajor;
        private TextBox tbGender;
    }
}