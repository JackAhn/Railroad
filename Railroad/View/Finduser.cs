using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Railroad.Controller;
using Railroad.Model;

namespace Railroad.View
{
    public partial class Finduser : Form
    {
        private FindCT findCT;

        public Finduser(FindCT findCT)
        {
            InitializeComponent();
            this.findCT = findCT;
            this.CenterToScreen();
        }


    }
}
