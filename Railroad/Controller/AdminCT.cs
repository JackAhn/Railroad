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
            trainDAO = TrainDAO.getInstance();
        }

        public List<string> get(string query)
        {
            return trainDAO.getStation(query);
        }

        public int set(List<string> data)
        {
            return trainDAO.setStation(data);
        }

        public void close()
        {
            trainDAO.closeConnect();
        }
    }
}
