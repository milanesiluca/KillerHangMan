using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    public class GameSession
    {
        private string _secretWord = string.Empty;
        private const int _numberOfMaxAttempt = 10;
        private int _attemptUsed = 0;
        private InputOutputManager gameConsole = new InputOutputManager();
        private char[] _wordsChar;
        private char[] _insertedChars;
        private StringBuilder _wordBuilder = new StringBuilder();


        public string SecretWord
        {
            get
            {
                return _secretWord;
            }
        }

        public GameSession()
        {
            _secretWord = SecretStringManager.getSecretWorld();
            _wordsChar = _secretWord.ToCharArray();
            _insertedChars = new char[_secretWord.Length];

        }

        public void runGame()
        {
            char wordChar;
            string word = string.Empty;

            for (int i = 0; i < _wordsChar.Length; i++)
            {
                _insertedChars[i] = '_';
                _wordBuilder.Append(_insertedChars[i]);
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************");
            Console.WriteLine("*                           *");
            Console.WriteLine("* Wellcome to Mortal Kombat *");
            Console.WriteLine("*                           *");
            Console.WriteLine("* Sorry, I mean, to Hangman *");
            Console.WriteLine("*                           *");
            Console.WriteLine("*****************************");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*      Prepare to Die!      *");
            Console.ResetColor(); 
            Console.WriteLine();


            string temporaryString = _wordBuilder.ToString();
            bool completed = false;
            do
            {
                Console.WriteLine($"Your word is {SecretWord.Length} characters long\n");
                Console.WriteLine(temporaryString);
                _wordBuilder.Clear();

                gameConsole.createMenu();
                int option = gameConsole.manageInput();
                switch (option)
                {
                    case -1:
                        break;
                    case 1:
                        char typedChar = gameConsole.validateChar(_wordsChar);
                        if (typedChar != ' ' && typedChar != '"')
                        {
                            for (int i = 0; i < _wordsChar.Length; i++)
                            {

                                if (_wordsChar[i] == typedChar)
                                {
                                    _insertedChars[i] = typedChar;
                                }
                                else
                                    continue;

                            }
                            Console.WriteLine($"Your word is {SecretWord.Length} characters long\n");

                            for (int i = 0; i < _insertedChars.Length; i++)
                            {
                                _wordBuilder.Append(_insertedChars[i]);
                            }
                            Console.WriteLine(_wordBuilder.ToString());
                            temporaryString = _wordBuilder.ToString();
                            if (_wordBuilder.ToString() == _secretWord)
                                completed = true;
                            _wordBuilder.Clear();
                        }
                        else
                            _attemptUsed++;
                        break;
                    case 2:
                        var succes = gameConsole.validateWord(_secretWord);
                        if (succes == true)
                            Environment.Exit(0);
                        else
                            _attemptUsed++;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Goodbye and thanks for gaming with us");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice (what an idiot!)");
                        Console.WriteLine("Press return to try again...");
                        _ = Console.ReadLine();
                        Console.Clear();
                        Console.ResetColor();
                        break;

                }


            } while (_attemptUsed < _numberOfMaxAttempt && completed == false );

            if (completed == true)
            {
                Console.WriteLine("YES! very good job, you have guessed! Congratulations!!!");
                Console.WriteLine("Goodbye and thanks for gaming with us");
                
            } else {

                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine("*****************************");
                Console.WriteLine("*                           *");
                Console.WriteLine("*         YOU DIED!         *");
                Console.WriteLine("*                           *");
                Console.WriteLine("*         Fatality!         *");
                Console.WriteLine("*                           *");
                Console.WriteLine("*****************************");
                Console.ResetColor();
            
            }
            Environment.Exit(0);
        }
 
    }
}

       

