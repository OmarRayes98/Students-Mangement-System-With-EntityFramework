using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Students_Mangement_System
{
    public partial class Frm_Login : Form
    {

        BL.Login class_log = new BL.Login();
        public Frm_Login()
        {

            InitializeComponent();

            Fill_ComUsers();

            Com_Users.SelectedValue = 0;
        }

        private void Fill_ComUsers()
        { 
            Com_Users.DataSource = class_log.AllUser();
            Com_Users.DisplayMember = "Name";
            Com_Users.ValueMember = "Id_User";
        }


        private void Btn_Cancel_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Com_Users.Text) || string.IsNullOrEmpty(Txt_PWD.Text))
            {
                MessageBox.Show("لا يمكن ترك البيانات فارغة ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = new User();
            user = class_log.Check_Login(Com_Users.Text, Txt_PWD.Text);

            if (user!=null)
            {
                Pic_Up.Image = Properties.Resources.True;
                Pic_Down.Image = Properties.Resources.True;
                MessageBox.Show("تم تسجيل الدخول بنجاح ", "تسجيل الدخول",MessageBoxButtons.OK, MessageBoxIcon.Information);

                Frm_MainForm MainF = new Frm_MainForm();
               

                string user_type = user.User_Type;

                if (user_type == "مدير")
                {
                    MainF.ToolMS_Users.Enabled = true;
                }
                else
                {
                    MainF.ToolMS_Users.Enabled = false;
                }
                this.Hide();
                MainF.ShowDialog();
            }
            else
            {
                Pic_Down.Image = Properties.Resources.False;
                MessageBox.Show("الرجاء التحقق من  المعلومات ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Btn_Eyes_Visible_Click(object sender, EventArgs e)
        {
            Txt_PWD.UseSystemPasswordChar = false;
            Btn_Eyes_Visible.Visible = false;
        }

        private void Btn_Eye_Hide_Click(object sender, EventArgs e)
        {
            Txt_PWD.UseSystemPasswordChar = true;
            Btn_Eyes_Visible.Visible = true;
        }

        private void Frm_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_login_Click(sender, e);
            }
        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
