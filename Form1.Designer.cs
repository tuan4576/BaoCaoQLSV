namespace QLSinhVien
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            btLogin = new Button();
            tbname = new TextBox();
            label3 = new Label();
            tbpassword = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(426, 96);
            label1.Name = "label1";
            label1.Size = new Size(224, 51);
            label1.TabIndex = 0;
            label1.Text = "Đăng nhập";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(309, 244);
            label2.Name = "label2";
            label2.Size = new Size(154, 24);
            label2.TabIndex = 1;
            label2.Text = "Mã đăng nhập";
            // 
            // btLogin
            // 
            btLogin.Anchor = AnchorStyles.None;
            btLogin.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btLogin.Location = new Point(441, 598);
            btLogin.Name = "btLogin";
            btLogin.Size = new Size(128, 46);
            btLogin.TabIndex = 2;
            btLogin.Text = "Đăng nhập";
            btLogin.UseVisualStyleBackColor = true;
            btLogin.Click += button1_Click;
            // 
            // tbname
            // 
            tbname.Anchor = AnchorStyles.None;
            tbname.Location = new Point(309, 289);
            tbname.Multiline = true;
            tbname.Name = "tbname";
            tbname.Size = new Size(410, 41);
            tbname.TabIndex = 3;
            tbname.KeyPress += tbname_KeyPress;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(309, 382);
            label3.Name = "label3";
            label3.Size = new Size(104, 24);
            label3.TabIndex = 4;
            label3.Text = "Mật khẩu";
            // 
            // tbpassword
            // 
            tbpassword.Anchor = AnchorStyles.None;
            tbpassword.Location = new Point(309, 446);
            tbpassword.Multiline = true;
            tbpassword.Name = "tbpassword";
            tbpassword.PasswordChar = '*';
            tbpassword.Size = new Size(410, 41);
            tbpassword.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1101, 732);
            Controls.Add(tbpassword);
            Controls.Add(label3);
            Controls.Add(tbname);
            Controls.Add(btLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btLogin;
        private TextBox tbname;
        private Label label3;
        private TextBox tbpassword;
    }
}
