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
        private Main main;
        private LoginCT loginCT;
        private FindCT findCT;

        public Login(Main main)
        {
            InitializeComponent();
            this.main = main;
            this.CenterToScreen();
            this.textBox2.PasswordChar = '＊';
            loginCT = new LoginCT(main);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register rs = new Register();
            rs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginCT.chkLogin(this, this.textBox1.Text, this.textBox2.Text);
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginCT.close();
            loginCT.isClose();
        }

        private void button3_Click(object sender, EventArgs e) //아이디&비번 찾기
        {
            findCT = new FindCT();
            findCT.showUser();
        }
    }
}
