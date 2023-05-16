using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Library;

namespace CPU_Opponent
{
    internal class EvaluatedMove : PlayerMove
    {
        public int Score { get; private set; }

        public EvaluatedMove(int i, int j, char team, int score) : base(i, j, team)
        {
            Score = score;
        }

        public EvaluatedMove(PlayerMove move, int score) : this(move.Row, move.Column, move.Team, score) { }
    }
}
