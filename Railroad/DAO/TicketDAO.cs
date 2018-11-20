using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Railroad.Model;

namespace Railroad.DAO
{
    public class TicketDAO
    {
        private static string url = "datasource=localhost;port=3306;username=root;password=1234;";
        private MySqlConnection con;
        private MySqlDataReader reader;
        private MySqlCommand command;
        private TicketDAO instance;

        public TicketDAO()
        {
            con = new MySqlConnection(url);
            con.Open();
            command = con.CreateCommand();
            executeNonQuery("use railroad");
        }

        public TicketDAO getInstance()
        {
            if (instance == null)
                instance = new TicketDAO();
            return instance;
        }

        private int executeNonQuery(string query) //쿼리문 작동 후 integer 반환
        {
            try
            {
                command.CommandText = query;
                return command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }

        public int addTicket(string memno, string memname, int trainno, string start, string end, string starttime, string endtime, string now)
        {
            try
            {
                string query = "insert into ticket values('0', '" + memno + "', '" + memname + "', '" + trainno + "', '" + start + "', '" + end + "', '" + starttime + "', '" + endtime + "', '" + now + "')";
                int data = executeNonQuery(query);
                executeNonQuery("update train set seat=seat-1 where trainno='" + trainno + "'");
                return data;
            } catch(MySqlException e)
            {
                return 0;
            }
        }

        public List<Ticket> getTicket(string memno, int trainno, string buytime)
        {
            try
            {
                string query = "select * from ticket where memberno='" + memno + "' and trainno='" + trainno + "' and buytime='" + buytime + "'";
                List<Ticket> data = new List<Ticket>();
                command.CommandText = query;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.ticketno = reader.GetString(0);
                    ticket.memberno = reader.GetString(1);
                    ticket.membername = reader.GetString(2);
                    ticket.trainno = reader.GetString(3);
                    ticket.departure = reader.GetString(4);
                    ticket.destination = reader.GetString(5);
                    ticket.starttime = reader.GetDateTime(6).ToString("yyyy-MM-dd HH:mm");
                    ticket.stoptime = reader.GetDateTime(7).ToString("yyyy-MM-dd HH:mm");
                    ticket.buytime = reader.GetDateTime(8).ToString("yyyy-MM-dd HH:mm");
                    data.Add(ticket);
                }
                return data;
            } catch(MySqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public void closeConnect()
        {
            con.Close();
        }
    }
}
