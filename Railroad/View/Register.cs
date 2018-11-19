using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Railroad.DAO;
using Railroad.Model;
using Railroad.Controller;

namespace Railroad.View
{
    public partial class Register : Form
    {
        private MemberCT memberCT = new MemberCT();
        private string[] userData = new string[7];
        public Register()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 1; i <= 7; i++)
            {
                TextBox tb = (TextBox)this.Controls.Find("textBox" + i, true).FirstOrDefault();
                if (tb.Text.Equals(""))
                {
                    MessageBox.Show("공백을 채워주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb.Select();
                    return;
                }
                userData[i - 1] = tb.Text;
            }
            if (!userData[2].Equals(userData[3]))
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox3.Select();
                return;
            }
            Member member = new Member();
            memberCT.addMember(member, userData);

            //아이디 중복 db에서 확인
            if (memberCT.chkDuplicate(member.Mid)) //중복이 없다면
            {
                if (memberCT.addMember(member) == 1)
                {
                    MessageBox.Show("회원가입 성공");
                    this.Close();
                }
                else
                    MessageBox.Show("회원가입 실패");
            }
            else //중복이 있다면
            {
                MessageBox.Show("아이디 중복이 있습니다.");
            }
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            memberCT.close();
        }
    }
}
