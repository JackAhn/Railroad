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

        public Getcount()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.personCount = "0";
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.personCount = this.numericUpDown1.Value.ToString();
            this.Hide();
        }
    }
}
