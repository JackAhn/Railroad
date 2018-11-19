using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railroad.DAO;
using Railroad.Model;


namespace Railroad.Controller
{
    public class MemberCT
    {
        private MemberDAO memberDAO;

        public MemberCT()
        {
            memberDAO = new MemberDAO();
            memberDAO = memberDAO.getInstance();
        }

        public void addMember(Member member, string[] userData)
        {
            member.Mname = userData[0];
            member.Mid = userData[1];
            member.Mpw = userData[2];
            member.Mphone = userData[4] + "-" + userData[5] + "-" + userData[6];
        }

        public bool chkDuplicate(string id)
        {
            return memberDAO.isDuplicate(id);
        }

        public int addMember(Member member)
        {
            return memberDAO.insertMember(member);
        }

        public void close()
        {
            memberDAO.closeConnect();
        }
    }
}
