
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
            this.label1 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startGameBtn
            // 
            this.startGameBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.startGameBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F);
            this.startGameBtn.Location = new System.Drawing.Point(228, 128);
            this.startGameBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startGameBtn.Name = "startGameBtn";
            this.startGameBtn.Size = new System.Drawing.Size(289, 73);
            this.startGameBtn.TabIndex = 0;
            this.startGameBtn.Text = "Start new game";
            this.startGameBtn.UseVisualStyleBackColor = false;
            this.startGameBtn.Click += new System.EventHandler(this.startGameBtn_Click);
            // 
            // WatchPrevGamesBtn
            // 
            this.WatchPrevGamesBtn.BackColor = System.Drawing.Color.IndianRed;
            this.WatchPrevGamesBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WatchPrevGamesBtn.Location = new System.Drawing.Point(228, 241);
            this.WatchPrevGamesBtn.Margin = new System.Windows.Forms.Padding(4);
            this.WatchPrevGamesBtn.Name = "WatchPrevGamesBtn";
            this.WatchPrevGamesBtn.Size = new System.Drawing.Size(289, 80);
            this.WatchPrevGamesBtn.TabIndex = 2;
            this.WatchPrevGamesBtn.Text = "Watch previous games";
            this.WatchPrevGamesBtn.UseVisualStyleBackColor = false;
            this.WatchPrevGamesBtn.Click += new System.EventHandler(this.WatchPrevGamesBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 62);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tic Tac Toe";
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(315, 356);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(87, 34);
            this.exit.TabIndex = 4;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 452);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WatchPrevGamesBtn);
            this.Controls.Add(this.startGameBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startGameBtn;
        private System.Windows.Forms.Button WatchPrevGamesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exit;
    }
}