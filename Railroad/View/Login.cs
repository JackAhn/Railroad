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
        private Main main;

        public Login(Main main, MainCT mct)
        {
            InitializeComponent();
            this.main = main;
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
            if(this.textBox1.Text.Equals("admin") && this.textBox2.Text.Equals("1234"))
            {
                MessageBox.Show("관리자님 환영합니다.", "관리자 로그인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                main.Visible = false;
                Admin admin = new Admin(main);
                admin.Show();
                return;
            }
            string membername = memberDAO.chkLogin(this.textBox1.Text, this.textBox2.Text); //회원 존재 유무에 따라 null 또는 회원의 이름 반환
            if(membername != null)
            {
                mct.setMemberdata(this.textBox1.Text, this.textBox2.Text, membername, memberDAO); //모델에 데이터 저장
                MessageBox.Show(membername + "님 환영합니다.", "로그인 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            memberDAO.closeConnect();
        }
    }
}
