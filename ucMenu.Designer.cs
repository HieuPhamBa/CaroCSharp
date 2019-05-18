namespace CaroGame
{
    partial class ucMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMangLan = new System.Windows.Forms.Button();
            this.btn1May = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.playWithAi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMangLan
            // 
            this.btnMangLan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMangLan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMangLan.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMangLan.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnMangLan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMangLan.Location = new System.Drawing.Point(233, 214);
            this.btnMangLan.Name = "btnMangLan";
            this.btnMangLan.Size = new System.Drawing.Size(191, 45);
            this.btnMangLan.TabIndex = 0;
            this.btnMangLan.Text = "Dau mang lan";
            this.btnMangLan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMangLan.UseVisualStyleBackColor = false;
            this.btnMangLan.Click += new System.EventHandler(this.btnMangLan_Click);
            // 
            // btn1May
            // 
            this.btn1May.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn1May.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn1May.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1May.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn1May.Location = new System.Drawing.Point(236, 287);
            this.btn1May.Name = "btn1May";
            this.btn1May.Size = new System.Drawing.Size(188, 43);
            this.btn1May.TabIndex = 1;
            this.btn1May.Text = "Tren 1 may";
            this.btn1May.UseVisualStyleBackColor = false;
            this.btn1May.Click += new System.EventHandler(this.btn1May_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuit.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnQuit.Location = new System.Drawing.Point(236, 375);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(188, 43);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // playWithAi
            // 
            this.playWithAi.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playWithAi.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playWithAi.ForeColor = System.Drawing.SystemColors.Highlight;
            this.playWithAi.Location = new System.Drawing.Point(233, 136);
            this.playWithAi.Name = "playWithAi";
            this.playWithAi.Size = new System.Drawing.Size(191, 41);
            this.playWithAi.TabIndex = 3;
            this.playWithAi.Text = "Ai ";
            this.playWithAi.UseVisualStyleBackColor = false;
            this.playWithAi.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.playWithAi);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btn1May);
            this.Controls.Add(this.btnMangLan);
            this.Name = "ucMenu";
            this.Size = new System.Drawing.Size(731, 629);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMangLan;
        private System.Windows.Forms.Button btn1May;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button playWithAi;
    }
}
