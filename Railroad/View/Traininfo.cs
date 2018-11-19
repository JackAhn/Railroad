using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railroad.View
{
    public partial class Traininfo : UserControl
    {
        public Traininfo()
        {
            InitializeComponent();
        }

        public string settrainNo
        {
            set { this.trainNo.Text = value; }
        }

        public string setdeparture
        {
            set { this.departure.Text = value; }
        }

        public string setdestination
        {
            set { this.destination.Text = value; }
        }

        public string setseat
        {
            set { this.seat.Text = value; }
        }

        public int seatct
        {
            get { return int.Parse(this.seat.Text); }
        }

        private void departure_Click(object sender, EventArgs e)
        {

        }
    }
}
