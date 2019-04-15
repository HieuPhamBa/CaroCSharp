using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame
{
    class SoundGame
    {
        private SoundPlayer restartSound, undoSound, clickSound, goWrong, winningSound;
        public SoundPlayer RestartSound
        {
            set { restartSound = value; }
            get { return restartSound; }

        }

        public SoundPlayer UndoSound
        {
            set { undoSound = value; }
            get { return undoSound; }
        }
        public SoundPlayer ClickSound
        {
            set { clickSound = value; }
            get { return clickSound; }
        }


        public SoundPlayer GoWrong {
            set { goWrong = value; }
            get { return goWrong; }  
        }

        public SoundPlayer WinSound
        {
            set { winningSound = value; }
            get { return winningSound; }
        }

        public SoundGame()
        {
            RestartSound = new SoundPlayer(Application.StartupPath + "\\button-20.wav");
            WinSound = new SoundPlayer(Application.StartupPath + "\\winner.wav");
            GoWrong = new SoundPlayer(Application.StartupPath + "\\beep-10.wav");
            ClickSound = new SoundPlayer(Application.StartupPath + "\\button-46.wav");
            UndoSound = new SoundPlayer(Application.StartupPath + "\\button-30.wav");
        }

    }
}
