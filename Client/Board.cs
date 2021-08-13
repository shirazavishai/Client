using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Client
{

    public partial class Board : Form
    {

        private static HttpClient httpclient = new HttpClient();

        public Board()
        {
            InitializeComponent();

        }

        private async void Board_Load(object sender, EventArgs e)
        {
            httpclient.BaseAddress = new Uri("https://localhost:44317/");
            await CreateGameAsync("Nissim");
            label2.Visible = false;
        }


        static async Task<Uri> CreateGameAsync(string playerId)
        {
            string playerIdAsJson = JsonConvert.SerializeObject(new { playerId = playerId});

            var content = new StringContent(playerIdAsJson, Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await httpclient.PostAsync(httpclient.BaseAddress, content);
            
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            String cellLabel = ((PictureBox)sender).Name;

            PictureBox pb = (PictureBox)sender;
            pb.Enabled = false;
            //Game.doMove(cellLabel, Moves);

            var values = new Dictionary<string, Object>
            {
                { "cellLabel", cellLabel }
            };

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
