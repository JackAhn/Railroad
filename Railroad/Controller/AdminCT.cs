using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railroad.Model;
using Railroad.DAO;

namespace Railroad.Controller
{
    public class AdminCT
    {
        public static List<Station> stations = new List<Station>();
        private TrainDAO trainDAO;

        public AdminCT()
        {
            trainDAO = new TrainDAO();
            trainDAO = trainDAO.getInstance();
        }

        public List<string> get(string query)
        {
            return trainDAO.getStation(query);
        }

        public int set(List<string> data)
        {
            return trainDAO.setStation(data);
        }

        public bool chktrainNo(string trainno)
        {
            return trainDAO.isTrainexist(trainno);
        }

        public int insertTrain(string trainno, string departure, string starttime, string destination, string stoptime, string seat)
        {
            return trainDAO.addTrain(trainno, departure, starttime, destination, stoptime, seat);
        }

        public bool chkDuplicate(string starttime, string stoptime)
        {
            return trainDAO.isTimeDupliate(starttime, stoptime);
        }

        public bool chkTime(string starttime, string stoptime)
        {
            DateTime parseStart = DateTime.Parse(starttime);
            DateTime parseEnd = DateTime.Parse(stoptime);
            int result = DateTime.Compare(parseStart, parseEnd);
            if (result >= 0)
                return false;
            else
                return true;
        }

        public bool isBeforeTime(string starttime)
        {
            DateTime now = DateTime.Now;
            DateTime start = DateTime.Parse(starttime);
            int result = DateTime.Compare(now, start);
            if (result <= 0)
                return true;
            else
                return false;
        }

        public void close()
        {
            trainDAO.closeConnect();
        }
    }
}
