
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
            this.mustSelect = new System.Windows.Forms.Label();
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
            this.choose.BackColor = System.Drawing.Color.White;
            this.choose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choose.Location = new System.Drawing.Point(227, 25);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(159, 63);
            this.choose.TabIndex = 1;
            this.choose.Text = "Choose game";
            this.choose.UseVisualStyleBackColor = false;
            this.choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // goBack
            // 
            this.goBack.BackColor = System.Drawing.Color.White;
            this.goBack.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBack.Location = new System.Drawing.Point(421, 27);
            this.goBack.Name = "goBack";
            this.goBack.Size = new System.Drawing.Size(216, 61);
            this.goBack.TabIndex = 2;
            this.goBack.Text = "Return to menu";
            this.goBack.UseVisualStyleBackColor = false;
            this.goBack.Click += new System.EventHandler(this.goBack_Click);
            // 
            // mustSelect
            // 
            this.mustSelect.AutoSize = true;
            this.mustSelect.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mustSelect.ForeColor = System.Drawing.Color.Red;
            this.mustSelect.Location = new System.Drawing.Point(187, 91);
            this.mustSelect.Name = "mustSelect";
            this.mustSelect.Size = new System.Drawing.Size(255, 22);
            this.mustSelect.TabIndex = 3;
            this.mustSelect.Text = "You must to select a game!";
            // 
            // GamesDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 554);
            this.Controls.Add(this.mustSelect);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource TblbindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button choose;
        private System.Windows.Forms.Button goBack;
        private System.Windows.Forms.Label mustSelect;
    }
}