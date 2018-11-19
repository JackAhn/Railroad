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
    //기차 관련 데이터베이스 관리
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
            executeNonQuery("use railroad");
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
                //MessageBox.Show(e.Message);
                return 0;
            }
        }

        private void initDB()
        {
            //처음 실행 시 기본 DB 데이터 추가
            //executeNonQuery("drop database railroad");
            if (executeNonQuery("create database railroad") == 0)
                return;
            executeNonQuery("use railroad");
            executeNonQuery("create table member(memberno int primary key not null auto_increment, membername varchar(20), memberid varchar(20), " +
                    "memberpw varchar(30), memberphone varchar(40))");
            executeNonQuery("create table train(trainno int primary key not null, departure varchar(20), starttime datetime, destination varchar(20), stoptime datetime," +
                    " seat int)");
            executeNonQuery("create table ticket(ticketno int, memberno int, membername varchar(15), trainno int, departure varchar(20), destination varchar(20), time datetime, " +
                    "foreign key(memberno) references member(memberno) on update cascade on delete cascade, foreign key(trainno) references train(trainno) on delete cascade)");
            executeNonQuery("create table destination(desno int primary key not null auto_increment, desname varchar(20))");
            executeNonQuery("insert into train values ('1000', '서울','"+DateTime.Now.ToString("yyyy-MM-dd")+" 12:00:00', '부산', '" + DateTime.Now.ToString("yyyy-MM-dd") +" 15:00:00', '100')");
            executeNonQuery("insert into destination values ('0', '부산')");
            executeNonQuery("insert into destination values ('0', '서울')");
            executeNonQuery("SET SQL_SAFE_UPDATES 0");
        }

        public object[,] getTrainData(string now, string after)
        {
            command.CommandText = "select count(*) from train where starttime>='" + now + "' and stoptime<='" + after + "'";
            reader = command.ExecuteReader();
            object [,] data= new object[0,0];
            if (reader.Read())
            {
                data = new object[reader.GetInt32(0), 6];
            }

            reader.Close();

            command.CommandText = "select * from train where starttime>='" + now + "' and stoptime<='" + after + "'";
            reader = command.ExecuteReader();
            int a = 0;
            while (reader.Read())
            {
                data[a,0] = reader.GetInt32(0);
                data[a,1] = reader.GetString(1);
                data[a,2] = reader.GetDateTime(2);
                data[a,3] = reader.GetString(3);
                data[a,4] = reader.GetDateTime(4);
                data[a,5] = reader.GetInt32(5);
                a++;
            }
            reader.Close();
            return data;
        }


        public List<string> getStation(string query) //관리자 폼에서 역명 데이터 가져옴
        {
            try
            {
                command.CommandText = query;
                reader = command.ExecuteReader();
                List<string> data = new List<string>();
                int a = 0;
                while (reader.Read())
                {
                    data.Insert(a, reader.GetString(0));
                    a++;
                }
                reader.Close();
                return data;
            } catch(MySqlException e)
            {
                return null;
            }
        }

        public int setStation(List<string> data) //역 추가
        {
            try
            {
                executeNonQuery("delete from destination");
                executeNonQuery("alter table destination auto_increment=1");
                for (int i = 0; i < data.Count; i++)
                {
                    if (i + 1 == data.Count)
                    {
                        return executeNonQuery("insert into destination values ('0', '" + data[i] + "')");
                    }
                    executeNonQuery("insert into destination values ('0', '" + data[i] + "')");
                }
                return 0;

            }catch(MySqlException e)
            {
                //MessageBox.Show(e.Message);
                return 0;
            }
        }

        public int addTrain(string memno, string memname, int trainno, string start, string end, string starttime, string endttime) //기차 추가
        {

        }

        public void closeConnect()
        {
            con.Close();
        }
    }
}
