﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Students_Mangement_System
{
    public partial class Frm_Students : Form
    {
        BL.Students student = new BL.Students();
        BL.Specializations Student_SP = new BL.Specializations();
        
        bool Enable_BtnAdd = true;

        private static Frm_Students frm;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Frm_Students getfrm_student
        {
            get
            {
                if (frm == null)
                {
                    frm=new Frm_Students();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);

                }
                return frm;
            }
        }
        public Frm_Students()
        {
            if (frm == null)
                frm = this;

            InitializeComponent();

            Fill_DGV_Students();
            Fill_Com_Spicaliztion();
            Com_Spicaliztion.SelectedValue = 0;

        }
        private void Fill_Com_Spicaliztion()
        {

            Com_Spicaliztion.DataSource = Student_SP.Fill_ListItems();
            Com_Spicaliztion.DisplayMember = "Name_Specializtion";
            Com_Spicaliztion.ValueMember = "Id_Specializtion";
            
        }

        private void Fill_DGV_Students()
        {
            DGV_Student.DataSource= student.Show_Students();
            DGV_Student.Columns[0].HeaderText = "رقم";
            DGV_Student.Columns[1].HeaderText = "اسم الطالب";
            DGV_Student.Columns[2].HeaderText = "الهاتف الأرضي";
            DGV_Student.Columns[3].HeaderText = "الموبايل ";
            DGV_Student.Columns[4].HeaderText = "الجنس ";
            DGV_Student.Columns[5].HeaderText = "اختصاص الطالب";


            foreach (DataGridViewColumn column in DGV_Student.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (column == DGV_Student.Columns[1])
                {
                    DGV_Student.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    continue;
                }
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            Check_DGV_Size();
        }
        private void Check_DGV_Size()
        {
            if (DGV_Student.Columns[1].Width <= 68)
            {
                DGV_Student.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            else
            {
                DGV_Student.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void Frm_Students_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void Frm_Students_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Btn_Reset_Click(sender, e);
            }  
        }

        public void OnlyNumber(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':case '1':case '2': case '3': case '4':case '5': case '6': case '7':  case '8':   case '9': case (char)Keys.Back: case (char)Keys.Space: case (char)Keys.Enter: case ('+'):
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        public void OnlyLetters(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            { case '0':case '1': case '2':  case '3': case '4':  case '5': case '6':  case '7':  case '8':  case '9':
                    e.Handled = true;
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }


         Student Check_NameStudent()
        {
            Student check_student = new Student();
            check_student = student.Check_Student(RText_Name.Text);
            return check_student;
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {

           Btn_Add.Enabled = true;
            Btn_Update.Enabled = false;

            RText_Name.ResetText();
            RText_Number.ResetText();
            RText_Landline.ResetText();
            Radio_F.Checked = false;
            Radio_M.Checked = true;
            Com_Spicaliztion.SelectedIndex = -1;

            DGV_Student.ClearSelection();
        }



        private void Frm_Students_Load(object sender, EventArgs e)
        {
            DGV_Student.ClearSelection();


        }

        private void btn_AddItem_Click(object sender, EventArgs e)
        {
            Frm_Additems Frm_item = new Frm_Additems();
            Frm_item.ShowDialog();
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            string Gender;
            if (Radio_M.Checked)
            {
                Gender = Radio_M.Text;
            }
            else
            {
                Gender = Radio_F.Text;
            }

            //-------------------------

            
            if (string.IsNullOrEmpty(RText_Name.Text) ||Com_Spicaliztion.SelectedIndex == -1)
            {
                MessageBox.Show("لا يمكن ترك بيانات الاسم فارغة أو الاختصاص ", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                 if ( Check_NameStudent() != null)
                 {
                     if (MessageBox.Show("                , هذا الاسم موجود سابقا  \n سيكون لديك تشابه في أسماء الطلاب \n       هل تريد إكمال عملية الإضافة ؟ ", "معلومات ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                         return;
                 }

                student.Add_Student(RText_Name.Text, RText_Number.Text, RText_Landline.Text, Gender, Convert.ToInt32(Com_Spicaliztion.SelectedValue));
                MessageBox.Show("تمت عملية الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Fill_DGV_Students();
                Check_DGV_Size();
                Btn_Reset_Click(sender, e);

            }


        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (DGV_Student.SelectedRows.Count > 0)
            {
                MessageBox.Show("            تحذير : عند حذف طالب سيتم حذف  \n  (كامل نشاطاته (الكورسات الخاصة به ..الخ   ", "تحذير ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (MessageBox.Show(" تأكيد عملية الحذف ؟ ", "عملية الحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    student.Delete_Student(Convert.ToInt32(DGV_Student.CurrentRow.Cells[0].Value));
                    Fill_DGV_Students();
                    Btn_Reset_Click(sender, e);
                }
                else
                {
                    Btn_Reset_Click(sender, e);
                }
            }
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            string Gender;
            if (Radio_M.Checked)
            {
                Gender = Radio_M.Text;
            }
            else
            {
                Gender = Radio_F.Text;
            }
            if (string.IsNullOrEmpty(RText_Name.Text) || Com_Spicaliztion.SelectedIndex == -1)
            {
                MessageBox.Show("لا يمكن ترك بيانات الاسم فارغة أو الاختصاص ", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                try
                {
                     student.Update_Student(RText_Name.Text, RText_Number.Text, RText_Landline.Text, Gender, Convert.ToInt32(Com_Spicaliztion.SelectedValue), Convert.ToInt32(DGV_Student.CurrentRow.Cells[0].Value.ToString()));
                     MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Fill_DGV_Students();


                    if (Enable_BtnAdd == false)
                    {
                        Btn_Add.Enabled = true;
                    }
                    Btn_Update.Enabled = false;

                    Btn_Reset_Click(sender, e);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void DGV_Student_DoubleClick(object sender, EventArgs e)
        {
            if (DGV_Student.SelectedRows.Count == 0)
                return;

            string Gender = this.DGV_Student.CurrentRow.Cells[4].Value.ToString();

            if (Gender == "ذكر")
            {
                Radio_M.Checked = true;
            }
            else
            {
                Radio_F.Checked = true;
            }

            RText_Name.Text = DGV_Student.CurrentRow.Cells[1].Value.ToString();
            RText_Landline.Text = DGV_Student.CurrentRow.Cells[2].Value.ToString();
            RText_Number.Text = DGV_Student.CurrentRow.Cells[3].Value.ToString();
            Com_Spicaliztion.Text = DGV_Student.CurrentRow.Cells[5].Value.ToString();


            DGV_Student.ClearSelection();
            Btn_Update.Enabled = true;
            Enable_BtnAdd = false;
            Btn_Add.Enabled = false;
        }

        private void RText_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumber(e);            
        }

        private void RText_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyLetters(e);
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            DGV_Student.DataSource = student.Search_Student(RText_Search.Text);

            DGV_Student.ClearSelection();
        }

        private void RText_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Btn_Search_Click(sender, e);
                RText_Search.Focus();
            }

        }

        private void Frm_Students_StyleChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
