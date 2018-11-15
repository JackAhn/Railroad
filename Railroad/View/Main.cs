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
                this.logbtn.Text = "로그인";
                Login login = new Login(this, mct);
                login.Show();
            }
            else
            {
                this.logbtn.Text = "로그아웃";
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            mct.setTrainData(this, trainDAO);
        }

        private void logbtn_Click(object sender, EventArgs e)
        {
            if (this.logbtn.Text.Equals("로그인"))
            {
                Login login = new Login(this, mct);
                login.Show();
            }
            else
            {
                MessageBox.Show("로그아웃이 완료되었습니다.", "로그아웃 완료", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.logbtn.Text = "로그인";
            }
        }
    }
}
