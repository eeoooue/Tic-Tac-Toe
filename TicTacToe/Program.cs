

using TicTacToeLibrary;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game myGame = new Game();

            while (!myGame.GameOver())
            {
                DisplayGrid(myGame.grid);
                PlayerMove(ref myGame);
            }

            DisplayGrid(myGame.grid);

            if (myGame.HasWinner())
            {
                CongratulateWinner(myGame);
            }
            Console.WriteLine($"The game is over, thanks for playing!");
        }

        static void PlayerMove(ref Game myGame)
        {
            int activePlayer = (myGame.moves % 2) + 1;
            ConsoleColor playerColour = (activePlayer == 1) ? ConsoleColor.Red : ConsoleColor.Yellow;

            while (true)
            {
                SayInColour($"Player {activePlayer} ", playerColour);
                Console.WriteLine("make your move 'i j'");
                string playerInput = Console.ReadLine();

                try
                {
                    string[] moves = playerInput.Split(' ');
                    int i = int.Parse(moves[0]);
                    int j = int.Parse(moves[1]);

                    if (myGame.CanMove(i, j))
                    {
                        myGame.PlaceMove(i, j);
                        return;
                    }
                }
                catch
                {

                }

                SayInColour($"'{playerInput}' ", ConsoleColor.Cyan);
                Console.WriteLine($"couldn't be interpretted as a valid move");
            }
        }

        static void DisplayGrid(in char[,] grid)
        {
            Console.Clear();
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    WriteChar(grid[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void CongratulateWinner(Game myGame)
        {
            int winner = ((myGame.moves-1) % 2) + 1;
            ConsoleColor colour = (winner == 1) ? ConsoleColor.Red : ConsoleColor.Yellow;
            SayInColour($"Player {winner} ", ConsoleColor.Red);
            Console.WriteLine("wins!!");
        }

        static void SayInColour(string message, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void WriteChar(char c)
        {
            if (c == 'X')
            {
                SayInColour("X", ConsoleColor.Red);
            }
            else if (c == 'O')
            {
                SayInColour("O", ConsoleColor.Yellow);
            }
            else
            {
                SayInColour("#", ConsoleColor.Gray);
            }
        }


    }
}