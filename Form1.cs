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
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net.Sockets;

namespace CaroGame
{
    public partial class Form1 : Form
    {
        #region Properties
        SocketManager socket;
        private SoundGame sound = new SoundGame();
        protected ChesBoardManger chesBoard = new ChesBoardManger();
        private string name = null;
        private bool lanPlay = true;
        private bool aiPlay = false;
        private bool isEndGame = false;
        EpicWinning winner;
        #endregion

        #region Initalize
        public Form1(string name)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            pnlTableGame.Visible = false;
            _ucMenu.Visible = true;
            pnlLanInfo.Visible = false;
            prcCoutDown.Value = 0;
            socket = new SocketManager();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.name = "Player";
            prcCoutDown.Step = ConsRegion.COUT_DOWN_Interval;
            txtNamePlayer.Text = name;
            chesBoard = new ChesBoardManger(pnlTableGame, txtNamePlayer, picMark);
            prcCoutDown.Maximum = ConsRegion.Tm_Max;
            tmStep.Interval = ConsRegion.TIME_STEP;
            lanGame(false);
            mnTab.Visible = false;
            _ucMenu.EventQuit    += _ucMenu_EventQuit;
            _ucMenu.Event1May    += _ucMenu_Event1May;
            _ucMenu.EventMangLan += _ucMenu_EventMangLan;
            _ucMenu.EventAi += _ucMenu_EventAi;
        }

        private void _ucMenu_EventAi(object sender, EventArgs e)
        {
            this.lanPlay = false;
            this.aiPlay = true;
            pnlLanInfo.Visible = false;
            mnTab.Visible = true;
            pnlTableGame.Visible = true;
            _ucMenu.Visible = false;
            newGame();
        }

        private void _ucMenu_EventMangLan(object sender, EventArgs e)
        {
            _ucMenu.Visible = false;
            pnlTableGame.Visible = true;
            aiPlay = false;
            lanGame(true);
            newGame();
        }

        private void _ucMenu_Event1May(object sender, EventArgs e)
        {
            aiPlay = false;
            _ucMenu.Visible = false;
            pnlTableGame.Visible = true;
            lanGame(false);
            newGame();
        }

        private void _ucMenu_EventQuit(object sender, EventArgs e)
        {
            quitGame();
        }
        #endregion

        private void resetControl()
        {
            txtNamePlayer.Text = name;
            chesBoard = new ChesBoardManger(pnlTableGame, txtNamePlayer, picMark);
          //  resetTimeStep();
        }

        private void lanGame(bool status)
        {
            lanPlay = status;
            pnlLanInfo.Visible = status;
            mnTab.Visible = true;
        }

        private void resetTimeStep()
        {
            prcCoutDown.Value = 0;
            tmStep.Start();
        }

        void chesBoard_EndGameEvent(object sender, EventArgs e)
        {
            this.aiPlay = false;
            this.lanPlay = false;
            this.isEndGame = true;
            chesBoard.changeColorBtnMarked();
            tmStep.Stop();
            pnlTableGame.Enabled = false;
            endGame();
            winner = new EpicWinning();
            winner.Text = "Happy " + chesBoard.NamePlayer;
            winner.Show();
            winner.Replay += Winner_Replay;
            winner.Quit += Winner_Quit;
        }

        private void endGame()
        {
            if (lanPlay)
                socket.Send(new SocketData((int)SocketComand.EndGame, "", new Point()));
        }
        private void Winner_Replay(object sender, EventArgs e)
        {
            newGame();
        }

        private void Winner_Quit(object sender, EventArgs e)
        {
            quitGame();
        }

