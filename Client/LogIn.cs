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


namespace Client
{
    public partial class LogIn : Form
    {
        private Board gameBoard;
        private static HttpClient client = new HttpClient();

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
                await getPlayer();

            }
            Board board = new Board(IdInput.Text);
            board.Activate();

        }

        private async Task getPlayer()
        {
            HttpResponseMessage response = await client.GetAsync("api/TblPlayers/" + IdInput.Text);

            if (!response.IsSuccessStatusCode)
            {
                UserNotFound.Visible = true;
            }
            else
            {
                gameBoard = new Board(IdInput.Text);
                gameBoard.ShowDialog();
                this.Hide();
            }
        }

        static async Task<object> CreateProductAsync(Player p)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/TblPlayers", p);
            response.EnsureSuccessStatusCode();
            
            // return URI of the created resource.
            return response.StatusCode;
        }

    }
}
