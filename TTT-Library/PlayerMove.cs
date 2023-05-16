using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Library
{
    public class PlayerMove
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public char Team { get; private set; }

        public PlayerMove(int i, int j, char team)
        {
            Row = i;
            Column = j;
            Team = team;
        }
    }

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
