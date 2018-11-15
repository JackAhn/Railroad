using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railroad.Model;
using Railroad.DAO;
using Railroad.View;

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
        public void setTrainData(List<Train> trainData, TrainDAO trainDAO)
        {
            object[,] data = trainDAO.getTrainData();

            for(int i = 0; i < data.GetLength(0); i++)
            {
                Train train = new Train();
                train.trainNo = (int)data[i, 0];
                train.departure = (string)data[i, 1];
                train.starttime = (DateTime)data[i, 2];
                train.destination = (string)data[i, 3];
                train.stoptime = (DateTime)data[i, 4];
                train.seat = (int)data[i, 5];
                trainData.Add(train);
            }
        }
    }
}
