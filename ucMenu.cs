using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame
{
    public partial class ucMenu : UserControl
    {
        private event EventHandler eventMangLan, event1May, eventQuit, eventAiPlay;
        public event EventHandler EventMangLan
        {
            add { eventMangLan += value; }
            remove { eventMangLan -= value; }
        }

        public event EventHandler Event1May
        {
            add { event1May += value; }
            remove { event1May -= value; }
        }

        public event EventHandler EventQuit
        {
            add { eventQuit += value; }
            remove { eventQuit -= value; }
        }

        public event EventHandler EventAi
        {
            add { eventAiPlay += value; }
            remove { eventAiPlay -= value; }
        }
        public ucMenu()
        {
            InitializeComponent();
        }

        private void btnMangLan_Click(object sender, EventArgs e)
        {
            if (eventMangLan != null)
               eventMangLan(this, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (eventAiPlay != null)
                eventAiPlay(this, new EventArgs());
        }

        private void btn1May_Click(object sender, EventArgs e)
        {
            if (event1May != null)
                event1May(this, new EventArgs());
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (eventQuit != null)
                eventQuit(this, new EventArgs());
        }
    }
}
