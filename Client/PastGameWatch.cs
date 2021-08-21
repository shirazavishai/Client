using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    
    public class PastGameWatch
    {
        private Board gameBoard;
        private const int PAST_GAME = 0;
        private List<int> gameMoves;

        public PastGameWatch(Player player, int gId,string moves)
        {
            gameBoard = new Board(player, gId, PAST_GAME,null);
            gameBoard.Activate();            
            gameBoard.Show();
            gameBoard.makeCellsUnClickable();           
            gameMoves = new List<int>(Array.ConvertAll(moves.Split(','), int.Parse));      
        }


        public int startGame()
        {
            for(int i = 0; i < gameMoves.Count; i ++)
            {
                int index = gameMoves[i];

                PictureBox currentCell = gameBoard.cells[index];

                if (i % 2 == 0)
                {
                    currentCell.BackColor = Color.Red;
                }
                else
                {
                    currentCell.BackColor = Color.Blue;
                }
                Thread.Sleep(800);
            }
            return 0;
        }

    }
}
