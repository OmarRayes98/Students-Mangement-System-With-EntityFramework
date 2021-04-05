namespace Students_Mangement_System
{
    partial class Frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.gradientPanel1 = new Students_Mangement_System.GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Pic_Up = new System.Windows.Forms.PictureBox();
            this.Pic_Down = new System.Windows.Forms.PictureBox();
            this.Btn_Eyes_Visible = new System.Windows.Forms.Button();
            this.Btn_Eye_Hide = new System.Windows.Forms.Button();
            this.Txt_PWD = new System.Windows.Forms.TextBox();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_login = new System.Windows.Forms.Button();
            this.Com_Users = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gradientPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angel = 75F;
            this.gradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.gradientPanel1.ColorButtom = System.Drawing.Color.Empty;
            this.gradientPanel1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(178)))), ((int)(((byte)(200)))));
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.groupBox1);
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(655, 349);
            this.gradientPanel1.TabIndex = 0;
            this.gradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(474, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "نظام إدارة طلاب ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Pic_Up);
            this.groupBox1.Controls.Add(this.Pic_Down);
            this.groupBox1.Controls.Add(this.Btn_Eyes_Visible);
            this.groupBox1.Controls.Add(this.Btn_Eye_Hide);
            this.groupBox1.Controls.Add(this.Txt_PWD);
            this.groupBox1.Controls.Add(this.Btn_Cancel);
            this.groupBox1.Controls.Add(this.Btn_login);
            this.groupBox1.Controls.Add(this.Com_Users);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(38, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(579, 242);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "يرجى تسجيل الدخول هنا ";
            // 
            // Pic_Up
            // 
            this.Pic_Up.Location = new System.Drawing.Point(19, 56);
            this.Pic_Up.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Pic_Up.Name = "Pic_Up";
            this.Pic_Up.Size = new System.Drawing.Size(23, 26);
            this.Pic_Up.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic_Up.TabIndex = 12;
            this.Pic_Up.TabStop = false;
            // 
            // Pic_Down
            // 
            this.Pic_Down.Location = new System.Drawing.Point(19, 123);
            this.Pic_Down.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Pic_Down.Name = "Pic_Down";
            this.Pic_Down.Size = new System.Drawing.Size(23, 26);
            this.Pic_Down.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic_Down.TabIndex = 11;
            this.Pic_Down.TabStop = false;
            // 
            // Btn_Eyes_Visible
            // 
            this.Btn_Eyes_Visible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Eyes_Visible.BackColor = System.Drawing.Color.White;
            this.Btn_Eyes_Visible.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Eyes_Visible.BackgroundImage")));
            this.Btn_Eyes_Visible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Eyes_Visible.FlatAppearance.BorderSize = 0;
            this.Btn_Eyes_Visible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Eyes_Visible.Location = new System.Drawing.Point(47, 123);
            this.Btn_Eyes_Visible.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Eyes_Visible.Name = "Btn_Eyes_Visible";
            this.Btn_Eyes_Visible.Size = new System.Drawing.Size(22, 26);
            this.Btn_Eyes_Visible.TabIndex = 7;
            this.Btn_Eyes_Visible.TabStop = false;
            this.Btn_Eyes_Visible.Text = "11111";
            this.Btn_Eyes_Visible.UseVisualStyleBackColor = false;
            this.Btn_Eyes_Visible.Click += new System.EventHandler(this.Btn_Eyes_Visible_Click);
            // 
            // Btn_Eye_Hide
            // 
            this.Btn_Eye_Hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Eye_Hide.BackColor = System.Drawing.Color.White;
            this.Btn_Eye_Hide.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Eye_Hide.BackgroundImage")));
            this.Btn_Eye_Hide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Eye_Hide.FlatAppearance.BorderSize = 0;
            this.Btn_Eye_Hide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Eye_Hide.Location = new System.Drawing.Point(47, 123);
            this.Btn_Eye_Hide.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Eye_Hide.Name = "Btn_Eye_Hide";
            this.Btn_Eye_Hide.Size = new System.Drawing.Size(22, 26);
            this.Btn_Eye_Hide.TabIndex = 6;
            this.Btn_Eye_Hide.TabStop = false;
            this.Btn_Eye_Hide.UseVisualStyleBackColor = false;
            this.Btn_Eye_Hide.Click += new System.EventHandler(this.Btn_Eye_Hide_Click);
            // 
            // Txt_PWD
            // 
            this.Txt_PWD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_PWD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Txt_PWD.Location = new System.Drawing.Point(46, 122);
            this.Txt_PWD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Txt_PWD.Name = "Txt_PWD";
            this.Txt_PWD.Size = new System.Drawing.Size(241, 30);
            this.Txt_PWD.TabIndex = 2;
            this.Txt_PWD.UseSystemPasswordChar = true;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Cancel.AutoSize = true;
            this.Btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.Btn_Cancel.Location = new System.Drawing.Point(47, 200);
            this.Btn_Cancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(82, 34);
            this.Btn_Cancel.TabIndex = 4;
            this.Btn_Cancel.Text = "إلغاء";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click_1);
            // 
            // Btn_login
            // 
            this.Btn_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_login.AutoSize = true;
            this.Btn_login.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Btn_login.ForeColor = System.Drawing.Color.Black;
            this.Btn_login.Location = new System.Drawing.Point(141, 200);
            this.Btn_login.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_login.Name = "Btn_login";
            this.Btn_login.Size = new System.Drawing.Size(121, 34);
            this.Btn_login.TabIndex = 3;
            this.Btn_login.Text = "تسجبل الدخول";
            this.Btn_login.UseVisualStyleBackColor = true;
            this.Btn_login.Click += new System.EventHandler(this.Btn_login_Click);
            // 
            // Com_Users
            // 
            this.Com_Users.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Com_Users.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Com_Users.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Com_Users.FormattingEnabled = true;
            this.Com_Users.Location = new System.Drawing.Point(46, 55);
            this.Com_Users.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Com_Users.Name = "Com_Users";
            this.Com_Users.Size = new System.Drawing.Size(241, 31);
            this.Com_Users.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(425, 39);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "كلمة المرور";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "اسم المستخدم ";
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(655, 349);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Login_KeyDown);
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox Pic_Up;
        private System.Windows.Forms.PictureBox Pic_Down;
        private System.Windows.Forms.Button Btn_Eyes_Visible;
        private System.Windows.Forms.Button Btn_Eye_Hide;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_login;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox Txt_PWD;
        public System.Windows.Forms.ComboBox Com_Users;
    }
}

