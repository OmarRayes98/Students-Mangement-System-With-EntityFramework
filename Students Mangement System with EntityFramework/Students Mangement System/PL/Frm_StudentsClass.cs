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
    public partial class Frm_StudentsClass : Form
    {
        BL.StudentsClass student_reg = new BL.StudentsClass();
        public Frm_StudentsClass()
        {
            InitializeComponent();
        }

        private void Frm_StudentsClass_SizeChanged(object sender, EventArgs e)
        {
        }

        private void Frm_StudentsClass_Load(object sender, EventArgs e)
        {
          

            DGV_InfoStudent.DataSource = student_reg.Show_Students(Frm_Class.idclass);

            DGV_InfoStudent.Columns[0].HeaderText="الرقم";
            DGV_InfoStudent.Columns[1].HeaderText = "اسم الطالب";
            DGV_InfoStudent.Columns[2].HeaderText = "الموبايل";
            DGV_InfoStudent.Columns[3].HeaderText = "الاختصاص";
            DGV_InfoStudent.Columns[4].HeaderText = "اسم الصف";
            DGV_InfoStudent.Columns[5].HeaderText = "تكاليف التسجيل";
            DGV_InfoStudent.Columns[6].HeaderText = "تاريخ التسجيل";
            DGV_InfoStudent.Columns[7].HeaderText = "تبرير الميلغ";
        }
    }
}
