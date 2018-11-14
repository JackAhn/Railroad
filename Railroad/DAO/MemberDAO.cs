using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railroad.Model;
using System.Windows.Forms;

namespace Railroad.DAO
{
    public class MemberDAO
    {
        private static string url = "datasource=localhost;port=3306;username=root;password=1234;";
        private MySqlConnection con;
        private MySqlDataReader reader;
        private MySqlCommand command;
        private static MemberDAO instance;

        public MemberDAO()
        {
            con = new MySqlConnection(url);
            con.Open();
            command = con.CreateCommand();
            initDB(); //db 초기화
        }

        public static MemberDAO getInstance()
        {
            if (instance == null)
            {
                instance = new MemberDAO();
            }
            return instance;
        }

        private int executeNonQuery(string query)
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
                }catch(MySqlException e)
                {
                    MessageBox.Show(e.Message);
                }

                executeNonQuery("create database railroad");
                executeNonQuery("use railroad");
                executeNonQuery("create table member(memberno int primary key not null auto_increment, membername varchar(20), memberid varchar(20), " +
                    "memberpw varchar(30), memberphone varchar(40))");
                executeNonQuery("create table train(trainno int primary key not null, departure varchar(20), starttime date, destination varchar(20), stoptime date," +
                    " seat int)");
                executeNonQuery("create table ticket(ticketno int, memberno int, membername varchar(15), trainno int, departure varchar(20), destination varchar(20), time date, " +
                    "foreign key(memberno) references member(memberno) on update cascade on delete cascade, foreign key(trainno) references train(trainno) on delete cascade)");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool isDuplicate(string id)
        {
            try
            {
                string query = "select memberid from member where memberid='"+id+"'";
                command.CommandText = query;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return false;
                }
                return true;
            } catch(MySqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public int insertMember(Member member)
        {
            return executeNonQuery("insert into member(memberno, membername, memberid, memberpw, memberphone) values" +
                   "('0', '" + member.Mname + "', '" + member.Mid + "', '" + member.Mpw + "', '" + member.Mphone + "')");
        }

        public string chkLogin(string id, string pw)
        {
            try
            {
                string query = "select * from member where memberid='"+id+"' and memberpw='"+pw+"'";
                command.CommandText = query;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetString("membername");
                }
                return null;
            }catch(MySqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public string findMemberno(string id, string pw)
        {
            try
            {
                string query = "select memberno from member where memberid='" + id + "' and memberpw='" + pw + "'";
                command.CommandText = query;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetString("memberno");
                }
                return null;
            }
            catch (MySqlException e)
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
