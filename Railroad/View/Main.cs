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
        private TrainDAO trainDAO;
        private static List<Train> trainData = new List<Train>();

        public Main()
        {
            InitializeComponent();
            this.CenterToScreen();
            mct = new MainCT();
            trainDAO = TrainDAO.getInstance();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (mct.Checknull() == true)
            {
                this.logbtn.Text = "로그인";
                Login login = new Login(this, mct);
                login.Show();
            }
            else
            {
                this.logbtn.Text = "로그아웃";
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            mct.setTrainData(trainData, trainDAO);
            traininfo = new Traininfo[trainData.Count];
            for(int i = 0; i < traininfo.Length; i++)
            {
                traininfo[i] = new Traininfo();
                flowLayoutPanel1.Controls.Add(traininfo[i]);
                traininfo[i].settrainNo = trainData[i].trainNo.ToString();
                traininfo[i].setdeparture = trainData[i].departure.ToString() + "\n" + trainData[i].starttime.ToString("yyyy-MM-dd HH:mm");
                traininfo[i].setdestination = trainData[i].destination.ToString() + "\n" + trainData[i].stoptime.ToString("yyyy-MM-dd HH:mm");
                traininfo[i].ticketbtn.Name = i + "";
                traininfo[i].ticketbtn.Click += new EventHandler(ticketbtn_click);
            }
        }

        private void logbtn_Click(object sender, EventArgs e)
        {
            if (this.logbtn.Text.Equals("로그인"))
            {
                Login login = new Login(this, mct);
                login.Show();
            }
            else
            {
                MessageBox.Show("로그아웃이 완료되었습니다.", "로그아웃 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.logbtn.Text = "로그인";
            }
        }

        private void ticketbtn_click(object sender, EventArgs e) //예매하기 버튼
        {

        }
    }
}
