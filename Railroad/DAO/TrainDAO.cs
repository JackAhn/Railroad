using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            initDB(); //db 초기화
        }
        public static TrainDAO getInstance()
        {
            if (instance == null)
                instance = new TrainDAO();
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

        private void initDB()
        {
            try
            {
                try
                {
                    executeNonQuery("drop database railroad");
                }
                catch (MySqlException e)
                {
                    MessageBox.Show(e.Message);
                }

                executeNonQuery("create database railroad");
                executeNonQuery("use railroad");
                executeNonQuery("create table member(memberno int primary key not null auto_increment, membername varchar(20), memberid varchar(20), " +
                    "memberpw varchar(30), memberphone varchar(40))");
                executeNonQuery("create table train(trainno int primary key not null, departure varchar(20), starttime datetime, destination varchar(20), stoptime datetime," +
                    " seat int)");
                executeNonQuery("create table ticket(ticketno int, memberno int, membername varchar(15), trainno int, departure varchar(20), destination varchar(20), time datetime, " +
                    "foreign key(memberno) references member(memberno) on update cascade on delete cascade, foreign key(trainno) references train(trainno) on delete cascade)");
                MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd")+" 12:00:00");
                executeNonQuery("insert into train values ('1000', '서울','"+DateTime.Now.ToString("yyyy-MM-dd")+" 12:00:00', '부산', '" + DateTime.Now.ToString("yyyy-MM-dd") +" 15:00:00', '100')");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
