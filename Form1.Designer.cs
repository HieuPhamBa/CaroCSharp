namespace CaroGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlTableGame = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNamePlayer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.picMark = new System.Windows.Forms.PictureBox();
            this.prcCoutDown = new System.Windows.Forms.ProgressBar();
            this.tmStep = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTableGame.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMark)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTableGame
            // 
            this.pnlTableGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTableGame.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTableGame.Controls.Add(this.flowLayoutPanel1);
            this.pnlTableGame.Location = new System.Drawing.Point(0, 30);
            this.pnlTableGame.Name = "pnlTableGame";
            this.pnlTableGame.Size = new System.Drawing.Size(580, 606);
            this.pnlTableGame.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(586, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(356, 210);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(586, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 238);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 235);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.txtNamePlayer);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnConnect);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.picMark);
            this.panel2.Controls.Add(this.prcCoutDown);
            this.panel2.Location = new System.Drawing.Point(588, 271);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 398);
            this.panel2.TabIndex = 3;
            // 
            // txtNamePlayer
            // 
            this.txtNamePlayer.Location = new System.Drawing.Point(9, 16);
            this.txtNamePlayer.Name = "txtNamePlayer";
            this.txtNamePlayer.ReadOnly = true;
            this.txtNamePlayer.Size = new System.Drawing.Size(141, 22);
            this.txtNamePlayer.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = "5 in a Line to win";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(9, 125);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(141, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(9, 86);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(141, 22);
            this.txtID.TabIndex = 3;
            // 
            // picMark
            // 
            this.picMark.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMark.Location = new System.Drawing.Point(169, 16);
            this.picMark.Name = "picMark";
            this.picMark.Size = new System.Drawing.Size(177, 159);
            this.picMark.TabIndex = 2;
            this.picMark.TabStop = false;
            // 
            // prcCoutDown
            // 
            this.prcCoutDown.Location = new System.Drawing.Point(9, 57);
            this.prcCoutDown.Name = "prcCoutDown";
            this.prcCoutDown.Size = new System.Drawing.Size(141, 23);
            this.prcCoutDown.TabIndex = 1;
            // 
            // tmStep
            // 
            this.tmStep.Tick += new System.EventHandler(this.tmStep_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(945, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replayToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.optionToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // replayToolStripMenuItem
            // 
            this.replayToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("replayToolStripMenuItem.Image")));
            this.replayToolStripMenuItem.Name = "replayToolStripMenuItem";
            this.replayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.replayToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.replayToolStripMenuItem.Text = "Replay";
            this.replayToolStripMenuItem.Click += new System.EventHandler(this.replayToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quitToolStripMenuItem.Image")));
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 634);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlTableGame);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My caro games!!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.pnlTableGame.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMark)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTableGame;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.PictureBox picMark;
        private System.Windows.Forms.ProgressBar prcCoutDown;
        private System.Windows.Forms.TextBox txtNamePlayer;
        private System.Windows.Forms.Timer tmStep;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replayToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
    }
}

