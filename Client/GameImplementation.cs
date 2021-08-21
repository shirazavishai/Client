using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class GameImplementation
    {
        private const int ROWS_SIZE = 5;
        private const int COLUMNS_SIZE = 5;

        private const int HUMAN_SIGN = 0;
        private const int SERVER_SIGN = 1;

        private int GameId;
        private int PlayerId;

        private int[] gameBoardCells;
        private List<int> unreachedCells;
        public List<int> gameMovesMemo { get; set; }
        private static HttpClient client;

        public GameImplementation(int gameId,int playerId,HttpClient rec_client)
        {
            initializeCellsCollections();
            client = rec_client;
            gameMovesMemo = new List<int>();
            GameId = gameId;
            PlayerId = playerId;
        }

     

        private void initializeCellsCollections()
        {
            gameBoardCells = new int[25];
            unreachedCells = new List<int>();

            for (int i = 0; i < 25; i++)
            {
                gameBoardCells[i] = -1;
                unreachedCells.Add(i);
            }
        }

        public async Task<GameRound> PlayRound(string humanCellChoiceLabel)
        {
            GameRound round = new GameRound();
            int humanIndex = getCellIndex(humanCellChoiceLabel);
            round.HumanIndexMove = humanIndex;
            round.Winner = "None";
            gameBoardCells[humanIndex] = HUMAN_SIGN;
            unreachedCells.Remove(humanIndex);
            gameMovesMemo.Add(humanIndex);
            round.unreachedCells = unreachedCells;
             
            if (CheckIfGameOver(HUMAN_SIGN) == true)
            {
                round.Winner = "Human";
                return round;
            }

            else if(round.unreachedCells.Count > 0)
            {
                round = await ServerTurn(round);
                int serverIndex = round.ServerIndexMove;
                gameBoardCells[serverIndex] = SERVER_SIGN;
                unreachedCells.Remove(serverIndex);
                gameMovesMemo.Add(serverIndex);

                if (CheckIfGameOver(SERVER_SIGN))
                {
                    round.Winner = "Server";
                }
                else
                {
                    round.Winner = "None";
                }
            }

            return round;

        }

        private async Task<GameRound> ServerTurn(GameRound round)
        {

            string url = "api/TblGames/server-turn";

            var gameRound = new GameRound
            { 
                ServerIndexMove = -1,
                unreachedCells = unreachedCells
            };

            HttpResponseMessage response = await client.PostAsJsonAsync(url, gameRound);

            if (response.IsSuccessStatusCode)
            {
                var serverTurnData = await response.Content.ReadAsStringAsync();
                var gameRoundObject = JsonConvert.DeserializeObject<GameRound>(serverTurnData);
                return gameRoundObject;
            }
            return null;           
        }

        public int getCellIndex(String cellLabel)
        {
            int indexLength = cellLabel.Length - 10;
            int index = Int32.Parse(cellLabel.Substring(10, indexLength));
            return index;
        }

        public bool CheckIfGameOver(int player)
        {
            if (RowCrossed(player) || columnCrossed(player) || diagonalCrossed(player))
            {
                return true;
            }
            return false;
        }

        public bool RowCrossed(int player)
        {
            for (int i = 0; i < ROWS_SIZE * ROWS_SIZE; i += ROWS_SIZE)
            {
                if (gameBoardCells[i + 1] == player &&
                    gameBoardCells[i + 1] == gameBoardCells[i + 2] &&
                    gameBoardCells[i + 2] == gameBoardCells[i + 3])
                {
                    if (gameBoardCells[i] == gameBoardCells[i + 1] || gameBoardCells[i + 3] == gameBoardCells[i + 4])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool columnCrossed(int player)
        {
            for (int i = 0; i < COLUMNS_SIZE; i++)
            {
                if (gameBoardCells[i + COLUMNS_SIZE] == player &&
                    gameBoardCells[i + COLUMNS_SIZE] == gameBoardCells[i + 2 * COLUMNS_SIZE] &&
                    gameBoardCells[i + 2 * COLUMNS_SIZE] == gameBoardCells[i + 3 * COLUMNS_SIZE])
                {
                    if (gameBoardCells[i] == gameBoardCells[i + COLUMNS_SIZE] || gameBoardCells[i + 3 * COLUMNS_SIZE] == gameBoardCells[i + 4 * COLUMNS_SIZE])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool diagonalCrossed(int player)
        {
            if (gameBoardCells[6] == gameBoardCells[12] && gameBoardCells[12] == gameBoardCells[18] && gameBoardCells[6] == player)
            {
                if (gameBoardCells[0] == gameBoardCells[6] || gameBoardCells[24] == gameBoardCells[18])
                {
                    return true;
                }
            }
            if (gameBoardCells[8] == gameBoardCells[12] && gameBoardCells[12] == gameBoardCells[16] && gameBoardCells[8] == player)
            {
                if (gameBoardCells[4] == gameBoardCells[8] || gameBoardCells[20] == gameBoardCells[16])
                {
                    return true;
                }
            }
            if (gameBoardCells[1] == gameBoardCells[7] && gameBoardCells[7] == gameBoardCells[13] && gameBoardCells[13] == gameBoardCells[19] && gameBoardCells[1] == player)
            {
                return true;
            }
            if (gameBoardCells[3] == gameBoardCells[7] && gameBoardCells[7] == gameBoardCells[11] && gameBoardCells[11] == gameBoardCells[15] && gameBoardCells[3] == player)
            {
                return true;
            }
            if (gameBoardCells[5] == gameBoardCells[11] && gameBoardCells[11] == gameBoardCells[17] && gameBoardCells[17] == gameBoardCells[23] && gameBoardCells[5] == player)
            {
                return true;
            }
            if (gameBoardCells[9] == gameBoardCells[13] && gameBoardCells[13] == gameBoardCells[17] && gameBoardCells[17] == gameBoardCells[21] && gameBoardCells[9] == player)
            {
                return true;
            }

            return false;
        }

        public async void saveGame(string gameWinner,Player thePlayer)
        {
            string gameMoves = string.Join(",", gameMovesMemo);

            string url = "api/TblGames/" + GameId;
            var game = new Game { Id = GameId,PlayerId = PlayerId.ToString(), Moves = gameMoves, Winner = gameWinner };

            HttpResponseMessage response = await client.PutAsJsonAsync(url, game);

            if (response.IsSuccessStatusCode)
            {
                var gameAsString = await response.Content.ReadAsStringAsync();
                var gameObject = JsonConvert.DeserializeObject<Game>(gameAsString);
            }

            string playerUrl = "api/TblPlayers/" + PlayerId;
            var player = new Player { Id = PlayerId, Name = thePlayer.Name, Games = thePlayer.Games + GameId + "," };
            HttpResponseMessage response2 = await client.PutAsJsonAsync(playerUrl, player);

        }
    }
}
