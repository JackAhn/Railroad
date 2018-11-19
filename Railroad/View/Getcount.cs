using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railroad.View
{
    public partial class Getcount : Form
    {
        public string personCount { get; set; }
        private int max;

        public Getcount(int count)
        {
            InitializeComponent();
            this.CenterToScreen();
            max = count;
            this.label2.Text = "남은 자리 수 : " + max;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.personCount = "0";
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.numericUpDown1.Value > max || this.numericUpDown1.Value > 10)
            {
                MessageBox.Show("최대 선택 가능한 인원을 초과하였습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.personCount = this.numericUpDown1.Value.ToString();
            this.Hide();
        }
    }
}
