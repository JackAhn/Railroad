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
    public partial class TicketForm : Form
    {
        private TicketCT tct;
        private string memno;
        private int trainno;
        private string now;

        public TicketForm(string memno, int trainno, string now)
        {
            InitializeComponent();
            this.CenterToScreen();
            tct = new TicketCT();
            this.memno = memno;
            this.trainno = trainno;
            this.now = now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            tct.addTicket(this, memno, trainno, now);
        }

        private void TicketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tct.close();
        }
    }
}
