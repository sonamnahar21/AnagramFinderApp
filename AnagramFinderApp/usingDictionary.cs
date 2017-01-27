using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinderApp
{
    class usingDictionary
    {
        private int noOfAnagrams;

        public int NoOfAnagrams
        {
            get
            {
                return noOfAnagrams;
            }
        }
        // to check if two strings are anagrams 
        //if match found return true else false  
        public bool IsAnagram(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return false;
            //considering the string is not anagram of itself
            if (str1.Equals(str2))
            {
                return false;
            }
            foreach (char c in str2)
            {
                int ix = str1.IndexOf(c);
                if (ix >= 0)
                    str1 = str1.Remove(ix, 1);
                else
                    return false;
            }

            return string.IsNullOrEmpty(str1);
        }
        //iterate thougth Dictionary. 
        public void AreAnagram(Dictionary<int, ArrayList> map)
        {
            foreach (KeyValuePair<int, ArrayList> kvp in map)
            {
                ArrayList inputArr = kvp.Value;

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
        }
    }
}

