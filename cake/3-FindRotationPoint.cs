using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake
{
    internal class FindRotationPoint
    {
        // You're given a list of sorted words, except it doesn't start from 'aaa'
        // Find the first word 
        // 
        public static int RotationPoint(string[] semiSortedWords)
        {
            return RotationPoint(semiSortedWords, 0, semiSortedWords.Length);
        }
        public static int RotationPoint(string[] semiSortedWords, int skip, int take)
        {
            for (int i = skip; i < skip + take; i++)
            {
                Console.Write(semiSortedWords[i] + ",");
            }
            Console.WriteLine();

            // Base case: take == 1
            if (take == 1)
            {
                return skip;
            }
            if (take == 2)
            {
                if (semiSortedWords[skip].CompareTo(semiSortedWords[skip+1]) <= 0)
                {
                    // Mid comes before first, return skip + 1
                    return skip;
                }
                else
                {
                    return skip+1;
                }
            }

            int firstIndex = skip;
            int lastIndex = skip + (take - 1);
            int midIndex = take / 2 + skip;
            string first = semiSortedWords[firstIndex];
            string last = semiSortedWords[lastIndex];
            string mid = semiSortedWords[midIndex];

            Console.WriteLine(first + " " + mid + " " + last);

            if (mid.CompareTo(first) <= 0)
            {
                // Mid comes before first, we're in the first section
                Console.WriteLine("First Section");
                return RotationPoint(semiSortedWords, skip, (int)Math.Ceiling(take / 2.0));
            }
            else
            {
                // Mid comes after first, we're in the second section
                Console.WriteLine("Second Section");
                // We're in the second section
                return RotationPoint(semiSortedWords, skip + (int)Math.Ceiling(take / 2.0), (int)Math.Floor(take / 2.0));
            }
        }

        public static void Test()
        {
            string[] words = new string[] { "frank", "zoolander", "apple", "bean", "corn", "eagle" };
            Console.WriteLine("First word is: " + words[RotationPoint(words)]);
        }
    }
}
