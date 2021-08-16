using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            Game game = new Game {PlayerId = PlayerId,Moves = "" ,Winner = "None"};
            
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
            
            var turnResultAsString = await response.Content.ReadAsStringAsync();
            var gameObject = JsonConvert.DeserializeObject<Game>(turnResultAsString);

            string[] split = gameObject.Moves.Split(new Char[] { ',', '\"' ,'\\'});
            List<int> shittyList = new List<int>();
            for(int i = 0; i < split.Length; i ++)
            {
                int numericValue = 0;
                bool isNumber = int.TryParse(split[i], out numericValue);
                if(isNumber == true)
                {
                    shittyList.Add(numericValue);
                }
            }
            
            int x = shittyList.Last();
            cells[x].BackColor = Color.Blue;
            cells[x].Enabled = false;
            
            
            

        }
    }
}
