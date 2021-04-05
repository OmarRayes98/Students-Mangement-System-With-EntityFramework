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
    public partial class Frm_Additems : Form
    {
        BL.Specializations Student_Sp = new BL.Specializations();
        public Frm_Additems()
        {
            InitializeComponent();   
            Fill_ListItems();
        }

        private void Frm_Additems_Load(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }
       
             private void Fill_ListItems()
        {
            listBox1.DataSource = Student_Sp.Fill_ListItems();
            listBox1.DisplayMember = "Name_Specializtion";
            listBox1.ValueMember = "Id_Specializtion";   
        }
        

        private void Btn_Add_Item_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RText_Items.Text) )
            {
                MessageBox.Show("لا يمكن ترك اسم الاختصاص فارغ  ", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Student_Sp.Add_Specialization(RText_Items.Text);
                MessageBox.Show("تمت عملية الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Fill_ListItems();
            }
            RText_Items.ResetText();
            listBox1.ClearSelected();

        }

        private void Btn_Delete_item_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItems.Count > 0)
                    if (MessageBox.Show(" تأكيد عملية الحذف ؟ ", "عملية الحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {

                        Student_Sp.Delete_Specialization(Convert.ToInt32(listBox1.SelectedValue));
                        Fill_ListItems();
                        listBox1.ClearSelected();
                    }
                    else
                    {
                        listBox1.ClearSelected();
                    }
            }
            catch (Exception ex) {  }

        }

        private void RText_Items_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();

        }

        private void RText_Items_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_Additems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_Add_Item_Click(sender, e);
            }  
        }

        private void Frm_Additems_FormClosed(object sender, FormClosedEventArgs e)
        {


              Frm_Students.getfrm_student.Com_Spicaliztion.DataSource = Student_Sp.Fill_ListItems();
              Frm_Students.getfrm_student.Com_Spicaliztion.DisplayMember = "Name_Specializtion";
              Frm_Students.getfrm_student.Com_Spicaliztion.ValueMember = "Id_Specializtion";

              Frm_Students.getfrm_student.Com_Spicaliztion.SelectedValue = 0;
        }
    }
}
