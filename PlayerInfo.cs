using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CaroGame
{
    class PlayerInfo
    {
        private int pos;
        public int Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        private Point point = new Point();
        public Point CurrPoint
        {
            get { return point; }
            set { point = value; }
        }
       
        public PlayerInfo(){
        }

        public PlayerInfo(int pos, Point CurrPoint)
        {
            this.pos = pos;
            this.CurrPoint = CurrPoint;
        }
    }
}
