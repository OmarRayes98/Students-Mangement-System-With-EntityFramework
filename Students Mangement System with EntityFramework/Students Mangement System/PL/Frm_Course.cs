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
    public partial class Frm_Course : Form
    {
        bool Enable_BtnAdd = true;
        BL.Courses course = new BL.Courses();
        public Frm_Course()
        {
            InitializeComponent();
            Fill_Course();

        }
        private void Fill_Course()
        {
            DGV_Course.DataSource=course.Fill_Courses();
            DGV_Course.Columns[0].HeaderText = "رقم الكورس";
            DGV_Course.Columns[1].HeaderText = "اسم الكورس";
            DGV_Course.Columns[2].HeaderText = "سعر الكورس";

            DGV_Course.Columns[2].DefaultCellStyle.Format = "C0";
            
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RText_Name.Text) || string.IsNullOrEmpty(RText_Cost.Text) )
            {
                MessageBox.Show("الرجاء إكمال المعلومات المطلوبة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                course.Add_Courses(RText_Name.Text, Convert.ToInt32(RText_Cost.Text));
                MessageBox.Show("تمت عملية الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Fill_Course();
                Btn_New_Click(sender, e);

            }

        }

        private void Btn_New_Click(object sender, EventArgs e)
        {
            Btn_Add.Enabled = true;
            Btn_Update.Enabled = false;

            RText_Name.ResetText();
            RText_Cost.ResetText();
            DGV_Course.ClearSelection();
        }

        private void Frm_Course_Load(object sender, EventArgs e)
        {
            DGV_Course.ClearSelection();
            RText_Name.Focus();
        }

        private void Frm_Course_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Btn_New_Click(sender, e);
            }  
        }

        private void DGV_Course_DoubleClick(object sender, EventArgs e)
        {
            if (DGV_Course.SelectedRows.Count == 0)
                return;

            RText_Name.Text = DGV_Course.CurrentRow.Cells[1].Value.ToString();
            RText_Cost.Text = DGV_Course.CurrentRow.Cells[2].Value.ToString();

            DGV_Course.ClearSelection();
            Btn_Update.Enabled = true;
            Enable_BtnAdd = false;
            Btn_Add.Enabled = false;
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Course.SelectedRows.Count > 0)
                    if (MessageBox.Show(" تأكيد عملية الحذف ؟ ", "عملية الحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        course.Delete_Course(Convert.ToInt32(DGV_Course.CurrentRow.Cells[0].Value.ToString()));
                        Fill_Course();
                        Btn_New_Click(sender, e);
                    }
                    else
                    {
                        Btn_New_Click(sender, e);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" لا يمكنك حذف كورس لانه يوجد معلومات مرتبطة به مثلا صفوف  ", "عملية الحذف ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                course.Update_Course(Convert.ToInt32(DGV_Course.CurrentRow.Cells[0].Value.ToString()), RText_Name.Text, Convert.ToInt32(RText_Cost.Text));

                MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Fill_Course();

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

        private void RText_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            Frm_Students student = new Frm_Students();
            student.OnlyNumber(e);
        }

        private void Frm_Course_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }
}
