using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railroad.View
{
    public partial class Admin : Form
    {
        private Main main;

        public Admin(Main main)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.main = main;
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Visible = true;
        }
    }
}