        void chesBoard_PlayMarked(object sender, ButtonClickedEvent e)
        {
            
            if (lanPlay)
            {
                listen();
                pnlTableGame.Enabled = false;
                socket.Send(new SocketData((int)SocketComand.SendPoint, "", e.clickedPoint));
            }
            if (!isEndGame)
            {
                
                if (aiPlay)
                {
                    resetTimeStep();
                    Point pnt = chesBoard.getAiPoint();
                    chesBoard.otherPlayClicked(pnt);
                }
                resetTimeStep();
            }
            else
            {
              //  chesBoard.EndGameEvent += chesBoard_EndGameEvent;
                isEndGame = false;
            }
                
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
            if (lanPlay)
                socket.Send(new SocketData((int)SocketComand.Replay,"",new Point()));
            newGame();
        }

        private void tmStep_Tick(object sender, EventArgs e)
        {
            prcCoutDown.PerformStep();
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
                if (lanPlay)
                {
                    socket.Send(new SocketData((int)SocketComand.QuitGame, "", new Point()));
                    if (socket.isServer)
                    {
                        try
                        {
                           // socket.server.Disconnect(true);
                            socket.server.Shutdown(SocketShutdown.Both);
                            socket.server.Close();
                            
                        }
                        catch(SocketException es)
                        {

                        }
                       

                    }

                    else
                    {
                        try
                        {
                           // socket.client.Disconnect(true);
                            socket.client.Shutdown(SocketShutdown.Both);
                            socket.client.Close(); 
                        }
                        catch(SocketException ex)
                        {

                        }
                        
                    }
                    Application.Exit();
                }
                   

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
            if (lanPlay)
            {
                socket.Send(new SocketData((int)SocketComand.Undo, "", new Point()));
                chesBoard.undo();
            }
               
           // Application.Exit();
            this.resetTimeStep();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            socket.IP = txtID.Text;

            if(!socket.ConnectServer())
            {
                socket.isServer = true;
                pnlTableGame.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                pnlTableGame.Enabled = false;
                listen();
            }
           
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtID.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if(string.IsNullOrEmpty(txtID.Text))
            {
                txtID.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        private void listen()
        {
            Thread listenThread = new Thread(() => {
                try
                {
                    SocketData data = (SocketData)socket.Receive();
                    //MessageBox.Show((string)data);
                    processData(data);
                }
                catch { }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
      
        }

        private void processData(SocketData data)
        {
            switch (data.Cmd)
            {
                case (int)SocketComand.SendPoint:
                    this.Invoke((MethodInvoker) (()=>
                        {
                            pnlTableGame.Enabled = true;
                            this.resetTimeStep();
                            chesBoard.otherPlayClicked(data.PointData);
                        }
                        ));
                    
                    break;
                case (int)SocketComand.Notify:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketComand.Replay:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        newGame();
                    }));
                    break;
                case (int)SocketComand.QuitGame:
                    tmStep.Stop();
                    MessageBox.Show("Doi phuong da quit game", "warnning!!!");
                    socket.Send(new SocketData((int)SocketComand.QuitGame, "", new Point()));
                    if (socket.isServer)
                    {
                        try
                        {
                           // socket.server.Disconnect(true);
                            socket.server.Shutdown(SocketShutdown.Both);
                            socket.server.Close();

                        }
                        catch (SocketException es)
                        {

                        }


                    }

                    else
                    {
                        try
                        {
                            //socket.client.Disconnect(true);
                            socket.client.Shutdown(SocketShutdown.Both);
                            socket.client.Close();
                        }
                        catch (SocketException ex)
                        {

                        }

                    }


                    break;
                case (int)SocketComand.Undo:
                    chesBoard.undo();
                    chesBoard.undo();
                    break;
                case (int)SocketComand.EndGame:
                    MessageBox.Show("Doi phuong da ket thuc game");
                    break;
            }   
            listen();
            
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlLanInfo.Visible = false;
            pnlTableGame.Visible = false;
            txtNamePlayer.Text = "";
            prcCoutDown.Value = 0;
            mnTab.Visible = false;
            tmStep.Stop();
            _ucMenu.Visible = true;
        }
    }

}

