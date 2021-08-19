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
    public partial class GamesDisplay : Form
    {
        private Player player;
        private ProjectDBEntities6 GamesMemoDB;

        public GamesDisplay(Player gamePlayer)
        {
            InitializeComponent();
            player = gamePlayer;
            GamesMemoDB = new ProjectDBEntities6();
        }

        private void GamesDisplay_Load(object sender, EventArgs e)
        {
            var query = from p in GamesMemoDB.TblPlayersGamesMemoes
                        where p.PlayerId == player.Id
                        select p;

            IEnumerable<TblPlayersGamesMemo> games = query.ToList();

            PastGameWatch postGameWatch = new PastGameWatch(player, games.First().GameId, games.First().Moves);
            
        }
    }
}
