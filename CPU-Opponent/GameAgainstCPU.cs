using TTT_Library;

namespace CPU_Opponent
{
    public class GameAgainstCPU : TicTacToeGame
    {
        private CPUOpponent _cpuPlayer;

        public GameAgainstCPU()
        {
            _cpuPlayer = new CPUOpponent(this);
        }

        public override void NotifyMove()
        {
            if (CurrentPlayer == _cpuPlayer.CPUTeam && !GameOver)
            {
                _cpuPlayer.MakeMove();
            }
        }
    }
}