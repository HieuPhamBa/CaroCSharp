using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame
{
    public partial class frmLogin : Form
    {

        private static string name = null;
        public frmLogin()
        {
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            InitializeComponent();
        }

        public string NameGet
        {
            get{ return name;}
            set{ name = value;}
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show( "TEN KHONG DUOC BO TRONG", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
            else
            {
                this.NameGet = txtName.Text;
                this.Close();
            }
          
        }

    }
}
