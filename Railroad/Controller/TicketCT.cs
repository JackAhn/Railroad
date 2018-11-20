using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railroad.View;
using Railroad.DAO;
using Railroad.Model;

namespace Railroad.Controller
{
    public class TicketCT
    {
        private TicketDAO ticketDAO;

        public TicketCT()
        {
            ticketDAO = new TicketDAO();
            ticketDAO = ticketDAO.getInstance();
        }

        public void addTicket(TicketForm ticket, string memno, int trainno, string buytime)
        {
            List<Ticket> data = ticketDAO.getTicket(memno, trainno, buytime);
            Ticketinfo[] ticketinfo = new Ticketinfo[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                ticketinfo[i] = new Ticketinfo();
                ticketinfo[i].setticketno = data[i].ticketno;
                ticketinfo[i].settrainno = data[i].trainno;
                ticketinfo[i].setstarttime = data[i].starttime;
                ticketinfo[i].setstoptime = data[i].stoptime;
                ticketinfo[i].setmembername = data[i].membername;
                ticketinfo[i].setmemberno = data[i].memberno;
                ticketinfo[i].setdeparture = data[i].departure;
                ticketinfo[i].setdestination = data[i].destination;
                ticket.flowLayoutPanel1.Controls.Add(ticketinfo[i]);
            }

        }

        public void close()
        {
            ticketDAO.closeConnect();
        }
    }
}
