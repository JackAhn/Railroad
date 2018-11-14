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
using Railroad.DAO;

namespace Railroad.View
{
    public partial class Main : Form
    {
        private MainCT mct;
        private TrainDAO trainDAO;

        public Main()
        {
            InitializeComponent();
            this.CenterToScreen();
            mct = new MainCT();
            trainDAO = TrainDAO.getInstance();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (mct.Checknull() == true)
            {
                Login login = new Login(this, mct);
                login.Show();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            mct.setTrainData(trainDAO);
        }
    }
}
