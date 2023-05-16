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
        public SimulationTile(GameSimulation sim, int row, int column) : base(row, column)
        {

        }

        public override void Click()
        {
            if (!Clicked)
            {
                Clicked = true;
            }
        }

        public void SetTeam(char team)
        {
            Character = team;
        }

        public void Unclick()
        {
            if (Clicked)
            {
                Clicked = false;
            }
        }
    }
}
