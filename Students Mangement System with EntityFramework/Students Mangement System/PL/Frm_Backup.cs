using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Transactions;
using System.Windows.Forms;
using System.Data.Entity;

namespace Students_Mangement_System
{
    public partial class Frm_Backup : Form
    {
        Office_TutorialsEntities dbo = new Office_TutorialsEntities();
        
        public Frm_Backup()
        {
            InitializeComponent();            

        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RTxt_FileName.Text))
            {
                MessageBox.Show("الرجاء قم بتحديد مسار حفظ النسخة الاحتياطية  ", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                return;
            }
            try
            {
                string filename = RTxt_FileName.Text + "\\Office_Tutorials" + DateTime.Now.ToShortDateString().Replace('/', '-') + " - " +
                    DateTime.Now.ToLongTimeString().Replace(':', '-');

                string Query = "Backup Database Office_Tutorials to Disk = '" + filename + ".bak'";
                 dbo.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,Query);

                MessageBox.Show("تم إنشاء النسخة اختياطية بنجاح ", "إنشاء النسخة احتياطية ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("  حدث خطأ لم يتم إنشاء نسخة احتياطية \n  لأنه ليس لديك الإذن بالحفظ في ذاك المجلد ", "استعادة النسخة احتياطية ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                RTxt_FileName.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Btn_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog File = new OpenFileDialog();
            File.Filter = "bak(*.bak)|*.bak";

            if (File.ShowDialog() == DialogResult.OK)
            {
                RTxt_file.Text = File.FileName;
            }
        }

        private void Btn_Rstore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RTxt_file.Text))
            {
                MessageBox.Show("الرجاء قم بتحديد مسار تواجد  النسخة الاحتياطية  ", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                return;
            }

            try
            {

                string Query = "Alter Database Office_Tutorials Set Offline With Rollback Immediate; Restore Database Office_Tutorials From Disk='" + RTxt_file.Text + "'";

                dbo.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, Query);

                MessageBox.Show("تم استعادة النسخة احتياطية بنجاح ", "استعادة النسخة احتياطية ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("  حدث خطأ \n  ", "  لم يتم استعادة النسخة احتياطية ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
