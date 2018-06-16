﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake
{
    internal class Utils
    {
        static Random r = new Random();
        
        public static string RandomWord(int minSize = 5, int maxSize = 8)
        {
            int randLength = r.Next(minSize, maxSize);
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < randLength; i++)
            {
                char randChar = (char)(r.Next(0, 25) + 'a');
                word.Append(randChar);
            }
            return word.ToString();
        }

        public static int[] CountingSort(int[] theArray, int maxValue)
        {
            // 1. Get an array of all possible values and their counts. 
            // 2. Starting with the lowest num, add the number of counts. 
            // Node: We need to know the maxValue beforehand, if we didn't, it'd be O(n)
            // (The premise is the maxValue < n)

            // Get the array of counts, this array also implies an index sort by value. 
            int[] countArray = new int[maxValue + 1];
            foreach (var num in theArray)
            {
                countArray[num]++;
            }

            // Add the item the number of times that it was counted
            int[] sortedArray = new int[theArray.Length];
            int sortedArrayIndex = 0;
            for (int num = 0; num < countArray.Length; num++)
            {
                int count = countArray[num];
                for (int i = 0; i < count; i++)
                {
                    sortedArray[sortedArrayIndex] = num;
                    sortedArrayIndex++;
                }
            }
            return sortedArray;
        }

        internal static void Test()
        {
            int[] myArray = new int[5] { 1, 7, 1, 1, 8 };
            int[] sortedArray = CountingSort(myArray, 10);
            Console.WriteLine(sortedArray);
        }

    }
}
