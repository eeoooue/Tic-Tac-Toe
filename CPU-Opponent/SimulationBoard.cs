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

        public SimulationBoard(GameSimulation sim)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _tiles[i, j] = new SimulationTile(sim, i, j);
                }
            }
        }

    }
}
