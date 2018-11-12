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
            string membername = memberDAO.chkLogin(this.textBox1.Text, this.textBox2.Text); //회원 존재 유무에 따라 null 또는 회원의 이름 반환
            if(membername != null)
            {
                mct.setMemberdata(this.textBox1.Text, this.textBox2.Text, membername, memberDAO); //모델에 데이터 저장
                MessageBox.Show(membername + "님 환영합니다.", "로그인 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
