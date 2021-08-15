using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client
{

    public partial class Board : Form
    {

        private static HttpClient client = new HttpClient();
        private string PlayerId;
        private int GameId;

        public Board(string playerId)
        {
            InitializeComponent();
            PlayerId = playerId;

        }

        private async void Board_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            client.BaseAddress = new Uri("https://localhost:44317/");
            await createGame();
            
        }

        private async Task createGame()
        {
            string url = "api/TblGames";
            Game game = new Game {PlayerId = PlayerId,Moves = "" };
            
            HttpResponseMessage response = await client.PostAsJsonAsync(url, game);

            if (!response.IsSuccessStatusCode)
            {
                this.Hide();
            }

            var gameResultAsString = await response.Content.ReadAsStringAsync();

            var gameObject = JsonConvert.DeserializeObject<Game>(gameResultAsString);

            GameId = gameObject.Id;

        }


        private async void pictureBox_Click(object sender, EventArgs e)
        {
            String cellLabel = ((PictureBox)sender).Name;

            PictureBox pb = (PictureBox)sender;
            pb.Enabled = false;
            
            await Play(cellLabel);

            //if (Game.Moves.Count % 2 == 1)
            //{
            //    pb.BackColor = Color.Red;
            //}
            //else
            //{
            //    pb.BackColor = Color.Blue;
            //}

            setNextTurn();


        }

        private async Task Play(string cellLabel)
        {
            string url = "api/TblGames/" + GameId + "/" + cellLabel;

            var values = new Dictionary<string, string>()
            {
                {"id" , Convert.ToString(GameId)},
                {"cellLabel", cellLabel}
            };
            HttpResponseMessage response = await client.PutAsJsonAsync(url, values);

            if (!response.IsSuccessStatusCode)
            {
                this.Hide();
            }

            var playResult = await response.Content.ReadAsStringAsync();

            Console.WriteLine(playResult);

        }


        void setNextTurn()
        {
            //int movesDone = Game.Moves.Count;
            //if(movesDone % 2 == 0)
            //{
            //    label2.Visible = false;
            //    label1.Visible = true;
            //}
            //else
            //{
            //    label1.Visible = false;
            //    label2.Visible = true;
            //}
        }
    }
}
