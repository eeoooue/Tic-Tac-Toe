using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Library;

namespace CPU_Opponent
{
    internal class SimulationTile : AbstractTile
    {
        private GameSimulation _sim;
        public SimulationTile(GameSimulation sim, int row, int column) : base(row, column)
        {
            _sim = sim;
        }

        public override void Mark()
        {
            if (!Marked)
            {
                Marked = true;
                Character = _sim.CurrentPlayer;
            }
        }

        public void SetTeam(char team)
        {
            if (team != ' ')
            {
                Mark();
            }
            Character = team;
        }

        public void Unmark()
        {
            if (Marked)
            {
                Marked = false;
                Character = ' ';
            }
        }
    }
}
