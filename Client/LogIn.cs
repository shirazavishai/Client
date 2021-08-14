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
using System.Web.Helpers;
using System.Windows.Forms;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

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

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Player p = new Player { Id = 5, Name = "Nissim", Games = "Nisso" };
            string responseData = CreateProductAsync(p).ToString();
            UserNameNull.Visible = true;
            UserNameNull.Text = responseData;

            //HttpResponseMessage response = client.PostAsJsonAsync("api/products", p);

            //JValue j = (JValue)JToken.FromObject(p);
            //HttpRequestMessage response = client.PostAsync("api/TblPlayers");
            
            //UserNameNull.Text = response.ToString();
            //UserNotFound.Visible = false;
            //UserIdNotValid.Visible = false;

            //if (UserNameInput.Text=="")
            //{
            //    UserNameNull.Visible = true;
            //}

            //else if (IdInput==null || !int.TryParse(IdInput.Text, out int n))
            //{
            //    UserIdNotValid.Visible = true;
            //}

            //else
            //{
            //    UserNameNull.Visible = true;
            //    UserIdNotValid.Visible = true;

            //    var response = client.GetAsync("api/TblPlayers/" + IdInput.Text);
            //    UserNameNull.Text = IdInput.Text;
            //    UserIdNotValid.Text = response.Result.ToString();
            //    if (response == null)
            //    {
            //        UserNotFound.Visible = true;
            //    }
            //    else
            //    {
            //        gameBoard = new Board(IdInput.Text);
            //        gameBoard.ShowDialog();
            //        Close();
            //    }

            //}

            //Board board = new Board();
            //board.Activate();
           
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
