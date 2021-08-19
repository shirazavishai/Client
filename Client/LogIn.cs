using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Client
{
    public partial class LogIn : Form
    {
        private static HttpClient client = new HttpClient();
        private Menu menu;
        public LogIn()
        {

            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri("https://localhost:44317/");
        }

        private async void ButtonOK_Click(object sender, EventArgs e)
        {
            UserNameNull.Visible = false;
            UserIdNotValid.Visible = false;

            if (UserNameInput.Text == "")
            {
                UserNameNull.Visible = true;
            }

            else if (IdInput == null || !int.TryParse(IdInput.Text, out int n))
            {
                UserIdNotValid.Visible = true;
            }

            else
            {
                Player player = await getPlayer();

                if(player != null)
                {
                    menu = new Menu(player,client);
                    menu.Activate();
                    this.Hide();
                    menu.ShowDialog();
                    this.Close();
                    
                }
            }
        }

        private async Task<Player> getPlayer()
        {
            string url = "api/TblPlayers/" + IdInput.Text + "/" + UserNameInput.Text;
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var playerAsString = await response.Content.ReadAsStringAsync();
                var playerObject = JsonConvert.DeserializeObject<Player>(playerAsString);
                return playerObject;
            }
            else
            {
                UserNotFound.Visible = true;
                return null;
            }
        }
    }
}
