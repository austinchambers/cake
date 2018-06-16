using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake
{
    internal class PermutationPalindrome
    {
        Dictionary<char, int> letterCount = new Dictionary<char, int>();

        public static void Test()
        {
            for (int i = 0; i < 800; i++)
            {
                String randomWord = Utils.RandomWord(5, 8);
                if (IsPalindromeForm(randomWord))
                {
                    Console.WriteLine(string.Format("\n{0}: permutation is Palindrome!", randomWord));
                }
                else
                {
                    Console.Write(string.Format("{0},", randomWord));
                }
            }
            return;
        }

        static bool IsPalindromeForm(String word)
        {
            HashSet<char> wordHash = new HashSet<char>(); 
            for (int i = 0; i < word.Length; i++)
            {
                if (wordHash.Contains(word[i]))
                {
                    wordHash.Remove(word[i]);
                }
                else
                {
                    wordHash.Add(word[i]);
                }
            }

            int maxAllowed = 0;
            if ((word.Length % 2 != 0) || (word.Length == 1))
            {
                maxAllowed++;
            }

            // Base Case: word size 0 or 1, technically yes. 
            if (wordHash.Count > maxAllowed)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
