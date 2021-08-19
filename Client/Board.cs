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
        private const int NEW_GAME = 1;
        public PictureBox[] cells { get; set; }

        private GameImplementation gameImplementation;

        private Player gamePlayer;
        private int gameId;

        public Board(Player player,int gId,int gameType)
        {
            InitializeComponent();

            cells = new PictureBox[]{ pictureBox0, pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                                     pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9,
                                     pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14,
                                     pictureBox15, pictureBox16,pictureBox17, pictureBox18, pictureBox19,
                                     pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24};

            gamePlayer = player;
            gameId = gId;

            if (gameType == NEW_GAME)
            {
                gameImplementation = new GameImplementation(gameId, gamePlayer.Id);
            }
            
        }

        private void Board_Load(object sender, EventArgs e)
        {
            humanLabel.Text = gamePlayer.Name;
            changePlayersLabelsVisibility(true, false);
            gamePlayersLabel.Text = "Computer\n\n vs.\n\n" + gamePlayer.Name;
            
        }


        private async void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            String cellLabel = pb.Name;

            pb.BackColor = Color.Red;

            pb.Enabled = false;

            changePlayersLabelsVisibility(false, true);

            makeCellsUnClickable();

            GameRound currentRound = await gameImplementation.PlayRound(cellLabel);

            collectRoundResults(currentRound);

        }

        private void collectRoundResults(GameRound currentRound)
        {
            if (currentRound.ServerIndexMove != -1 && currentRound.Winner != "Human")
            {
                cells[currentRound.ServerIndexMove].BackColor = Color.Blue;
                cells[currentRound.ServerIndexMove].Enabled = false;
            }
            string gameWinner;
            if (currentRound.Winner != "None")
            {
                changePlayersLabelsVisibility(false, false);
                winnerTitle.Text = "The winner is : ";

                if (currentRound.Winner == "Human")
                {
                    gameWinner = gamePlayer.Name;
                    winnerTitle.Text += gamePlayer.Name + " ! ";
                }

                else
                {
                    gameWinner = "Computer";
                    winnerTitle.Text += "Computer !";
                }
                
                winnerTitle.Visible = true;
                saveGame(gameWinner);
                return;
            }

            if (currentRound.unreachedCells.Count == 0)
            {
                gameWinner = "Draw";
                changePlayersLabelsVisibility(false, false);
                winnerTitle.Text = "GAME OVER";
                winnerTitle.Visible = true;
                saveGame(gameWinner);
                return;
            }

            changePlayersLabelsVisibility(true,false);
            
            makeCellsClickable();
        }

        private void changePlayersLabelsVisibility(bool humanLabelAction,bool computerLabelAction)
        {
            humanLabel.Visible = humanLabelAction;
            computerLabel.Visible = computerLabelAction;
        }

        public void makeCellsUnClickable()
        {
            for(int i = 0; i < cells.Length; i ++)
            {
                cells[i].Enabled = false;
            }
        }

        public void makeCellsClickable()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].BackColor.Name == "Window")
                {
                    cells[i].Enabled = true;
                }
            }
        }
        private void saveGame(string gameWinner)
        {
            saveGameForClient();
            gameImplementation.saveGame(gameWinner);
        }

        private void saveGameForClient()
        {
            GamesMemoDB GamesMemoDB = new GamesMemoDB();

            string gameMoves = string.Join(",", gameImplementation.gameMovesMemo);

            TblPlayersGamesMemo gameMemo = new TblPlayersGamesMemo();

            gameMemo.GameId = gameId;
            gameMemo.PlayerId = gamePlayer.Id;
            gameMemo.Moves = gameMoves;

            GamesMemoDB.TblPlayersGamesMemo.Add(gameMemo);
            GamesMemoDB.SaveChanges();
        }
    }
}
