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
    }
}
