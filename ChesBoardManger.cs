using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
namespace CaroGame
{
    public class ChesBoardManger
    {
        #region properties
        private SoundGame sound = new SoundGame();
        ConsRegion cons = new ConsRegion();
        private string namePlayer = "";
        public string NamePlayer
        {
            set { namePlayer = value; }
            get { return namePlayer; }
        }
        private Point[] winMark;
        private event EventHandler<ButtonClickedEvent> playerMarked;
        private event EventHandler endGameEvent;
        public event EventHandler<ButtonClickedEvent> PlayerMarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }
        public event EventHandler EndGameEvent
        {
            add
            {
                endGameEvent += value;
            }
            remove
            {
                endGameEvent -= value;
            }
        }
        private bool[,] flagPos = new bool[ConsRegion.BOARD_HEIGHT, ConsRegion.BOARD_WITDH];
        private Panel chessBoard;
        private Player[] arrPlayer = new Player[2];
        private Image[] iconImage = { Image.FromFile(Application.StartupPath + "\\images.png"),
                                Image.FromFile(Application.StartupPath + "\\imageO.png")};
        private Bitmap[] avatarImage = {new Bitmap(Application.StartupPath+"\\player1.png"),
                                new Bitmap(Application.StartupPath + "\\player2.png")};

        private int postion = 0;
        private TextBox txtNamePlayer = new TextBox();
        private List<List<Button>> matrixButton = new List<List<Button>>();
        private ProgressBar prcCountDown = new ProgressBar();
        private Timer tmCoutDown = new Timer();
        private PictureBox pcIcon;
        public PictureBox PcIcon
        {
            set { pcIcon = value; }
            get { return pcIcon;   }
        }
        
        private Stack<PlayerInfo> playTimeLine;
        private int[] attackCore = { 0, 4, 25, 246, 7300, 6561, 59049 };
        private int[] defendCore = { 0, 4, 25, 246, 7300, 6561, 59049 };

        #endregion

        #region initalize
        public ChesBoardManger() { }
        public ChesBoardManger(Panel chessBoard, TextBox txtNamePlayer, PictureBox pcIcon)
        {
          
            this.chessBoard = chessBoard;
            arrPlayer[0] = new Player(txtNamePlayer.Text+"1",iconImage[0],avatarImage[0]);
            arrPlayer[1] = new Player(txtNamePlayer.Text+"2",iconImage[1],avatarImage[1]);
            this.txtNamePlayer = txtNamePlayer;

            this.pcIcon = pcIcon;
            pcIcon.Image = arrPlayer[0].AvatarPlayer;
            pcIcon.SizeMode = PictureBoxSizeMode.StretchImage;

            this.playTimeLine = new Stack<PlayerInfo>();
            this.winMark = new Point[100];
        }
        #endregion

