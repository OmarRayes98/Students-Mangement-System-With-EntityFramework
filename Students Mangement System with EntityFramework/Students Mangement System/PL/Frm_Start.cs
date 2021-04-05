using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students_Mangement_System.PL
{
    public partial class Frm_Start : Form
    {

        public Frm_Start()
        {
            InitializeComponent();
        }

        private void Frm_Start_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            this.Hide();
            Frm_Login log = new Frm_Login();
            log.ShowDialog();
        }
    }
}
