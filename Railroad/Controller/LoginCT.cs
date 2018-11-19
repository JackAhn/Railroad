using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railroad.Controller;
using Railroad.View;
using Railroad.Model;
using Railroad.DAO;
using System.Windows.Forms;

namespace Railroad.Controller
{
    public class LoginCT
    {
        private MemberDAO memberDAO;
        private Main main;
        private Admin admin;

        public LoginCT(Main main)
        {
            this.main = main;
            memberDAO = new MemberDAO();
            memberDAO = memberDAO.getInstance();
        }

        public void chkLogin(Login login, string text1, string text2)
        {
            if (text1.Equals("admin") && text2.Equals("1234"))
            {
                MessageBox.Show("관리자님 환영합니다.", "관리자 로그인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                admin = new Admin(main);
                admin.Show();
                login.Close();
                return;
            }
            string membername = memberDAO.chkLogin(text1, text2); //회원 존재 유무에 따라 null 또는 회원의 이름 반환
            if (membername != null)
            {
                MainCT.member = new LoginMember();
                setMemberdata(text1, text2, membername, memberDAO); //모델에 데이터 저장
                MessageBox.Show(membername + "님 환영합니다.", "로그인 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                main.label1.Text = membername+"님 환영합니다.";
                main.Visible = true;
                login.Close();
                return;
            }
            else
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void setMemberdata(string id, string pw, string membername, MemberDAO memberDAO)
        {
            MainCT.member.memberno = int.Parse(memberDAO.findMemberno(id, pw));
            MainCT.member.memberid = id;
            MainCT.member.memberpw = pw;
            MainCT.member.membername = membername;
        }

        public bool Checknull()
        {
            if (MainCT.member == null)
                return true;
            return false;
        }

        public void isClose()
        {
            //멤버 객체에 아무것도 없고 관리자 객체도 생성되지 않았다면
            if (Checknull() == true && admin == null)
            {
                main.Close(); //메인 닫기
            }
        }

        public void close()
        {
            memberDAO.closeConnect();
        }
    }
}
