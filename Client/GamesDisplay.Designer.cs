
namespace Client
{
    partial class GamesDisplay
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
            this.TblbindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.choose = new System.Windows.Forms.Button();
            this.goBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TblbindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(874, 417);
            this.dataGridView1.TabIndex = 0;
            // 
            // choose
            // 
            this.choose.Location = new System.Drawing.Point(23, 23);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(191, 88);
            this.choose.TabIndex = 1;
            this.choose.Text = "Choose game";
            this.choose.UseVisualStyleBackColor = true;
            this.choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // goBack
            // 
            this.goBack.Location = new System.Drawing.Point(250, 25);
            this.goBack.Name = "goBack";
            this.goBack.Size = new System.Drawing.Size(173, 85);
            this.goBack.TabIndex = 2;
            this.goBack.Text = "Return to menu";
            this.goBack.UseVisualStyleBackColor = true;
            this.goBack.Click += new System.EventHandler(this.goBack_Click);
            // 
            // GamesDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.goBack);
            this.Controls.Add(this.choose);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GamesDisplay";
            this.Text = "GamesDisplay";
            this.Load += new System.EventHandler(this.GamesDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TblbindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource TblbindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button choose;
        private System.Windows.Forms.Button goBack;
    }
}