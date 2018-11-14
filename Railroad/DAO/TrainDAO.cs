using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railroad.DAO
{
    public class TrainDAO
    {
        private static string url = "datasource=localhost;port=3306;username=root;password=1234;";
        private MySqlConnection con;
        private MySqlDataReader reader;
        private MySqlCommand command;
        private static TrainDAO instance;

        public TrainDAO()
        {
            con = new MySqlConnection(url);
            con.Open();
            command = con.CreateCommand();
        }
        public static TrainDAO getInstance()
        {
            if (instance == null)
                instance = new TrainDAO();
            return instance;
        }
    }
}
