using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HangMan
{
    internal class SecretStringManager
    {
        private static string baseText = "Considerate,la,vostra,semenza,fatti,non,foste,a,viver,come,bruti,ma,per,seguir,virtute,e,canoscenza".ToLower();
        public static string getSecretWorld() {
            string[] wordsList = baseText.Split(',');
            Random indexCalculator = new Random();
            do
            {
                int wordIndex = indexCalculator.Next(0, wordsList.Length - 1);
                if (wordsList[wordIndex].Length >= 4)
                    return wordsList[wordIndex];
            } while (true);

        }
        
    }
}
