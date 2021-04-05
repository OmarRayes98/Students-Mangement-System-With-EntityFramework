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
    public partial class Frm_OldBills : Form
    {
        BL.Cls_OldBill oldBill = new BL.Cls_OldBill();
        public Frm_OldBills()
        {
            InitializeComponent();
        }

        private void Frm_OldBills_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void FillDGV_OldBill()
        {

            DGV_OldBills.DataSource = oldBill.Fill_DGV(Frm_Bill.Com_student);

            DGV_OldBills.Columns[0].HeaderText = "الرقم";
            DGV_OldBills.Columns[1].HeaderText = "المدفوعات";
            DGV_OldBills.Columns[2].HeaderText = "الباقي";
            DGV_OldBills.Columns[3].HeaderText = "تاريخ الدفع";

            DGV_OldBills.Columns[1].DefaultCellStyle.Format = "C0";
            DGV_OldBills.Columns[2].DefaultCellStyle.Format = "C0";
        }
        private void Fill_Paid_TotalCost()
        {
           
                Rtext_Paid.Text = oldBill.Sum_Paid(Frm_Bill.Com_student).ToString() + " ل.س ";
              
                RText_Total.Text = oldBill.Sum_ValueReg(Frm_Bill.Com_student) + " ل.س ";
            
        }

        private void Fill_Name_Rest()
        {
            try
            {
                var results = oldBill.Show_Name_Rest(Frm_Bill.Com_student);

                if (results != null)
                {
                    foreach (Fill_Name_Rest_Result item in results)
                    {
                        RText_NameS.Text = item.Name;
                        RText_Rest.Text = item.Rest.ToString();
                    }

                }
            }
            catch(Exception ex) { }             
        }

        private void Frm_OldBills_Load(object sender, EventArgs e)
        {
            FillDGV_OldBill();
            Fill_Paid_TotalCost();
            Fill_Name_Rest();
            DGV_OldBills.ClearSelection();
        }
    }
}
