using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CaroGame
{
    [Serializable]
    public class SocketData
    {
        private int cmd;
        private string  message;
        private Point pointData;
        public int Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }

        public Point PointData
        {
            get { return pointData; }
            set { pointData = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public SocketData(int cmd, string message, Point point)
        {
            this.Cmd = cmd;
            this.Message = message;
            this.pointData = point;
        }

        public static explicit operator string(SocketData v)
        {
            throw new NotImplementedException();
        }
    }
    public enum SocketComand
    {
        SendPoint,
        Notify,
        Message,
        EndGame,
        QuitGame,
        Replay,
        Undo
    }

}
