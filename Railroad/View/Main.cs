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
using Railroad.Model;

namespace Railroad.View
{
    public partial class Main : Form
    {
        private MainCT mct;
        private Traininfo[] traininfo;
        private static List<Train> trainData = new List<Train>();

        public Main()
        {
            InitializeComponent();
            this.CenterToScreen();
            mct = new MainCT();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
            Login login = new Login(this);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            updateView();
        }

        private void logbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("로그아웃이 완료되었습니다.", "로그아웃 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mct.setmemberNull();
            this.logbtn.Text = "로그인";
            this.Hide();
            Login login = new Login(this);
            login.Show();
        }

        private void ticketbtn_click(object sender, EventArgs e) //예매하기 버튼
        {
            Button b = sender as Button;
            int bct = int.Parse(b.Name);
            int count = traininfo[bct].seatct;

            if (mct.Checknull())
            {
                MessageBox.Show("로그인을 먼저 해 주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mct.Checkseat(count))
            {
                MessageBox.Show("위 기차는 매진되었습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Getcount getcount = new Getcount(count);
            getcount.ShowDialog();
            int data = int.Parse(getcount.personCount);
            getcount.Close();

            string memno = MainCT.member.memberno.ToString();
            string memname = MainCT.member.membername;
            int trainno = trainData[bct].trainNo;
            string depart = trainData[bct].departure;
            string destination = trainData[bct].destination;
            string start = trainData[bct].starttime.ToString("yyyy-MM-dd HH:mm");
            string stop = trainData[bct].stoptime.ToString("yyyy-MM-dd HH:mm");
            for(int i = 0; i < data; i++)
            {
                if(mct.setTicketData(memno, memname, trainno, depart, destination, start, stop) != 1)
                {
                    MessageBox.Show("에러 발생", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("구매가 완료되었습니다.\n티켓이 출력됩니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            updateView();
        }

        private void updateView()
        {
            flowLayoutPanel1.Controls.Clear(); //패널 내 아이템 클리어
            trainData.Clear(); //리스트 클리어
            DateTime datetime = DateTime.Now;
            string now = datetime.ToString("yyyy-MM-dd HH:mm:ss");
            string after = datetime.AddDays(5).ToString("yyyy-MM-dd") + " 23:59:59";
            this.label3.Text = now + " ~ " + after + " 까지의 기차 정보";
            mct.setTrainData(trainData, now, after);
            traininfo = new Traininfo[trainData.Count];
            for (int i = 0; i < traininfo.Length; i++)
            {
                traininfo[i] = new Traininfo();
                mct.setTrainInfo(this, i, traininfo[i], trainData);
                traininfo[i].ticketbtn.Click += new EventHandler(ticketbtn_click);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            mct.close();
        }


    }
}
