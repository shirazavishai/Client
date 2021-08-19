using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class GamesDisplay : Form
    {
        private Player player;
        private GamesMemoDB GamesMemoDB;

        private const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\AppData\\Local\\Microsoft\\Microsoft SQL Server Local DB\\Instances\\MSSQLLocalDB\\GamesAndPlayersDB.mdf;Integrated Security = True; Connect Timeout = 30";
        public GamesDisplay(Player gamePlayer)
        {
            InitializeComponent();
            player = gamePlayer;
            GamesMemoDB = new GamesMemoDB();
        }

        private void GamesDisplay_Load(object sender, EventArgs e)
        {
            TblbindingSource1.DataSource = GamesMemoDB.TblPlayersGamesMemo.ToList();
            dataGridView1.DataSource = TblbindingSource1;
            ShowGames();
        }

        private void ShowGames()
        {
            var query = from p in GamesMemoDB.TblPlayersGamesMemo
                        where p.PlayerId == player.Id
                        select p;
            dataGridView1.DataSource = query.ToList();
        }

        private async void choose_Click(object sender, EventArgs e)
        {
            try
            {
                int gameId = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string gameMoves = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                PastGameWatch postGameWatch = new PastGameWatch(player,gameId, gameMoves);
                await Task.Run<int>(()=> postGameWatch.startGame());
            }
            catch (Exception ex)
            {
                choose.Text = "Must select a game";
            }
            
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
