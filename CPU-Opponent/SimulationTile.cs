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

        public override void Click()
        {
            if (!Clicked)
            {
                Clicked = true;
                Character = _sim.CurrentPlayer;
            }
        }

        public void SetTeam(char team)
        {
            if (team != ' ')
            {
                Click();
            }
            Character = team;
        }

        public void Unclick()
        {
            if (Clicked)
            {
                Clicked = false;
                Character = ' ';
            }
        }
    }
}
