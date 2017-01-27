using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinderApp
{
    class usingBruteForceApproach
    {
        private int noOfAnagrams;

        public int NoOfAnagrams
        {
            get
            {
                return noOfAnagrams;
            }
        }
        //iterating through the list of words and comparing each word with the rest of the words in the list.
        public void findAnagram(ArrayList inputArr)
        {
            while (inputArr.Count != 0)
            {
                String currentWord = inputArr[0].ToString();
                inputArr.Remove(currentWord);
                ArrayList anagramMatchingCurrentWord = new ArrayList();

                for (int i = 0; i < inputArr.Count; i++)
                {
                    String wordToBeMatched = inputArr[i].ToString();
                    if (IsAnagram(currentWord, wordToBeMatched))
                    {
                        anagramMatchingCurrentWord.Add(wordToBeMatched);
                    }
                }
                if (anagramMatchingCurrentWord.Count > 0)
                {
                    Console.WriteLine();
                    Console.Write(currentWord + " ");
                    foreach (string str in anagramMatchingCurrentWord)
                    {
                        Console.Write(str + " ");
                        inputArr.Remove(str);
                        
                    }
                    noOfAnagrams++;
                }
            }
        }
        public static bool IsAnagram(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return false;
            //considering the string is not anagram of itself
            if (s1.Equals(s2))
            {
                return false;
            }
            if (s1.Length!=s2.Length)
            {
                return false;
            }
            foreach (char c in s2)
            {
                int ix = s1.IndexOf(c);
                if (ix >= 0)
                    s1 = s1.Remove(ix, 1);
                else
                    return false;
            }

            return string.IsNullOrEmpty(s1);
        }
    }
}
