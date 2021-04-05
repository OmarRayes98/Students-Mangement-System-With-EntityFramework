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
    public partial class Frm_Registration : Form
    {
        bool Enable_BtnAdd = true;
        BL.Registration register = new BL.Registration();
        public Frm_Registration()
        {
            InitializeComponent();

            Fill_ComStudent();
            Com_NameS.SelectedValue = 0;

            Fill_ComClass();
            Com_NameC.SelectedValue = 0;

            FillDGV_Reg();

        }

        private void FillDGV_Reg()
        {

            DGV_Registration.DataSource = register.Show_SRegistrations();

            DGV_Registration.Columns[0].HeaderText = "الرقم";
            DGV_Registration.Columns[1].HeaderText = "اسم الطالب";
            DGV_Registration.Columns[2].HeaderText = "اسم الصف";
            DGV_Registration.Columns[3].HeaderText = "تاريخ التسجيل";
            DGV_Registration.Columns[4].HeaderText = "تكاليف التسجيل";
            DGV_Registration.Columns[5].HeaderText = "تبرير المبلغ";


            DGV_Registration.Columns[4].DefaultCellStyle.Format = "C0";

            foreach (DataGridViewColumn column in DGV_Registration.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (column == DGV_Registration.Columns[1])
                {
                    DGV_Registration.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    continue;
                }
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void Check_DGV_Size()
        {
            try
            {
                 if (DGV_Registration.Columns[0].Width <= 68)
                 {
                     DGV_Registration.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                 }
                 else
                 {
                     DGV_Registration.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                 }
            }
            catch(Exception ex) { }
        }


        private void Fill_ComStudent()
        {

            Com_NameS.DataSource = register.Fill_ChooseStudent();
            Com_NameS.DisplayMember = "Name";
            Com_NameS.ValueMember = "Id_S";
        }

        private void Fill_ComClass()
        {

            Com_NameC.DataSource = register.Fill_ChooseClass();
            Com_NameC.DisplayMember = "Name";
            Com_NameC.ValueMember = "Id_Class";
        }

        private void Frm_Registration_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void RadBtn_SepicalC_CheckedChanged(object sender, EventArgs e)
        {
            if (RadBtn_SepicalC.Checked == true)
            {
                RText_SpecialC.ReadOnly = false;
                RText_Cause.ReadOnly = false;
                RText_SpecialC.ResetText();
                RText_Cause.ResetText();
            }
            else
            {
                RText_SpecialC.ReadOnly = true;
                RText_Cause.ReadOnly = true;
                RText_SpecialC.Text = "المبلغ الخاص";
                RText_Cause.Text = "تبرير السعر";
            }
        }

        private void Frm_Registration_Load(object sender, EventArgs e)
        {
            DGV_Registration.ClearSelection();
            RText_SpecialC.Text = "المبلغ الخاص";
            RText_Cause.Text = "تبرير السعر";
            Check_DGV_Size();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Btn_Add.Enabled = true;
            Btn_Update.Enabled = false;

            Com_NameS.SelectedValue = 0;
            Com_NameC.SelectedValue = 0;
            Lbl_Course.Text = ". . . . .";
            Lbl_Cost.Text = ". . . . .";
            DTP_history.Value = Convert.ToDateTime(DateTime.Now);
            RadBtn_Cost.Checked = true;
            RadBtn_SepicalC.Checked = false;


            DGV_Registration.ClearSelection();
        }

        private void Frm_Registration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Btn_Reset_Click(sender, e);
            }
        }

        private void RText_SpecialC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Frm_Students student = new Frm_Students();
            student.OnlyNumber(e);
        }

        private void Com_NameC_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                var results = register.Show_Coures_Cost(Convert.ToInt32(Com_NameC.SelectedValue));
                
                if (results != null)
                {
                    foreach (Show_Course_Result item in results)
                    {
                        Lbl_Course.Text = item.Name;
                        Lbl_Cost.Text = item.Cost.ToString();
                    }

                }
            }
            catch (Exception ex) { }
        }

        Student_Regisrtation Check_FindStudentClass()
        {
            Student_Regisrtation check_nameStudent = new Student_Regisrtation();
            check_nameStudent = register.Check_FindStudentClass(Convert.ToInt32(Com_NameS.SelectedValue), Convert.ToInt32(Com_NameC.SelectedValue));
            return check_nameStudent;
        }
        
        Student_Regisrtation Check_FindStudentCourse()
        {
            Student_Regisrtation check_studentCourse = new Student_Regisrtation();
            check_studentCourse = register.Check_FindStudentCourse(Convert.ToInt32(Com_NameS.SelectedValue), Lbl_Course.Text);
            return check_studentCourse;
        }


        private void Btn_Add_Click(object sender, EventArgs e)
        {
            string RadBtnCost;
            string Cause;

            if (RadBtn_Cost.Checked)
            {
                RadBtnCost = Lbl_Cost.Text;
                Cause = RadBtn_Cost.Text;
            }
            else
            {
                RadBtnCost = RText_SpecialC.Text;
                Cause = RText_Cause.Text;
            }

            if (Com_NameS.SelectedIndex == -1 || Com_NameC.SelectedIndex == -1 || string.IsNullOrEmpty(RText_SpecialC.Text))
            {
                MessageBox.Show("الرجاء إكمال المعلومات المطلوبة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (Check_FindStudentClass() != null)
                {
                    MessageBox.Show("! هذا الطالب مسجل مسبقا بهذا الصف", "معلومات ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }
                else if (Check_FindStudentCourse() != null)
                {
                    MessageBox.Show(" , هذا الطالب مسجل مسبقا في هذا الكورس \n ! لا يمكن تسجيل طالب في أكثر من صف لأجل كورس واحد", "معلومات ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                register.Add_SRegistration(Convert.ToInt32(Com_NameS.SelectedValue), Convert.ToInt32(Com_NameC.SelectedValue), DTP_history.Value, Convert.ToInt32(RadBtnCost), Cause);
                MessageBox.Show("تمت عملية الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDGV_Reg();
                Check_DGV_Size();
                Btn_Reset_Click(sender, e);

            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (DGV_Registration.SelectedRows.Count > 0)
                if (MessageBox.Show(" تأكيد عملية الحذف ؟ ", "عملية الحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    register.Delete_Register(Convert.ToInt32(DGV_Registration.CurrentRow.Cells[0].Value));
                    FillDGV_Reg();
                    Btn_Reset_Click(sender, e);
                }
                else
                {
                    Btn_Reset_Click(sender, e);
                }
        }

        private void DGV_Registration_DoubleClick(object sender, EventArgs e)
        {
            if (DGV_Registration.SelectedRows.Count == 0)
                return;

            Com_NameS.Text = DGV_Registration.CurrentRow.Cells[1].Value.ToString();
            Com_NameC.Text = DGV_Registration.CurrentRow.Cells[2].Value.ToString();
            DTP_history.Value = Convert.ToDateTime(DGV_Registration.CurrentRow.Cells[3].Value.ToString());

            string cause = this.DGV_Registration.CurrentRow.Cells[5].Value.ToString();

            if (cause == "المبلغ الافتراضي")
            {
                RadBtn_Cost.Checked = true;

            }
            else
            {
                RadBtn_SepicalC.Checked = true;
                RText_SpecialC.Text = this.DGV_Registration.CurrentRow.Cells[4].Value.ToString();
                RText_Cause.Text = this.DGV_Registration.CurrentRow.Cells[5].Value.ToString();
            }

            DGV_Registration.ClearSelection();
            Btn_Update.Enabled = true;
            Enable_BtnAdd = false;
            Btn_Add.Enabled = false;
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
           string RadBtnCost;
            string Cause;

            if (RadBtn_Cost.Checked)
            {
                RadBtnCost = Lbl_Cost.Text;
                Cause = RadBtn_Cost.Text;
            }
            else
            {
                RadBtnCost = RText_SpecialC.Text;
                Cause = RText_Cause.Text;
            }

            if (Com_NameS.SelectedIndex == -1 || Com_NameC.SelectedIndex == -1 || string.IsNullOrEmpty(RText_SpecialC.Text))
            {
                MessageBox.Show("الرجاء إكمال المعلومات المطلوبة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                try
                {
                    register.Update_Register(Convert.ToInt32(Com_NameS.SelectedValue), Convert.ToInt32(Com_NameC.SelectedValue), DTP_history.Value, Convert.ToInt32(RadBtnCost), Cause, Convert.ToInt32(DGV_Registration.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDGV_Reg();
                    Check_DGV_Size();


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

        private void RText_Search_TextChanged(object sender, EventArgs e)
        {

            DGV_Registration.DataSource = register.Search_SRegister(RText_Search.Text);

            DGV_Registration.Columns[0].HeaderText = "الرقم";
            DGV_Registration.Columns[1].HeaderText = "اسم الطالب";
            DGV_Registration.Columns[2].HeaderText = "اسم الصف";
            DGV_Registration.Columns[3].HeaderText = "تاريخ التسجيل";
            DGV_Registration.Columns[4].HeaderText = "تكاليف التسجيل";
            DGV_Registration.Columns[5].HeaderText = "تبرير المبلغ";

            DGV_Registration.ClearSelection();
        }

        private void Com_NameS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

