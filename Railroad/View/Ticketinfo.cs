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
    public partial class Ticketinfo : UserControl
    {
        public Ticketinfo()
        {
            InitializeComponent();
        }

        public string setticketno
        {
            set { this.ticketNo.Text = value; }
        }

        public string settrainno
        {
            set { this.trainno.Text = "Train No. " + value; }
        }

        public string setmemberno
        {
            set { this.memberno.Text = value; }
        }

        public string setmembername
        {
            set { this.membername.Text = value; }
        }

        public string setdeparture
        {
            set { this.departure.Text = value; }
        }
        public string setstarttime
        {
            set { this.starttime.Text = value; }
        }
        public string setdestination
        {
            set { this.destination.Text = value; }
        }
        public string setstoptime
        {
            set { this.stoptime.Text = value; }
        }
    }
}
