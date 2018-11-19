using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                //MessageBox.Show(e.Message);
                return 0;
            }
        }

        public int addTicket(string memno, string memname, int trainno, string start, string end, string starttime, string endttime)
        {
            return 0;
        }

        public void closeConnect()
        {
            con.Close();
        }
    }
}
