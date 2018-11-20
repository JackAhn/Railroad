using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railroad.Model
{
    public class Ticket
    {
        public string ticketno { get; set; }
        public string memberno { get; set; }
        public string membername { get; set; }
        public string trainno { get; set; }
        public string departure { get; set; }
        public string destination { get; set; }
        public string starttime { get; set; }
        public string stoptime { get; set; }
        public string buytime { get; set; }
    }
}
