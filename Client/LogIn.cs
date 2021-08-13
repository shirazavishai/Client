using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            UserNameNull.Visible = false;
            UserIdNotValid.Visible = false;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            UserNameNull.Visible = false;
            UserIdNotValid.Visible = false;

            if (UserNameInput.Text=="")
            {
                UserNameNull.Visible = true;
            }

            if (IdInput==null || !int.TryParse(IdInput.Text, out int n))
            {
                UserIdNotValid.Visible = true;
            }

            else
            {

            }
        }
    }
}
