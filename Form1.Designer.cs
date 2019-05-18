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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.pnlLanInfo = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNamePlayer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picMark = new System.Windows.Forms.PictureBox();
            this.prcCoutDown = new System.Windows.Forms.ProgressBar();
            this.tmStep = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnTab = new System.Windows.Forms.ToolStripMenuItem();
            this.replayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._ucMenu = new CaroGame.ucMenu();
            this.pnlInfo.SuspendLayout();
            this.pnlLanInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMark)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTableGame
            // 
            this.pnlTableGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTableGame.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pnlTableGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTableGame.Location = new System.Drawing.Point(0, 31);
            this.pnlTableGame.Name = "pnlTableGame";
            this.pnlTableGame.Size = new System.Drawing.Size(973, 734);
            this.pnlTableGame.TabIndex = 0;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlInfo.Controls.Add(this.pnlLanInfo);
            this.pnlInfo.Controls.Add(this.txtNamePlayer);
            this.pnlInfo.Controls.Add(this.label1);
            this.pnlInfo.Controls.Add(this.picMark);
            this.pnlInfo.Controls.Add(this.prcCoutDown);
            this.pnlInfo.Location = new System.Drawing.Point(969, 290);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(341, 591);
            this.pnlInfo.TabIndex = 3;
            // 
            // pnlLanInfo
            // 
            this.pnlLanInfo.Controls.Add(this.btnConnect);
            this.pnlLanInfo.Controls.Add(this.txtID);
            this.pnlLanInfo.Location = new System.Drawing.Point(6, 100);
            this.pnlLanInfo.Name = "pnlLanInfo";
            this.pnlLanInfo.Size = new System.Drawing.Size(150, 71);
            this.pnlLanInfo.TabIndex = 7;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(2, 41);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(141, 30);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(4, 3);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(141, 22);
            this.txtID.TabIndex = 3;
            // 
            // txtNamePlayer
            // 
            this.txtNamePlayer.Location = new System.Drawing.Point(9, 33);
            this.txtNamePlayer.Name = "txtNamePlayer";
            this.txtNamePlayer.ReadOnly = true;
            this.txtNamePlayer.Size = new System.Drawing.Size(141, 22);
            this.txtNamePlayer.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = "5 in a Line to win";
            // 
            // picMark
            // 
            this.picMark.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.picMark.Location = new System.Drawing.Point(168, 33);
            this.picMark.Name = "picMark";
            this.picMark.Size = new System.Drawing.Size(168, 138);
            this.picMark.TabIndex = 2;
            this.picMark.TabStop = false;
            // 
            // prcCoutDown
            // 
            this.prcCoutDown.Location = new System.Drawing.Point(9, 69);
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
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1310, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnTab
            // 
            this.mnTab.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mnTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replayToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.menuToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.mnTab.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mnTab.Image = ((System.Drawing.Image)(resources.GetObject("mnTab.Image")));
            this.mnTab.Name = "mnTab";
            this.mnTab.Size = new System.Drawing.Size(87, 24);
            this.mnTab.Text = "Option";
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
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("menuToolStripMenuItem.Image")));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
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
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(969, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 262);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // _ucMenu
            // 
            this._ucMenu.BackColor = System.Drawing.SystemColors.HighlightText;
            this._ucMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._ucMenu.Location = new System.Drawing.Point(116, 69);
            this._ucMenu.Name = "_ucMenu";
            this._ucMenu.Size = new System.Drawing.Size(729, 627);
            this._ucMenu.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1310, 765);
            this.Controls.Add(this._ucMenu);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlTableGame);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My caro games!!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlLanInfo.ResumeLayout(false);
            this.pnlLanInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMark)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTableGame;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.PictureBox picMark;
        private System.Windows.Forms.ProgressBar prcCoutDown;
        private System.Windows.Forms.TextBox txtNamePlayer;
        private System.Windows.Forms.Timer tmStep;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnTab;
        private System.Windows.Forms.ToolStripMenuItem replayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlLanInfo;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private ucMenu _ucMenu;
    }
}

