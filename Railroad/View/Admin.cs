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
        private TrainDAO trainDAO;

        public Admin(Main main)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.main = main;
            adminCT = new AdminCT();
            trainDAO = TrainDAO.getInstance();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            trainDAO.closeConnect();
            main.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Visible = true;
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
                    this.comboBox1.Items.Add(list[i]);
                }
            }
            else if (what == 1)
            {
                this.comboBox2.Items.Clear();
                //도착역 콤보박스 추가
                for(int i = 0; i < list.Length; i++)
                {
                    this.comboBox2.Items.Add(list[i]);
                }
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            List<string> data = trainDAO.getStation("select desname from destination order by desno asc");
            setcomboBox(data,0);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            List<string> data = trainDAO.getStation("select desname from destination order by desno desc");
            setcomboBox(data,0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //출발역 설정
        {
            MessageBox.Show(comboBox1.SelectedIndex+"");
            List<string> data = trainDAO.getStation("select desname from destination where desno >'" + (comboBox1.SelectedIndex + 1) + "'");
            setcomboBox(data, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.comboBox3.SelectedIndex==-1 || this.textBox13.Text.Equals(""))
            {
                MessageBox.Show("공백이 있는지 확인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> data = trainDAO.getStation("select desname from destination");
            int ind = data.IndexOf(this.comboBox3.SelectedItem.ToString());
            data.Insert(ind, this.textBox13.Text);

            if (trainDAO.setStation(data) == 1)
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
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            this.comboBox3.Text = "";
            this.textBox13.Text = "";

            List<string> data = trainDAO.getStation("select desname from destination order by desname asc");
            this.comboBox3.Items.Clear();
            this.comboBox3.Items.AddRange(data.ToArray());
            setcomboBox(data, 0);
        }
    }
}
