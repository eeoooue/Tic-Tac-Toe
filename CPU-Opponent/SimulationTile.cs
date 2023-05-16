using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Library;

namespace CPU_Opponent
{
    internal class SimulationTile : BoardTile
    {
        public SimulationTile(SimulatedGame game, int i, int j) : base(game, i, j) { }

        public void SetTeam(char team)
        {
            Character = team;
        }
    }
}
