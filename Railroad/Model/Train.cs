using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railroad.View;
namespace Railroad.Model
{
    public class Train
    {
        public int trainNo { get; set; }
        public string departure { get; set; }
        public DateTime starttime { get; set; }
        public string destination { get; set; }
        public DateTime stoptime { get; set; }
        public int seat { get; set; }
    }
}
