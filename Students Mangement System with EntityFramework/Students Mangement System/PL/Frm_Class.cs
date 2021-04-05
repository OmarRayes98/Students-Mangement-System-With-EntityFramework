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

    public partial class Frm_Class : Form
    {
        BL.Classes classes = new BL.Classes();
        bool Enable_BtnAdd = true;
        public static int idclass;
        public Frm_Class()
        {
            InitializeComponent();
            Fill_ComNameClass();
            Com_NameClass.SelectedValue = 0;
            Fill_DGV_Class();
        }

        private void Fill_DGV_Class()
        {
            DGV_Class.DataSource = classes.Fill_Classes();
            DGV_Class.Columns[0].HeaderText = "رقم الصف";
            DGV_Class.Columns[1].HeaderText = "اسم الصف";
            DGV_Class.Columns[2].HeaderText = "رقم الكورس";            
        }

        private void Fill_ComNameClass()
        {


            Com_NameClass.DataSource = classes.Fill_ComNameClassCourse();
            Com_NameClass.DisplayMember = "Name";
            Com_NameClass.ValueMember = "Id_Course";
        }

        private void Frm_Class_Load(object sender, EventArgs e)
        {
            DGV_Class.ClearSelection();
        }

        private void Btn_New_Click(object sender, EventArgs e)
        {
            Btn_Add.Enabled = true;
            Btn_Update.Enabled = false;

            Com_NameClass.SelectedValue = 0;
            RText_Letter.ResetText();
            DGV_Class.ClearSelection();

        }

        private void Frm_Class_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Btn_New_Click(sender, e);
            }
        }

        private void Frm_Class_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
        
        Class Check_NameClass()
       {
            Class Class = new Class();
            Class = classes.Check_Class(RText_Edit.Text);
            return Class;
       }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (Com_NameClass.SelectedIndex == -1 || string.IsNullOrEmpty(RText_Letter.Text))
            {
                MessageBox.Show("الرجاء إكمال المعلومات المطلوبة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (Check_NameClass() != null)
                {
                    MessageBox.Show("                   , هذا الاسم موجود سابقا  \n               الرجاء تغيير الحرف أو الرقم  \n . لعدم حدوث تشابه بأسماء الصفوف ", "معلومات ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }

                classes.Add_Classes(Com_NameClass.Text + " فئة : " + RText_Letter.Text, Convert.ToInt32(Com_NameClass.SelectedValue));
                MessageBox.Show("تمت عملية الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Fill_DGV_Class();
                Btn_New_Click(sender, e);
                
            }
        }



        private void Btn_Delete_Click(object sender, EventArgs e)
        {

                if (DGV_Class.SelectedRows.Count > 0)
                {
                    MessageBox.Show("            تحذير : عند حذف صف سيتم حذف  \n  (كامل بياناته (الطلاب الصف وتسجيلاتهم الخاصة به ..الخ   ", "تحذير ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (MessageBox.Show(" تأكيد عملية الحذف ؟ ", "عملية الحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        classes.Delete_Class(Convert.ToInt32(DGV_Class.CurrentRow.Cells[0].Value.ToString()));
                        Fill_DGV_Class();
                        Btn_New_Click(sender, e);
                    }
                    else
                    {
                        Btn_New_Click(sender, e);
                    }
                }
            

        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {


                classes.Update_Class(Convert.ToInt32(DGV_Class.CurrentRow.Cells[0].Value.ToString()), Com_NameClass.Text + " فئة : " + RText_Letter.Text, Convert.ToInt32(Com_NameClass.SelectedValue));

                MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Fill_DGV_Class();

                if (Enable_BtnAdd == false)
                {
                    Btn_Add.Enabled = true;
                }
                Btn_Update.Enabled = false;

                Btn_New_Click(sender, e);
            }
            catch (Exception ex)
            {
            }
        }

        private void DGV_Class_DoubleClick(object sender, EventArgs e)
        {
            RText_Edit.ResetText();
            if (DGV_Class.SelectedRows.Count == 0)
                return;

            RText_Edit.Text = DGV_Class.CurrentRow.Cells[1].Value.ToString();


            DGV_Class.ClearSelection();

            Btn_Update.Enabled = true;
            Enable_BtnAdd = false;
            Btn_Add.Enabled = false;
        }

        private void Com_NameClass_TextChanged(object sender, EventArgs e)
        {
            RText_Edit.Text = "" + Com_NameClass.Text + " فئة : " + RText_Letter.Text + "";
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {

            DGV_Class.DataSource = classes.Search_Class(RText_Search.Text);
            DGV_Class.Columns[0].HeaderText = "رقم الصف";
            DGV_Class.Columns[1].HeaderText = "اسم الصف";
            DGV_Class.Columns[2].HeaderText = "رقم الكورس";

            DGV_Class.ClearSelection();
        }

        private void Btn_ClassStudents_Click(object sender, EventArgs e)
        {
            if (DGV_Class.SelectedRows.Count > 0)
            {
                idclass = Convert.ToInt32(DGV_Class.CurrentRow.Cells[0].Value.ToString());

                Frm_StudentsClass SClass = new Frm_StudentsClass();
                SClass.ShowDialog();
            }
            else
            {
                MessageBox.Show("                              , لم يتم تحديد سجل من الجدول الأسفل  \n . الرجاء تحديد سجل ثم الضغط لإظهار طلاب الصف المحدد", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

    


