using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railroad.Model;
using Railroad.DAO;

namespace Railroad.Controller
{
    public class MainCT
    {
        public static LoginMember member = new LoginMember(); //로그인한 회원의 데이터 저장을 위한 객체 생성

        public bool Checknull()
        {
            if (member.membername == null)
                return true;
            return false;
        }
        public void setMemberdata(string id, string pw, string membername, MemberDAO memberDAO)
        {
            member.memberno = int.Parse(memberDAO.findMemberno(id, pw));
            member.memberid = id;
            member.memberpw = pw;
            member.membername = membername;
        }
    }
}
