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
        private MemberDAO instance;

        public MemberDAO()
        {
            con = new MySqlConnection(url);
            con.Open();
            command = con.CreateCommand();
            executeNonQuery("use railroad");
        }

        public MemberDAO getInstance()
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
                //MessageBox.Show(e.Message);
                return 0;
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
                    reader.Close();
                    return false;
                }
                reader.Close();
                return true;
            } catch(MySqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public int insertMember(Member member)
        {
            return executeNonQuery("insert into member values" +
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
                    string data = reader.GetString("membername");
                    reader.Close();
                    return data;
                }
                reader.Close();
                return null;
            }catch(MySqlException e)
            {
                //MessageBox.Show(e.Message);
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
                    string data = reader.GetString("memberno");
                    reader.Close();
                    return data;
                }
                reader.Close();
                return null;
            }
            catch (MySqlException e)
            {
                //MessageBox.Show(e.Message);
                return null;
            }
        }

        public string findMemberid(string name, string phone)
        {
            try
            {
                string query = "select memberid from member where membername='" + name + "' and memberphone='" + phone + "'";
                command.CommandText = query;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string data = reader.GetString(0);
                    reader.Close();
                    return data;
                }
                reader.Close();
                return null;
            } catch (MySqlException e)
            {
                return null;
            }
        }

        public string findMemberpw(string name, string id, string phone)
        {
            try
            {
                string query = "select memberpw from member where membername='" + name + "' and memberid='" + id + "' and memberphone='" + phone + "'";
                command.CommandText = query;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string data = reader.GetString(0);
                    reader.Close();
                    return data;
                }
                reader.Close();
                return null;
            }
            catch (MySqlException e)
            {
                return null;
            }
        }

        public void closeConnect()
        {
            con.Close();
        }
    }
}
