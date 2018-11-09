using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Railroad.View;
using Railroad.Controller;
using Railroad.DAO;

namespace Railroad
{
    public partial class Login : Form
    {
        private MemberDAO memberDAO;
        private MainCT mct;
        public Login(MainCT mct)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.textBox2.PasswordChar = '＊';
            this.mct = mct;
            memberDAO = MemberDAO.getInstance();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register rs = new Register();
            rs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(memberDAO.isLogin(this.textBox1.Text, this.textBox2.Text))
            {

            }
            else
            {

            }
        }
    }
}
