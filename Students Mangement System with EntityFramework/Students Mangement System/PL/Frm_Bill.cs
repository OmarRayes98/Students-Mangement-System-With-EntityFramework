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
    public partial class Frm_Bill : Form
    {
        public static int Com_student;
        public static int CheckofOldBill = 0;
        BL.Cls_Bill bill = new BL.Cls_Bill();

        //for report
        public  Report.rpt_lastbills rpt = new Report.rpt_lastbills();
        DataSet ds = new DataSet();
        DataTable dt = new Models_DataSet.DataSet1.Print_LastBillDataTable();
        int Num_StudetPrint = 0;
        //end of report's variables 
        public Frm_Bill()
        {
            InitializeComponent();

            Fill_ComStudent();
            Com_NameS.SelectedValue = 0;

            Fill_DGV_Bill();
        }

        private void Fill_ComStudent()
        {
                Com_NameS.DataSource = bill.ShowComStudent();
                Com_NameS.DisplayMember = "Name";
                Com_NameS.ValueMember = "Id_S";
        }
        private void Fill_DGV_Bill()
        {

            DGV_Bill.DataSource = bill.ShowDGV_Bill();

            DGV_Bill.Columns[0].HeaderText = "الرقم";
            DGV_Bill.Columns[1].HeaderText = "اسم الطالب";
            DGV_Bill.Columns[2].HeaderText = "المبلغ المدفوع";
            DGV_Bill.Columns[3].HeaderText = "الباقي";
            DGV_Bill.Columns[4].HeaderText = "تاريخ الدفع";

            DGV_Bill.Columns[2].DefaultCellStyle.Format = "C0";
             DGV_Bill.Columns[3].DefaultCellStyle.Format = "C0";
             

        }
        private void Frm_Bill_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void Com_NameS_SelectedIndexChanged(object sender, EventArgs e)
        {
             try
             {
                 Com_student = Convert.ToInt32(Com_NameS.SelectedValue);
                 CheckofOldBill = Convert.ToInt32(Com_NameS.SelectedValue);


                int total = bill.Sum_Total(Convert.ToInt32(Com_NameS.SelectedValue));

                 if (total != 0)
                 {
                    RText_Total.Text = total.ToString();

                 }
             }
             catch (Exception ex) { }
        }

        private void RText_Paid_KeyPress(object sender, KeyPressEventArgs e)
        {
            Frm_Students student = new Frm_Students();
            student.OnlyNumber(e);
        }

        private void Frm_Bill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Btn_Reset_Click(sender, e);
            }
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Com_NameS.SelectedIndex = -1;
            RText_Paid.ResetText();
            RText_Rest.ResetText();
            RText_Total.ResetText();
            DTP_history.Value = Convert.ToDateTime(DateTime.Now);
            DGV_Bill.ClearSelection();
            Btn_Print.Enabled = false;


        }

        private void Frm_Bill_Load(object sender, EventArgs e)
        {
            DGV_Bill.ClearSelection();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
              if (DGV_Bill.SelectedRows.Count > 0)
              {
                  if (MessageBox.Show(" تأكيد عملية الحذف ؟ ", "عملية الحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                  {
                       bill.Delete_Bill(Convert.ToInt32(DGV_Bill.CurrentRow.Cells[0].Value));
                       Fill_DGV_Bill();
                       Btn_Reset_Click(sender, e);
                  }
                  else
                  {
                      Btn_Reset_Click(sender, e);
                  }}
        
    }

    private void Btn_Add_Click(object sender, EventArgs e)
    {
          if (Com_NameS.SelectedIndex == -1 || string.IsNullOrEmpty(RText_Paid.Text) || string.IsNullOrEmpty(RText_Total.Text) || string.IsNullOrEmpty(RText_Rest.Text))
          {
              MessageBox.Show("الرجاء إكمال المعلومات المطلوبة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
          }
          else
          {
                try
                {
                    bill.Add_Bill(Convert.ToInt32(RText_Paid.Text), Convert.ToInt32(RText_Rest.Text), DTP_history.Value, Convert.ToInt32(Com_NameS.SelectedValue));

                    MessageBox.Show("تمت عملية الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Fill_DGV_Bill();
                    Btn_Print.Enabled = true;
                    Num_StudetPrint = Convert.ToInt32(Com_NameS.SelectedValue);
                }
                catch(Exception ex) { }
          }
    }

    private void RText_Rest_Click(object sender, EventArgs e)
    {

            if (string.IsNullOrEmpty(RText_Total.Text) || string.IsNullOrEmpty(RText_Paid.Text))
            {
                return;
            }

            int Total = Convert.ToInt32(RText_Total.Text);
            int NewPaid = Convert.ToInt32(RText_Paid.Text);


                int OldPaid = bill.Sum_OldPaid(Convert.ToInt32(Com_NameS.SelectedValue));
                RText_Rest.Text = (Total - (NewPaid + OldPaid)).ToString();

            if (Convert.ToInt32(RText_Rest.Text) < 0)
            {
                MessageBox.Show("  (المبالغ التي تم دفعها (السابقة و الحالية \n   .قد تجاوزت المبلغ الكامل  ", "رسالة خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


    }

    private void RText_Rest_TextChanged(object sender, EventArgs e)
    {

    }

    private void DGV_Bill_DoubleClick(object sender, EventArgs e)
    {
          if (DGV_Bill.SelectedRows.Count == 0)
              return;

          Com_NameS.Text = DGV_Bill.CurrentRow.Cells[1].Value.ToString();
          RText_Paid.Text = DGV_Bill.CurrentRow.Cells[2].Value.ToString();
          RText_Rest.Text = DGV_Bill.CurrentRow.Cells[3].Value.ToString();
          DTP_history.Value = Convert.ToDateTime(DGV_Bill.CurrentRow.Cells[4].Value.ToString());

          DGV_Bill.ClearSelection();
    }



    private void Frm_Bill_Leave(object sender, EventArgs e)
    {
         CheckofOldBill = 0;
    }

        private void Btn_Search_Click(object sender, EventArgs e)
        {

            DGV_Bill.DataSource = bill.ShowDGV_Search(RText_Search.Text);

            DGV_Bill.ClearSelection();
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            Btn_Print.Enabled = false;


        }

        private void Btn_Print_Click_1(object sender, EventArgs e)
        {

            try
            {
                var result_print = bill.Last_Bill(bill.Sum_Total(Convert.ToInt32(Com_NameS.SelectedValue)), bill.Max_Bill());

                if (result_print != null)
                {
                    foreach (var dr in result_print)
                    {
                        DataRow row = dt.NewRow();

                        row[0] = dr.اسم_الطالب;
                        row[1] = dr.المبلغ_المدفوع;
                        row[2] = dr.الباقي;
                        row[3] = dr.تاريخ_الدفع;
                        row[4] = dr.المبلغ_الكامل;



                        dt.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("لا يوجد بيانات لطباعتها","البيانات فارغة",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

            }
            catch (Exception ex)
            {
            }

            ds.Tables.Add(dt);

            if (ds.Tables["Print_LastBill"].Rows.Count == 0)
            {
                MessageBox.Show("لا يوجد بيانات لطباعتها", "البيانات فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            rpt.Load("rpt_lastbills.rpt");
            rpt.SetDataSource(ds);

          //  rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
           // rpt.PrintToPrinter(1, false, 0, 0);

            Report.Frm_Report_LastBill f = new Report.Frm_Report_LastBill();
            f.Cursor = Cursor.Current;
            f.crystalReportViewer1.ReportSource = rpt;
            f.ShowDialog();
            ds.Reset();
        }
    }
        }