        #region Method
        public Panel drawChesBoard()
        {
            matrixButton.Clear();
            txtNamePlayer.Text = arrPlayer[postion].Name;
            Button oldBtn = new Button() {
                Width = 0,
                Location = new Point(0, 0)
            };
            matrixButton = new List<List<Button>>();

            for (int i = 0; i < ConsRegion.BOARD_HEIGHT; i++)
            {
                matrixButton.Add(new List<Button>());
                for (int j = 0; j < ConsRegion.BOARD_WITDH; j++)
                {

                    Button btn = new Button()
                    {
                        Width = ConsRegion.BTN_WITDH,
                        Height = ConsRegion.BTN_HEIGHT,
                        Location = new Point(oldBtn.Location.X + j * ConsRegion.BTN_WITDH, oldBtn.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                    };
                    btn.Click += button_Click;
                    chessBoard.Controls.Add(btn);
                    matrixButton[i].Add(btn);
                }
                oldBtn.Location = new Point(oldBtn.Location.X, oldBtn.Location.Y + ConsRegion.BTN_HEIGHT);
            }
            return chessBoard;

        }

        void button_Click(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
            {
                sound.GoWrong.Play();
                return;
            }
            sound.ClickSound.Play();
            NamePlayer = this.txtNamePlayer.Text;
            changeIcon(btn);
            playTimeLine.Push(new PlayerInfo(this.postion, getPoint(btn)));
            changePlayer();
            
            if (isEndGame(btn))
            {
                endGame();
            }
            if (playerMarked != null)
                playerMarked(this, new ButtonClickedEvent(getPoint(btn)));

        }

        public void otherPlayClicked(Point point)
        {
            Button btn = matrixButton[point.Y][point.X];
            if (btn.BackgroundImage != null)
            {
                sound.GoWrong.Play();
                return;
            }
            sound.ClickSound.Play();
            NamePlayer = this.txtNamePlayer.Text;
            changeIcon(btn);
            playTimeLine.Push(new PlayerInfo(this.postion, getPoint(btn)));
            changePlayer();
            if (isEndGame(btn))
            {
                endGame();
            }
        
        }

        private void changeIcon(Button btn)
        {
            
            btn.BackgroundImage = arrPlayer[postion].IconMark;
        }

        public void changePlayer()
        {
            this.postion = (this.postion + 1) % 2;
            txtNamePlayer.Text = arrPlayer[postion].Name;
            pcIcon.Image = arrPlayer[postion].AvatarPlayer;
        }
        private void endGame()
        {
            if (endGameEvent != null)
                endGameEvent(this, new EventArgs());
        }
        private Point getPoint(Button btn)
        {
            int pointY = Convert.ToInt32(btn.Tag);
            int pointX = matrixButton[pointY].IndexOf(btn);
            Point point = new Point(pointX, pointY);
            return point;
        }
        private bool isEndGame(Button btn)
        {
            return isEndHorizon(btn) || isEndVatical(btn)|| isEndSubDiagonal(btn)||isEndPrimeDiagonal(btn);
        }
        public void changeColorBtnMarked()
        {
            //Button btn = new Button();
            for (int i = 0; i<10; i++)
            {
                if (winMark[i] == null )
                    break;
                Button btn = matrixButton[winMark[i].Y][winMark[i].X];
                if(btn.BackgroundImage!=null)
                    btn.BackColor = Color.Red;
            }
        }
        private bool isEndVatical(Button btn)
        {
            Point point = getPoint(btn);
            int i, countRight, countLeft;
            countLeft = countRight = 0;

            for( i = point.X; i > 0; i--)
            {
                if (matrixButton[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    winMark[countLeft] = getPoint(matrixButton[point.Y][i]);
                   countLeft++;
                   
                }
                else
                    break;
            }

            for (i = point.X+1; i < ConsRegion.BOARD_WITDH; i++)
            {
                if (matrixButton[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    winMark[countRight+countLeft] = getPoint(matrixButton[point.Y][i]);
                    countRight++;
                }

                else
                    break;
            }

            return countRight + countLeft >= 5;

        }
        private bool isEndHorizon(Button btn)
        {
            Point point = getPoint(btn);
            int i, countBottom, countTop;
            countBottom = countTop = 0;

            for (i = point.Y; i > 0; i--)
            {
                if (matrixButton[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    winMark[countBottom] = getPoint(matrixButton[i][point.X]);
                    countBottom++;
                }
                   
                else
                    break;
            }

            for (i = point.Y + 1; i < ConsRegion.BOARD_HEIGHT; i++)
            {
                if (matrixButton[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    winMark[countBottom + countTop] = getPoint(matrixButton[i][point.X]);
                    countTop++;
                }                
                else
                    break;
            }

            return countBottom + countTop >= 5;

        }       
        private bool isEndSubDiagonal(Button btn)
        {
            Point point = getPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i >=  ConsRegion.BOARD_WITDH || point.Y + i >= ConsRegion.BOARD_HEIGHT)
                    break;

                if (matrixButton[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    winMark[countTop] = getPoint(matrixButton[point.Y + i][point.X + i]);
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <= ConsRegion.BOARD_WITDH - point.X; i++)
            {
                if (point.Y - i < 0 || point.X - i < 0)
                    break;

                if (matrixButton[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    winMark[countTop + countBottom] = getPoint(matrixButton[point.Y - i][point.X - i]);
                    countBottom++;
                }
                else
                    break;
            }
            //MessageBox.Show(countBottom + "v" + countTop);

            return countTop + countBottom >= 5;

        }
        private bool isEndPrimeDiagonal(Button btn)
        {
            Point point = getPoint(btn);
            int i, countBottom, countTop;
            countBottom = countTop = 0;

            for (i = 0; i <= point.X; i++)
            {
                if (point.X + i >= ConsRegion.BOARD_WITDH || point.Y - i < 0)
                    break;
                if (matrixButton[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    winMark[countBottom] = getPoint(matrixButton[point.Y - i][point.X + i]);
                    countBottom++;
                }
                else
                    break;
            }
           
            for (i = 1; i <= ConsRegion.BOARD_WITDH - point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= ConsRegion.BOARD_HEIGHT)
                    break;
                if (matrixButton[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    winMark[countBottom + countTop] = getPoint(matrixButton[point.Y + i][point.X - i]);
                    countTop++;
                }
                else
                    break;
            }

            return countBottom + countTop >= 5;
        }
        public bool undo()
        {          
            if (playTimeLine.Count <= 0)
                return false;
            PlayerInfo currPlay = playTimeLine.Pop();
            Button btn = matrixButton[currPlay.CurrPoint.Y][currPlay.CurrPoint.X];
            this.postion = currPlay.Pos+1;
            btn.BackgroundImage = null;
            //.btn.Bo = Color.Red;
            changePlayer();
            return true;
        }

        #endregion
        #region AI
        private int coutMarkedAi = 0;
        private Button oldBtn = new Button();
        public Point getAiPoint()
        {
            //Point pointAi = new Point();
            Button btn = new Button();
            btn = findPoint();
            return getPoint(btn);
           
        }
        private int getCore(Button btn)
        {
            int sum, attackCore1, defendCore1;
            attackCore1 = attackHorizon(btn) + attackPrimeDiagonal(btn) + attackSubDiagonal(btn) + attackVatical(btn);
            defendCore1 = defendHorizon(btn) + defendPrimeDiagonal(btn) + defendSubDiagonal(btn) + defendVatical(btn);
            
            sum = defendCore1 > attackCore1?defendCore1:attackCore1;
            //MessageBox.Show(sum + "");
            return sum;
        }
       
        private Button findPoint()
        {
            Button maxbtn = new Button();
            int coreBtn;
            Button btn;
            Point point = getPoint(oldBtn);
            int maxCore = 0;
            for (int i = 0; i < ConsRegion.BOARD_HEIGHT; i++)
            {

                for (int j = 0; j <  ConsRegion.BOARD_WITDH ; j++)
                {
                    btn = matrixButton[i][j];
                    if (btn.BackgroundImage == null)
                    {
                        coreBtn = getCore(matrixButton[i][j]);
                      //  MessageBox.Show(maxCore + "");
                        if (coreBtn >= maxCore)
                        {
                           
                            maxCore = coreBtn;
                            maxbtn = matrixButton[i][j];
                        }
                    } 
                }
            }
            return maxbtn;
        }

        private int attackHorizon(Button btn)
        {
            int sum;
            sum = 0;
            Point point = getPoint(btn);
            int  enemyUnit, aiUnit;
            enemyUnit = aiUnit = 0;

            for (int i = point.Y; i >= 0; i--)
            {
                if (matrixButton[i][point.X].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                    break;
                }
                else if(matrixButton[i][point.X].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                    break;
                }
                else
                    break;
            }

            for (int i = point.Y + 1; i < ConsRegion.BOARD_HEIGHT; i++)
            {
                if (matrixButton[i][point.X].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                    break;
                }
                else if (matrixButton[i][point.X].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                   
                }
                else
                    break;
            }

            if (enemyUnit == 2)
                return 0;
            sum -= defendCore[enemyUnit+1];
            sum += attackCore[aiUnit];
            return sum;
        }
        private int attackVatical(Button btn)
        {
            int sum;
            Point point = getPoint(btn);
            int i, enemyUnit, aiUnit;
            enemyUnit = aiUnit = sum = 0;

            for (i = point.X; i >= 0; i--)
            {
                if (matrixButton[point.Y][i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                    break;
                }
                else if (matrixButton[point.Y][i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                    
                }
                else
                    break;
            }

            for (i = point.X + 1; i < ConsRegion.BOARD_WITDH; i++)
            {
                if (matrixButton[point.Y][i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                    break;
                }
                else if (matrixButton[point.Y][i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                   
                }
                else
                    break;
            }

            if (enemyUnit == 2)
                return 0;
            if (enemyUnit == 2)
                return 0;
            sum -= defendCore[enemyUnit+1];
            sum += attackCore[aiUnit];
            return sum;

        }
        private int attackSubDiagonal(Button btn)
        {
            int sum;
            Point point = getPoint(btn);
            int  enemyUnit, aiUnit;
            enemyUnit = aiUnit = sum = 0;

            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i >= ConsRegion.BOARD_WITDH || point.Y + i >= ConsRegion.BOARD_HEIGHT)
                    break;

                if (matrixButton[point.Y + i][point.X + i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                    break;
                }
                else if (matrixButton[point.Y + i][point.X + i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                   
                }
                else
                    break;
            }
            for (int i = 1; i <= ConsRegion.BOARD_WITDH - point.X; i++)
            {
                if (point.Y - i < 0 || point.X - i < 0)
                    break;

                if (point.X + i >= ConsRegion.BOARD_WITDH || point.Y + i >= ConsRegion.BOARD_HEIGHT)
                    break;

                if (matrixButton[point.Y - i][point.X - i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                    break;
                }
                else if (matrixButton[point.Y - i][point.X - i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                    
                }
                else
                    break;
            }
            //MessageBox.Show(countBottom + "v" + countTop);

            if (enemyUnit == 2)
                return 0;
           
            sum -= defendCore[enemyUnit+1];
            sum += attackCore[aiUnit];
            return sum;

        }
        private int attackPrimeDiagonal(Button btn)
        {
            int sum;
            Point point = getPoint(btn);
            int enemyUnit, aiUnit, i;
            enemyUnit = aiUnit = sum = 0;

            for (i = 0; i <= point.X; i++)
            {
                if (point.X + i >= ConsRegion.BOARD_WITDH || point.Y - i < 0)
                    break;

                if (matrixButton[point.Y - i][point.X + i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                    break;
                }
                else if (matrixButton[point.Y - i][point.X + i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                   
                }
                else
                    break;
            }

            for (i = 1; i <= ConsRegion.BOARD_WITDH - point.X; i++)
            {
                if (point.X - i <= 0 || point.Y + i >=ConsRegion.BOARD_HEIGHT)
                    break;

                if (matrixButton[point.Y + i][point.X - i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                    break;
                }
                else if (matrixButton[point.Y + i][point.X - i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                   
                }
                else
                    break;
            }

            if (enemyUnit == 2)
                return 0;
            sum -= defendCore[enemyUnit+1];
            sum += attackCore[aiUnit];
            return sum;
        }

        private int defendHorizon(Button btn)
        {
            int sum;
            sum = 0;
            Point point = getPoint(btn);
            int i, enemyUnit, aiUnit;
            enemyUnit = aiUnit = 0;

            for (i = point.Y; i >= 0; i--)
            {
                if (matrixButton[i][point.X].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                   
                }
                else if (matrixButton[i][point.X].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                    break;
                }
                else
                    break;
            }

            for (i = point.Y + 1; i < ConsRegion.BOARD_HEIGHT; i++)
            {
                if (matrixButton[i][point.X].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                   
                }
                else if (matrixButton[i][point.X].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                    break;
                }
                else
                    break;
            }

            if (aiUnit == 2)
                return 0;
            //sum -= attackCore[aiUnit];
            sum += defendCore[enemyUnit];
            return sum;

        }
        private int defendVatical(Button btn)
        {
            int sum;
            Point point = getPoint(btn);
            int i, enemyUnit, aiUnit;
            enemyUnit = aiUnit = sum = 0;

            for (i = point.X; i >= 0; i--)
            {
                if (matrixButton[point.Y][i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                   
                }
                else if (matrixButton[point.Y][i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                    break;
                }
                else
                    break;
            }

            for (i = point.X + 1; i < ConsRegion.BOARD_HEIGHT; i++)
            {
                if (matrixButton[point.Y][i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                   
                }
                else if (matrixButton[point.Y][i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                    break;
                }
                else
                    break;
            }
            if (aiUnit == 2)
                return 0;
            //sum -= attackCore[aiUnit];
            sum += defendCore[enemyUnit];
            return sum;


        }
        private int defendSubDiagonal(Button btn)
        {
            int sum;
            Point point = getPoint(btn);
            int enemyUnit, aiUnit;
            enemyUnit = aiUnit = sum = 0;

            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i >= ConsRegion.BOARD_WITDH || point.Y + i >= ConsRegion.BOARD_HEIGHT)
                    break;

                if (matrixButton[point.Y + i][point.X + i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                    
                }
                else if (matrixButton[point.Y + i][point.X + i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                    break;
                }
                else
                    break;
            }
            for (int i = 1; i <= ConsRegion.BOARD_WITDH - point.X; i++)
            {
                if (point.Y - i < 0 || point.X - i < 0)
                    break;

                if (point.X + i >= ConsRegion.BOARD_WITDH || point.Y + i >= ConsRegion.BOARD_HEIGHT)
                    break;

                if (matrixButton[point.Y - i][point.X - i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                    
                }
                else if (matrixButton[point.Y - i][point.X - i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                    break;
                }
                else
                    break;
            }
            //MessageBox.Show(countBottom + "v" + countTop);

            if (aiUnit == 2)
                return 0;
            //sum -= attackCore[aiUnit];
            sum += defendCore[enemyUnit];
            return sum;

        }
        private int defendPrimeDiagonal(Button btn)
        {
            int sum;
            Point point = getPoint(btn);
            int enemyUnit, aiUnit, i;
            enemyUnit = aiUnit = sum = 0;

            for (i = 0; i <= point.X; i++)
            {
                if (point.X + i >= ConsRegion.BOARD_WITDH || point.Y - i < 0)
                    break;

                if (matrixButton[point.Y - i][point.X + i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                   
                }
                else if (matrixButton[point.Y - i][point.X + i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                    break;
                }
                else
                    break;
            }

            for (i = 1; i <= ConsRegion.BOARD_WITDH - point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= ConsRegion.BOARD_HEIGHT)
                    break;

                if (matrixButton[point.Y + i][point.X - i].BackgroundImage == arrPlayer[0].IconMark)
                {
                    enemyUnit++;
                   
                }
                else if (matrixButton[point.Y + i][point.X - i].BackgroundImage == arrPlayer[1].IconMark)
                {
                    aiUnit++;
                    break;
                }
                else
                    break;
            }
            
            if (aiUnit == 2)
                return 0;
           // sum -= attackCore[aiUnit];
            sum += defendCore[enemyUnit];
            return sum;
        }
        #endregion
    }

    public class ButtonClickedEvent : EventArgs
    {
        private Point point;
        public Point clickedPoint
        {
            set { point = value; }
            get { return point; }
        }

        public ButtonClickedEvent(Point point)
        {
            this.clickedPoint = point;
        }
       
    }
}
