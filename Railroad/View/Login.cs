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
        private Admin admin;
        private LoginCT loginCT;

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

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginCT.close();
            //멤버 객체에 아무것도 없고 관리자 객체도 생성되지 않았다면
            if(loginCT.Checknull()==true && admin == null)
            {
                main.Close(); //메인 닫기
            }
        }
    }
}
