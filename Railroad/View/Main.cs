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
    public partial class Main : Form
    {
        public static MainCT mct;
        public Main()
        {
            InitializeComponent();
            mct = new MainCT();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (mct.Checknull() == true)
            {
                Login login = new Login(mct);
                login.Show();
            }
        }
    }
}
