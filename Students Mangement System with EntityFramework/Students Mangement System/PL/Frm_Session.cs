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
    public partial class Frm_Session : Form
    {
        BL.Sessions session = new BL.Sessions();
        bool Enable_BtnAdd = true;
        public Frm_Session()
        {
            InitializeComponent();

            Fill_Choose_Class();
            Com_Class.SelectedValue = 0;
            FillDGV_Session();

        }
        private void FillDGV_Session()
        {
            DGV_Session.DataSource = session.Fill_Sessions();
            DGV_Session.Columns[0].HeaderText = "الرقم";
            DGV_Session.Columns[1].HeaderText = "اسم الصف";
            DGV_Session.Columns[2].HeaderText = "اليوم ";
            DGV_Session.Columns[3].HeaderText = "الوقت ";


        }

        private void Fill_Choose_Class()
        {
            Com_Class.DataSource = session.Fill_ChooseClass();
            Com_Class.DisplayMember = "Name";
            Com_Class.ValueMember = "Id_Class";

        }

        private void Frm_Session_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void Btn_New_Click(object sender, EventArgs e)
        {
            Btn_Add.Enabled = true;
            Btn_Update.Enabled = false;

            Com_Class.SelectedValue = 0;
            Com_Days.SelectedIndex = -1;
            DTP_time.Value = Convert.ToDateTime(DateTime.Now);
            DGV_Session.ClearSelection();

        }

        private void Frm_Session_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Btn_New_Click(sender, e);
            }
        }

        private void Frm_Session_Load(object sender, EventArgs e)
        {
            DGV_Session.ClearSelection();
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (Com_Class.SelectedIndex == -1 || Com_Days.SelectedIndex == -1)
            {
                MessageBox.Show("الرجاء إكمال المعلومات المطلوبة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                session.Add_Session(Com_Days.Text, DTP_time.Text, Convert.ToInt32(Com_Class.SelectedValue));

                MessageBox.Show("تمت عملية الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDGV_Session();

                Btn_New_Click(sender, e);

            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
             if (DGV_Session.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(" تأكيد عملية الحذف ؟ ", "عملية الحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    session.Delete_Session(Convert.ToInt32(DGV_Session.CurrentRow.Cells[0].Value));
                    FillDGV_Session();
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
                session.Update_Session(Com_Days.Text, DTP_time.Text, Convert.ToInt32(Com_Class.SelectedValue), Convert.ToInt32(DGV_Session.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FillDGV_Session();

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
        
        private void DGV_Session_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Session.SelectedRows.Count == 0)
                    return;

                Com_Class.Text = DGV_Session.CurrentRow.Cells[1].Value.ToString();
                Com_Days.Text = DGV_Session.CurrentRow.Cells[2].Value.ToString();
                DTP_time.Value = Convert.ToDateTime(DGV_Session.CurrentRow.Cells[3].Value.ToString());

                DGV_Session.ClearSelection();
                Btn_Update.Enabled = true;
                Enable_BtnAdd = false;
                Btn_Add.Enabled = false;
            }
            catch (Exception ex) { }
           
        }
    }
}

