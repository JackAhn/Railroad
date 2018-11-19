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
        private TrainDAO trainDAO;
        private TicketDAO ticketDAO;

        public MainCT()
        {
            trainDAO = new TrainDAO();
            ticketDAO = new TicketDAO();
            trainDAO = trainDAO.getInstance();
            ticketDAO = ticketDAO.getInstance();
        }

        public void setTrainData(List<Train> trainData, string now, string after)
        {
            object[,] data = trainDAO.getTrainData(now, after);

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

        public void setTrainInfo(Main main, int i, Traininfo traininfo, List<Train> trainData)
        {
            traininfo.settrainNo = trainData[i].trainNo.ToString();
            traininfo.setdeparture = trainData[i].departure.ToString() + "\n" + trainData[i].starttime.ToString("yyyy-MM-dd HH:mm");
            traininfo.setdestination = trainData[i].destination.ToString() + "\n" + trainData[i].stoptime.ToString("yyyy-MM-dd HH:mm");
            traininfo.ticketbtn.Name = i + "";
        }

        public int setTicketData(string memno, string memname, int trainno, string depart, string destination, string start, string stop)
        {
            return ticketDAO.addTicket(memno, memname, trainno, depart, destination, start, stop);
        }

        public void setmemberNull()
        {
            member = null;
        }
        public bool Checknull()
        {
            if (member.membername == null)
                return true;
            return false;
        }

        public void close()
        {
            trainDAO.closeConnect();
            ticketDAO.closeConnect();
        }
    }
}
