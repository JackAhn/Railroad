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
    class MemberDAO
    {
        private static MemberDAO instance;

        public static MemberDAO getInstance()
        {
            if (instance == null)
                instance = new MemberDAO();
            return instance;
        }

        private static string url = "Server=localhost;Database=railroad;Uid=root;Pwd=1234";
        private MySqlConnection con;
        private MySqlDataReader reader;
        private MySqlCommand command;

        public bool isDuplicate(string id)
        {
            try
            {
                con = new MySqlConnection(url);
                con.Open();
                string query = "select memberid from member where memberid='"+id+"'";
                command = new MySqlCommand(query, con);
                reader = command.ExecuteReader();
                if (reader.Read())
                    return false;
                con.Close();
                return true;
            } catch(MySqlException e)
            {
                checkException(e.Number);
                return false;
            }
        }

        public int insertMember(Member member)
        {
            try
            {
                con = new MySqlConnection(url);
                con.Open();
                string query = "insert into member(memberno, membername, memberid, memberpw, memberphone) values('0', '"+member.Mname+"', '"+member.Mid+"', '"+member.Mpw+"', '"+member.Mphone+"')";
                command = new MySqlCommand(query, con);
                return command.ExecuteNonQuery();
            } catch(MySqlException e)
            {
                checkException(e.Number);
                return 0;
            }

        }

        public bool isLogin(string id, string pw)
        {
            try
            {
                con = new MySqlConnection(url);
                con.Open();
                string query = "select * from member where "
            }catch(MySqlException e)
            {

            }
        }

        private void checkException(int number)
        {
            switch (number)
            {
                case 0:
                    MessageBox.Show("연결 실패");
                    break;
                case 1045:
                    MessageBox.Show("db 아이디, 비밀번호 오류");
                    break;
            }
        }
    }
}
