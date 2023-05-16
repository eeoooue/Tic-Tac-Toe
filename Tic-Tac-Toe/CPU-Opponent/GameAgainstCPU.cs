using Game_Library;

namespace CPU_Opponent
{
    public class GameAgainstCPU : TicTacToeGame
    {
        private CPUOpponent _cpuPlayer;

        public GameAgainstCPU()
        {
            _cpuPlayer = new CPUOpponent(this, 'O');
            NotifyMove();
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