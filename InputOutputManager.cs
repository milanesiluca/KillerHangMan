using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    internal class InputOutputManager
    {

        List<char> typedChar = new List<char>();    
        public void createMenu()
        {

            Console.WriteLine("\nAvailable option:\n");
            Console.WriteLine("1 - Insert a letter");
            Console.WriteLine("2 - Try to gess the word");
            Console.WriteLine("3 - Leave the Game");
            Console.WriteLine();
            Console.Write("Insert your choice: ");
            


        }

        public int manageInput() {

            int option = -1;
            string choice = Console.ReadLine();
            try
            {
                option = int.Parse(choice);
                
            }
            catch (FormatException exp)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice (what an idiot!)");
                Console.WriteLine("Press return to try again...");
                _ = Console.ReadLine();
                Console.Clear();

            }
            finally
            {
                Console.ResetColor();
            }

            return option;

        }

        public bool validateWord(string word)
        {
            Console.Write("Ok my friend, you have choose to challenge the fortune!\nTry to guess the word: ");
            var triedWord = Console.ReadLine();
            if (!string.IsNullOrEmpty(triedWord))
            {
                if (triedWord == word)
                {
                    Console.WriteLine("YES! very good job, you have guessed! Congratulations!!!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Oh no! you have faild and now you are closer to yout daeth!\n");
                    return false;
                }
            }
            Console.WriteLine("Oh no, empty string! you have failed, and your death i closer now!");
            return false;
        }

        public char validateChar(char[] cArray)
        {
            Console.Write("Insert the char please: ");
            char typedCh = Console.ReadKey().KeyChar;
            try
            {
                if (typedChar.Contains(typedCh))
                {
                    Console.WriteLine("\n\nYou have already typed this char. But I am kind today, I don't calculate your attempt");
                    return '"';
                }

                typedChar.Add(typedCh);
                if (cArray.Contains(typedCh)) {
                    Console.WriteLine("\n\nGood job, the word containes the typed char");
                    return typedCh;
                }else
                {
                    Console.WriteLine("\n\nSorry, the word doesn't containe the typed char");
                    return ' ';
                }

            } catch (Exception ex) {
                Console.WriteLine("Nooooo goooood!!! please insert a valid char");
                return ' ';
            }
            
        }

    }


}



