using System;

namespace WordGames
{
    class MainGameController
    {
        private static Game game;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");

            game = new Game();

            while (!game.Guess()) ;
        }
    }
}
