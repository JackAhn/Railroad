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
using Railroad.Model;

namespace Railroad.View
{
    public partial class Finduser : Form
    {
        private FindCT findCT;

        public Finduser(FindCT findCT)
        {
            InitializeComponent();
            this.findCT = findCT;
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //아이디 찾기
        {
            foreach (Control ct in tabPage1.Controls.OfType<TextBox>())
            {
                if(ct.Text.Equals(""))
                {
                    MessageBox.Show("공백이 있는지 확인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string name = this.textBox1.Text;
            string phone = this.textBox2.Text + "-" + this.textBox3.Text + "-" + this.textBox4.Text;
            string data = findCT.getID(name, phone);

            if (data != null)
            {
                DialogResult result = MessageBox.Show("회원님의 아이디는 " + data + " 입니다.\n비밀번호도 찾으시겠습니까?", "아이디 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if(result == DialogResult.OK)
                {
                    this.tabControl1.SelectedIndex = 1;
                    cleardata();
                    this.textBox6.Text = data;
                }
            }
            else
            {
                MessageBox.Show("일치하는 정보가 없습니다. 다시 확인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e) //비밀번호 찾기
        {
            foreach (Control ct in tabPage2.Controls.OfType<TextBox>())
            {
                if (ct.Text.Equals(""))
                {
                    MessageBox.Show("공백이 있는지 확인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string name = this.textBox5.Text;
            string id = this.textBox6.Text;
            string phone = this.textBox7.Text + "-" + this.textBox8.Text + "-" + this.textBox9.Text;
            string data = findCT.getPW(name, id, phone);
            if (data != null)
            {
                DialogResult result = MessageBox.Show("회원님의 비밀번호는 " + data + " 입니다.", "비밀번호 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleardata();
            }
            else
            {
                MessageBox.Show("일치하는 정보가 없습니다. 다시 확인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cleardata()
        {
            foreach (Control ct in tabControl1.Controls.OfType<TextBox>())
            {
                ct.Text = "";
            }
        }

        private void Finduser_FormClosing(object sender, FormClosingEventArgs e)
        {
            findCT.close();
        }

    }
}
