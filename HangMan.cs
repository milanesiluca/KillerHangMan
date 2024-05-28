namespace HangMan
{
    internal class HangMan
    {
        static void Main(string[] args)
        {
            GameSession newGame = new GameSession();
            //Console.WriteLine(newGame.SecretWord);

            newGame.runGame();
        }
    }
}
