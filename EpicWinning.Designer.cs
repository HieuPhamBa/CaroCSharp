namespace CaroGame
{
    partial class EpicWinning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EpicWinning));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnRelay = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnRelay);
            this.panel1.Location = new System.Drawing.Point(0, 214);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 67);
            this.panel1.TabIndex = 0;
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnQuit.Font = new System.Drawing.Font("Mistral", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(261, 5);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(144, 42);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnRelay
            // 
            this.btnRelay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRelay.Font = new System.Drawing.Font("Mistral", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelay.Location = new System.Drawing.Point(0, 6);
            this.btnRelay.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnRelay.Name = "btnRelay";
            this.btnRelay.Size = new System.Drawing.Size(139, 42);
            this.btnRelay.TabIndex = 0;
            this.btnRelay.Text = "Replay";
            this.btnRelay.UseVisualStyleBackColor = false;
            this.btnRelay.Click += new System.EventHandler(this.btnRelay_Click);
            // 
            // EpicWinning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(402, 271);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "EpicWinning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRelay;
        private System.Windows.Forms.Button btnQuit;
    }
}