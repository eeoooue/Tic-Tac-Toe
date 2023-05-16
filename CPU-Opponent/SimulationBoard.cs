using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Library;

namespace CPU_Opponent
{
    internal class SimulationBoard : AbstractGameBoard
    {
        public void CopyBoard(GameSimulation sim, AbstractGameBoard board)
        {
            for(int i=0; i < _rows; i++)
            {
                for(int j=0; j < _cols; j++)
                {
                    AbstractTile originalTile = board.GetTile(i, j);
                    SimulationTile simTile = new(sim, i, j);
                    simTile.SetTeam(originalTile.Character);

                    _tiles[i, j] = simTile;
                }
            }
        }

        public int GetMoveCount()
        {
            int count = 0;
            foreach(AbstractTile tile in _tiles)
            {
                if (tile != null)
                {
                    if (tile.Character != ' ')
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
