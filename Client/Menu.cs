using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Menu : Form
    {
        private Player player;
        private static HttpClient client;
        private Board gameBoard;
        private GamesDisplay gamesDisplay;
        private const int NEW_GAME = 1;
        public Menu(Player gamePlayer, HttpClient httpClient)
        {
            InitializeComponent();
            client = httpClient;
            player = gamePlayer;
        }

        private async void startGameBtn_Click(object sender, EventArgs e)
        {
            int gameId = await createGame();

            if (gameId != -1)
            {
                gameBoard = new Board(player, gameId, NEW_GAME,client);
                gameBoard.Activate();
                this.Hide();
                gameBoard.ShowDialog();
                this.Show();
            }
        }

        private async Task<int> createGame()
        {
            string url = "api/TblGames";
            var game = new Game { PlayerId = player.Id.ToString(), Moves = "", Winner = "None" };
            HttpResponseMessage response = await client.PostAsJsonAsync(url, game);
       
            if (response.IsSuccessStatusCode)
            {
                var gameAsString = await response.Content.ReadAsStringAsync();
                var gameObject = JsonConvert.DeserializeObject<Game>(gameAsString);
                return gameObject.Id;
            }
            return -1;
        }

        private void WatchPrevGamesBtn_Click(object sender, EventArgs e)
        {
            gamesDisplay = new GamesDisplay(player);
            gamesDisplay.Activate();
            this.Hide();
            gamesDisplay.ShowDialog();
            this.Show();
        }

    }
}
