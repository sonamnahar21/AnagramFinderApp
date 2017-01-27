using System;
using System.Collections;
using System.Linq;

namespace AnagramFinderApp
{
    class usingLinq
    {
        private int noOfAnagrams;

        public int NoOfAnagrams
        {
            get
            {
                return noOfAnagrams;
            }
        }
        //this method will fetch the words from wordslist with respect to length frst 
        //and after that it will compare strings.
        //uses Lambda expression and Linq query
        public void findAnagram(ArrayList wordsList)
        {
            var groups = from string w in wordsList
                         group w by string.Concat(w.OrderBy(x => x)) into c
                         group c by c.Count() into d
                         orderby d.Key ascending
                         select d;
            foreach (System.Linq.IGrouping<int, System.Linq.IGrouping<string, string>> listOfWords in groups)
            {
                foreach (System.Linq.IGrouping<string, string> anagramMap in listOfWords)
                {
                    int anagramGroup = anagramMap.Count();

                    if (anagramGroup > 1)
                    {
                        Console.WriteLine(string.Join(" ", anagramMap));
                        noOfAnagrams++;
                    }
                }
            }
        }
    }
}
