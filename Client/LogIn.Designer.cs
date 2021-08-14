
namespace Client
{
    partial class LogIn
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
            this.UserNameInput = new System.Windows.Forms.TextBox();
            this.IdInput = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.UserNameNull = new System.Windows.Forms.Label();
            this.UserIdNotValid = new System.Windows.Forms.Label();
            this.UserNotFound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserNameInput
            // 
            this.UserNameInput.AcceptsTab = true;
            this.UserNameInput.Location = new System.Drawing.Point(71, 78);
            this.UserNameInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserNameInput.Name = "UserNameInput";
            this.UserNameInput.Size = new System.Drawing.Size(197, 20);
            this.UserNameInput.TabIndex = 0;
            // 
            // IdInput
            // 
            this.IdInput.Location = new System.Drawing.Point(71, 132);
            this.IdInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IdInput.Name = "IdInput";
            this.IdInput.Size = new System.Drawing.Size(197, 20);
            this.IdInput.TabIndex = 1;
            this.IdInput.UseSystemPasswordChar = true;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.title.Location = new System.Drawing.Point(130, 19);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(72, 26);
            this.title.TabIndex = 2;
            this.title.Text = "Log In";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Insert id as Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Insert name";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(135, 166);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(56, 19);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // UserNameNull
            // 
            this.UserNameNull.AutoSize = true;
            this.UserNameNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserNameNull.ForeColor = System.Drawing.Color.Red;
            this.UserNameNull.Location = new System.Drawing.Point(138, 59);
            this.UserNameNull.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserNameNull.Name = "UserNameNull";
            this.UserNameNull.Size = new System.Drawing.Size(87, 13);
            this.UserNameNull.TabIndex = 6;
            this.UserNameNull.Text = "Must insert name";
            this.UserNameNull.Visible = false;
            // 
            // UserIdNotValid
            // 
            this.UserIdNotValid.AutoSize = true;
            this.UserIdNotValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserIdNotValid.ForeColor = System.Drawing.Color.Red;
            this.UserIdNotValid.Location = new System.Drawing.Point(180, 113);
            this.UserIdNotValid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserIdNotValid.Name = "UserIdNotValid";
            this.UserIdNotValid.Size = new System.Drawing.Size(111, 13);
            this.UserIdNotValid.TabIndex = 7;
            this.UserIdNotValid.Text = "Must insert Validate Id";
            this.UserIdNotValid.Visible = false;
            // 
            // UserNotFound
            // 
            this.UserNotFound.AutoSize = true;
            this.UserNotFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserNotFound.ForeColor = System.Drawing.Color.Red;
            this.UserNotFound.Location = new System.Drawing.Point(120, 198);
            this.UserNotFound.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserNotFound.Name = "UserNotFound";
            this.UserNotFound.Size = new System.Drawing.Size(82, 13);
            this.UserNotFound.TabIndex = 8;
            this.UserNotFound.Text = "User Not Found";
            this.UserNotFound.Visible = false;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 230);
            this.Controls.Add(this.UserNotFound);
            this.Controls.Add(this.UserIdNotValid);
            this.Controls.Add(this.UserNameNull);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.IdInput);
            this.Controls.Add(this.UserNameInput);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserNameInput;
        private System.Windows.Forms.TextBox IdInput;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label UserNameNull;
        private System.Windows.Forms.Label UserIdNotValid;
        private System.Windows.Forms.Label UserNotFound;
    }
}