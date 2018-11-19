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
    public partial class Admin : Form
    {
        private Main main;
        private AdminCT adminCT;

        public Admin(Main main)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.main = main;
            adminCT = new AdminCT();
            this.comboBox1.Sorted = false;
            this.comboBox2.Sorted = false;
            this.comboBox3.Sorted = false;
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminCT.close();
            Login login = new Login(main);
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            afterRegis();
        }

        private void setcomboBox(List<string> data, int what) //출발, 도착 콤보박스 추가
        {
            string[] list = data.ToArray(); //리스트를 배열로 변경


            if (what == 0)
            {
                this.comboBox1.Items.Clear(); //콤보박스 초기화
                //출발역 콤보박스 추가
                for (int i = 0; i < list.Length - 1; i++)
                {
                    //MessageBox.Show(list[i]);
                    this.comboBox1.Items.Insert(i, list[i]);
                }
            }
            else if (what == 1)
            {
                this.comboBox2.Items.Clear();
                //도착역 콤보박스 추가
                for(int i = 0; i < list.Length; i++)
                {
                    this.comboBox2.Items.Insert(i, list[i]);
                }
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            List<string> data = adminCT.get("select desname from destination order by desno asc"); //get() = 목적지를 가져옴
            setcomboBox(data,0);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            List<string> data = adminCT.get("select desname from destination order by desno desc");
            setcomboBox(data,0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //출발역 설정
        {
            //MessageBox.Show(comboBox1.SelectedIndex+"");
            List<string> data= new List<string>();
            if (this.radioButton1.Checked == true)
            {
                data = adminCT.get("select desname from destination where desno >'" + (comboBox1.SelectedIndex + 1) + "'");
            }
            else if (this.radioButton2.Checked == true)
            {
                data = adminCT.get("select desname from destination where desno <'" + (comboBox1.SelectedIndex + 1) + "'");
            }
            setcomboBox(data, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.comboBox3.SelectedIndex==-1 || this.textBox13.Text.Equals(""))
            {
                MessageBox.Show("공백이 있는지 확인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> data = adminCT.get("select desname from destination");
            int ind = data.IndexOf(this.comboBox3.SelectedItem.ToString());
            data.Insert(ind + 1, this.textBox13.Text);

            if (adminCT.set(data) == 1) //set() = 목적지 등록
            {
                MessageBox.Show("등록이 완료되었습니다.\n자동 새로고침이 진행됩니다.", "등록 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                afterRegis();
                return;
            }
        }
        //처음 로딩 or 등록 후 초기화 소스
        private void afterRegis()
        {
            this.radioButton1.Select();

            //콤보박스 선택 인덱스 초기화
            this.comboBox1.SelectedIndex = -1;
            this.comboBox2.SelectedIndex = -1;
            this.comboBox3.SelectedIndex = -1;

            //기차 등록 텍스트박스 초기화
            foreach(Control ct in splitContainer1.Panel1.Controls.OfType<TextBox>())
            {
                ct.Text = null;
            }
            //목적지 추가 텍스트박스 초기화
            this.textBox13.Text = null;

            List<string> data = adminCT.get("select desname from destination order by desno asc");
            this.comboBox3.Items.Clear();
            for(int i = 0; i < data.Count; i++)
            {
                this.comboBox3.Items.Insert(i, data[i]);
            }
            setcomboBox(data, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //에러 컨트롤
            foreach (Control ct in splitContainer1.Panel1.Controls.OfType<TextBox>())
            {
                int a = 0;
                bool result = int.TryParse(ct.Text, out a);
                if (ct.Text.Equals(""))
                {
                    MessageBox.Show("공백이 있는지 확인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!result)
                {
                    MessageBox.Show("숫자로 입력해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if(this.comboBox1.SelectedIndex==-1 || this.comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("출발역 또는 도착역을 선택해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string trainno = this.textBox1.Text;
            if (adminCT.chktrainNo(trainno))
            {
                MessageBox.Show("이미 등록된 기차번호입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string departure = this.comboBox1.Text;
            string starttime = this.textBox2.Text + "-" + this.textBox3.Text + "-" + this.textBox4.Text + " " + this.textBox5.Text + ":" + this.textBox6.Text;
            string destination = this.comboBox2.Text;
            string stoptime = this.textBox7.Text + "-" + this.textBox8.Text + "-" + this.textBox9.Text + " " + this.textBox10.Text + ":" + this.textBox11.Text;
            string seat = this.textBox12.Text;

            if(!adminCT.chkTime(starttime, stoptime))
            {
                MessageBox.Show("출발시간이 도착시간이랑 같거나 도착시간보다 늦으면 안 됩니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if(adminCT.chkDuplicate(starttime, stoptime))
            {
                MessageBox.Show("이 시간 사이에 운행하는 기차가 있습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(adminCT.insertTrain(trainno, departure, starttime, destination, stoptime, seat) == 1)
            {
                MessageBox.Show("등록되었습니다.", "등록 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                afterRegis();
            }
            else
            {
                MessageBox.Show("에러 발생", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
