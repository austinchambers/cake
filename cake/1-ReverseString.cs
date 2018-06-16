using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake
{
    class ReverseString
    {
        public static void Test()
        {
            for (int i = 0; i < 10; i++)
            {
                String randomWord = Utils.RandomWord();
                String reverseWord = ReverseWord(randomWord);
                Console.WriteLine(" Random Word is: " + randomWord);
                Console.WriteLine("Reverse Word is: " + reverseWord);

                if ((randomWord != ReverseWord(reverseWord)) || (randomWord == reverseWord))
                {
                    Console.WriteLine("Tests Failed!!");
                    return;
                }
            }
            return;
        }

        public static string ReverseWord(String word)
        {
            StringBuilder reversedWord = new StringBuilder(word);
            if (word.Length <= 1) return word;

            int startPos = 0;
            int endPos = word.Length - 1;

            while ((startPos != endPos) && (endPos > 0))
            {
                char tempChar = reversedWord[startPos];
                reversedWord[startPos] = reversedWord[endPos];
                reversedWord[endPos] = tempChar;
                startPos++;
                endPos--;
            }

            return reversedWord.ToString();
        }
    }
}
