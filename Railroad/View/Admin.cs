using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Railroad.Controller;

namespace Railroad.View
{
    public partial class Admin : Form
    {
        private Main main;
        private AdminCT adminCT;

        public Admin(Main main)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.main = main;
            adminCT = new AdminCT();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Visible = true;
        }
    }
}
