using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;

namespace CaroGame
{
    public partial class Form1 : Form
    {
        #region Properties
        SocketConection socket;
        private SoundGame sound = new SoundGame();
        protected ChesBoardManger chesBoard = new ChesBoardManger();
        private string name = null;
        EpicWinning winner;
        #endregion

        #region Initalize
        public Form1(string name)
        {
            InitializeComponent();
            socket = new SocketConection();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.name = "Player";
            prcCoutDown.Step = ConsRegion.COUT_DOWN_Interval;
            txtNamePlayer.Text = name;
            chesBoard = new ChesBoardManger(pnlTableGame, txtNamePlayer, picMark);
            prcCoutDown.Maximum = ConsRegion.Tm_Max;
            tmStep.Interval = ConsRegion.TIME_STEP;        
            newGame();


        }
        #endregion

        private void resetControl()
        {
            txtNamePlayer.Text = name;
            chesBoard = new ChesBoardManger(pnlTableGame, txtNamePlayer, picMark);
            resetTimeStep();
        }

        private void resetTimeStep()
        {
            prcCoutDown.Value = 0;
            tmStep.Start();
        }

        void chesBoard_EndGameEvent(object sender, EventArgs e)
        {
            chesBoard.changeColorBtnMarked();
            tmStep.Stop();
            pnlTableGame.Enabled = false;
           
            winner = new EpicWinning();
            winner.Text = "Happy " + chesBoard.NamePlayer;
            winner.Show();
            winner.Replay += Winner_Replay;
            winner.Quit += Winner_Quit;
        }

        private void Winner_Replay(object sender, EventArgs e)
        {
            newGame();
        }

        private void Winner_Quit(object sender, EventArgs e)
        {
            quitGame();
        }

        void chesBoard_PlayMarked(object sender, EventArgs e)
        {
            prcCoutDown.Value = 0;
            tmStep.Start();
        }

        private void newGame()
        {
            pnlTableGame.Enabled = true;
            pnlTableGame.Controls.Clear();
            resetControl();
            chesBoard.PlayerMarked += chesBoard_PlayMarked;
            chesBoard.EndGameEvent += chesBoard_EndGameEvent;
            chesBoard.drawChesBoard();
        }

        private void replayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sound.RestartSound.Play();
            newGame();
        }

        private void tmStep_Tick(object sender, EventArgs e)
        {
          //  prcCoutDown.PerformStep();
            if(prcCoutDown.Value == prcCoutDown.Maximum)
            {
                prcCoutDown.Value = 0;
                tmStep.Stop();
                System.Windows.Forms.DialogResult result = MessageBox.Show("Ban muon choi tiep khong??? \n Nếu tiếp tục ban sẽ mất lượt.",
                                                                       "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
             
                if (result == DialogResult.Yes)
                {
                    chesBoard.changePlayer();
                    tmStep.Start();
                }
                else if (result == DialogResult.No)
                    chesBoard_EndGameEvent(sender, e);
              
               
            }
        }
        
        private void quitGame()
        {
            Application.Exit();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quitGame();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban muon thoat khong???", "Note",
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();

            }
            else if (MessageBox.Show("Ban muon thoat khong???", "Note",
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!chesBoard.undo())
                MessageBox.Show("Khong the undo duoc nua!!!!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                sound.UndoSound.Play();
            this.resetTimeStep();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            socket.IP = txtID.Text;
            if(!socket.conectServer())
            {
                socket.createServer();
                Thread listenThread = new Thread(() => {
                    while (true)
                    {
                        Thread.Sleep(500);
                        try {
                            listen();
                            break;
                        }
                        catch { }
                        
                    }
                });
                listenThread.IsBackground = true;
                listenThread.Start();
               
            }
            else
            {
                Thread listenThread = new Thread(() => { listen(); });
                listenThread.IsBackground = true;
                listenThread.Start();
                socket.send("Data tu client ");
            }
           
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtID.Text = socket.getLocalIpV4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txtID.Text))
                txtID.Text = socket.getLocalIpV4(NetworkInterfaceType.Ethernet);
        }

        private void listen()
        {
            string data = (string)socket.receive();
            MessageBox.Show(data,"waning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }

}

