namespace Game_Library
{
    public class GameBoard
    {
        protected GameTile[,] _tiles = new GameTile[3, 3];

        public GameBoard(TicTacToeGame myGame)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _tiles[i, j] = new GameTile(myGame, i, j);
                }
            }
        }

        public GameTile GetTile(int row, int column)
        {
            return _tiles[row, column];
        }
    }
}