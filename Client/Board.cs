using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Client
{

    public partial class Board : Form
    {

        private static HttpClient client = new HttpClient();
        private string PlayerId;
        private int GameId;
        private PictureBox[] cells;

        public Board(string playerId)
        {
            InitializeComponent();
            PlayerId = playerId;
            cells = new PictureBox []{ pictureBox0, pictureBox1, pictureBox2, pictureBox3, pictureBox4, 
                                     pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, 
                                     pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, 
                                     pictureBox15, pictureBox16,pictureBox17, pictureBox18, pictureBox19, 
                                     pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24};
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
            var game = new Game {PlayerId = PlayerId,Moves = "" ,Winner = "None"};
            
            HttpResponseMessage response = await client.PostAsJsonAsync(url, game);
            
            if (!response.IsSuccessStatusCode)
            {
                this.Hide();
            }

            var gameAsString = await response.Content.ReadAsStringAsync();

            var gameObject = JsonConvert.DeserializeObject<Game>(gameAsString);

            GameId = gameObject.Id;

        }


        private async void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            String cellLabel = pb.Name;
            pb.BackColor = Color.Red;
            pb.Enabled = false;

            await Play(cellLabel);
            fillCell(sender,0);
        }

        private void fillCell(object sender, int sign)
        {
            PictureBox pb = (PictureBox)sender;
        
        }

        private async Task<Game> Play(string cellLabel)
        {

            string url = "api/TblGames/" + GameId + "/" + cellLabel;

            var values = new Dictionary<string, string>() {};

            var httpResponse = await client.PutAsJsonAsync(url, values);

            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

            if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                var contentStream = await httpResponse.Content.ReadAsStreamAsync();
                
                var streamReader = new StreamReader(contentStream);

                var jsonReader = new JsonTextReader(streamReader);

                string output = JsonConvert.SerializeObject(jsonReader);
                //JsonSerializer serializer = new JsonSerializer();

                try
                {
                    Game game = JsonConvert.DeserializeObject<Game>(output);
                    //Game game = serializer.Deserialize<Game>(jsonReader);

                    string[] split = game.Moves.Split(new Char[] { ',', '\"', '\\' });

                    List<int> shittyList = new List<int>();

                    for (int i = 0; i < split.Length; i++)
                    {
                        int numericValue = 0;
                        bool isNumber = int.TryParse(split[i], out numericValue);
                        if (isNumber == true)
                        {
                            shittyList.Add(numericValue);
                        }
                    }

                    if (game.Winner != "None")
                    {
                        winnerTitle.Text = winnerTitle.Text + " " + game.Winner;
                    }

                    int x = shittyList.Last();
                    cells[x].BackColor = Color.Blue;
                    cells[x].Enabled = false;
                    return game;
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else
            {
                Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            }
            return null;
        }
    }

    //    private async Task Play(string cellLabel)
    //    {
    //        string url = "api/TblGames/" + GameId + "/" + cellLabel;

    //        var values = new Dictionary<string, string>()
    //        {
    //            {"id" , Convert.ToString(GameId)},
    //            {"cellLabel", cellLabel}
    //        };
    //        HttpResponseMessage response = await client.PutAsJsonAsync(url, values);

    //        if (!response.IsSuccessStatusCode)
    //        {
    //            this.Hide();
    //        }

    //        var turnResultAsString = await response.Content.ReadAsStringAsync();

    //        var gameObject = JsonSerializer.Deserialize(turnResultAsString);

    //        //var gameObject = JsonConvert.DeserializeObject<Game>(turnResultAsString);

    //        string[] split = gameObject.Moves.Split(new Char[] { ',', '\"' ,'\\'});

    //        List<int> shittyList = new List<int>();

    //        for(int i = 0; i < split.Length; i ++)
    //        {
    //            int numericValue = 0;
    //            bool isNumber = int.TryParse(split[i], out numericValue);
    //            if(isNumber == true)
    //            {
    //                shittyList.Add(numericValue);
    //            }
    //        }

    //        if(gameObject.Winner != "None")
    //        {
    //            winnerTitle.Text = winnerTitle.Text + " " + gameObject.Winner;
    //        }

    //        int x = shittyList.Last();
    //        cells[x].BackColor = Color.Blue;
    //        cells[x].Enabled = false;

    //    }
    //}
}
