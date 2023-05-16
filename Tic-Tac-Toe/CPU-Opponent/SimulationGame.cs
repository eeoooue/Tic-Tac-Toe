using Game_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Opponent
{
    internal class SimulationGame : TicTacToeGame
    {
        public SimulationGame(TicTacToeGame originalGame)
        {
            LoadMoves(originalGame);
        }

        private void LoadMoves(TicTacToeGame originalGame)
        {
            foreach (PlayerMove move in originalGame.MoveHistory)
            {
                SubmitMove(move);
            }
        }

        private bool CanMove(int i, int j)
        {
            GameTile tile = Board.GetTile(i, j);
            return tile.Character == ' ';
        }

        public List<PlayerMove> GetPossibleMoves()
        {
            List<PlayerMove> possibleMoves = new();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (CanMove(i, j))
                    {
                        PlayerMove move = new PlayerMove(i, j, CurrentPlayer);
                        possibleMoves.Add(move);
                    }
                }
            }
            return possibleMoves;
        }

        public void UndoPreviousMove()
        {
            PlayerMove move = MoveHistory.Pop();
            GameTile tile = Board.GetTile(move.Row, move.Column);
            tile.Unmark();
        }
    }
}
