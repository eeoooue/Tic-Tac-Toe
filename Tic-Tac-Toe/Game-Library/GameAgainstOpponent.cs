using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Library
{
    public class GameAgainstOpponent : TicTacToeGame
    {
        private Opponent _opponent;

        public GameAgainstOpponent(Opponent opponent)
        {
            _opponent = opponent;
            NotifyMove();
        }

        public override void NotifyMove()
        {
            if (CurrentPlayer == _opponent.Team && !GameOver)
            {
                PlayerMove move = _opponent.MakeMove(this);
                SubmitMove(move);
            }
        }
    }
}
