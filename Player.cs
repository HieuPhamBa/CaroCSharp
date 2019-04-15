using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame
{
    public class Player
    {
        private string name;
        private Image iconMark;
        private Bitmap avatarPlayer;

        public Player() { }

        public Player(string name, Image iconMark)
        {
            this.iconMark = iconMark;
            this.name = name;
        }

        public Player(string name, Image iconMark, Bitmap avatarPlayer)
        {
            this.name = name;
            this.iconMark = iconMark;
            this.avatarPlayer = avatarPlayer;
        }

        public Bitmap AvatarPlayer
        {
            get { return avatarPlayer; }
            set { avatarPlayer = value; }
        }

        public string Name
        {
            get{ return name; }
            set{ name = value; }
        }
       public Image IconMark
        {
            get { return iconMark; }
            set { iconMark = value; }
        }
    }
}
