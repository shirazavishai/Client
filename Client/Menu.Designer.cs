﻿
namespace Client
{
    partial class Menu
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
            this.startGameBtn = new System.Windows.Forms.Button();
            this.WatchPrevGamesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startGameBtn
            // 
            this.startGameBtn.Location = new System.Drawing.Point(80, 93);
            this.startGameBtn.Name = "startGameBtn";
            this.startGameBtn.Size = new System.Drawing.Size(257, 78);
            this.startGameBtn.TabIndex = 0;
            this.startGameBtn.Text = "Start new game";
            this.startGameBtn.UseVisualStyleBackColor = true;
            this.startGameBtn.Click += new System.EventHandler(this.startGameBtn_Click);
            // 
            // WatchPrevGamesBtn
            // 
            this.WatchPrevGamesBtn.Location = new System.Drawing.Point(447, 93);
            this.WatchPrevGamesBtn.Name = "WatchPrevGamesBtn";
            this.WatchPrevGamesBtn.Size = new System.Drawing.Size(257, 78);
            this.WatchPrevGamesBtn.TabIndex = 2;
            this.WatchPrevGamesBtn.Text = "Watch previous games";
            this.WatchPrevGamesBtn.UseVisualStyleBackColor = true;
            this.WatchPrevGamesBtn.Click += new System.EventHandler(this.WatchPrevGamesBtn_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 285);
            this.Controls.Add(this.WatchPrevGamesBtn);
            this.Controls.Add(this.startGameBtn);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startGameBtn;
        private System.Windows.Forms.Button WatchPrevGamesBtn;
    }
}