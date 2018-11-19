using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railroad.DAO;
using Railroad.View;
using Railroad.Model;

namespace Railroad.Controller
{
    public class FindCT
    {
        private MemberDAO memberDAO;

        public FindCT()
        {
            memberDAO = new MemberDAO();
            memberDAO = memberDAO.getInstance();
        }

        public void showUser()
        {
            Finduser user = new Finduser(this);
            user.Show();
        }

        public string getID(string name, string phoneno)
        {
            return memberDAO.findMemberid(name, phoneno);
        }

        public string getPW(string name, string id, string phoneno)
        {
            return memberDAO.findMemberpw(name, id, phoneno);
        }

        public void close()
        {
            memberDAO.closeConnect();
        }
    }
}
