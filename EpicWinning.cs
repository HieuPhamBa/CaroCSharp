using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CaroGame
{
    public partial class EpicWinning : Form
    {
        private SoundGame sound = new SoundGame();
        public PictureBox picPlayer;
        private event EventHandler replay, quit;
        public event EventHandler Replay
        {
            add { replay += value; }
            remove { replay -= value; }
        }

        public event EventHandler Quit
        {
            add { quit += value; }
            remove { quit -= value; }
            
        }
        //private String option = "";
        
       
        public EpicWinning()
        {

            InitializeComponent();
            //picMark.SizeMode = PictureBoxSizeMode.StretchImage;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            sound.WinSound.Play();
        }

        private void btnRelay_Click(object sender, EventArgs e)
        {
            //this.Option = "r";
            sound.WinSound.Stop();
            this.Close();
            if (replay != null)
                replay(this, e);
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
           sound.WinSound.Stop();
            this.Close();
            if (quit != null)
                quit(this, e);
           
        }
    }
}
