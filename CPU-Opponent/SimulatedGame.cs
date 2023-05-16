using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Library;

namespace CPU_Opponent
{
    internal class SimulatedGame : TicTacToeGame
    {
        private readonly Stack<PlayerMove> _moves = new Stack<PlayerMove>();

        public void CloneBoard(GameBoard gameBoard)
        {
            foreach(BoardTile tile in gameBoard.Tiles)
            {
                int i = tile.Row;
                int j = tile.Column;

                SimulationTile simTile = new SimulationTile(this, i, j);
                simTile.SetTeam(tile.Character);
                Board.Tiles[i, j] = simTile;
            }
        }

        private bool CanMove(int i, int j)
        {
            BoardTile tile = Board.GetTile(i, j);
            return !tile.Clicked;
        }

        public bool SimulateMove(PlayerMove move)
        {
            if (CanMove(move.Row, move.Column))
            {
                SubmitMove(move);
                _moves.Push(move);
                return true;
            }
            return false;
        }

        public void UndoPreviousMove()
        {
            if (_moves.Count > 0)
            {
                PlayerMove move = _moves.Pop();
                ResetTile(move.Row, move.Column);
            }
        }

        private void ResetTile(int row, int column)
        {
            Board.Tiles[row, column] = new SimulationTile(this, row, column);
        }
    }
}
