using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace AnagramFinderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "words.txt";
            //read data from file
            ArrayList wordsList = readInput(fileName);
            ArrayList wordListBackup = (ArrayList)wordsList.Clone();
            int wordCount = wordListBackup.Count;

            //create map         
            Dictionary<int, ArrayList> map = createMap(wordsList);


            // finding anagrams using BruteForceApproch.
            Console.WriteLine("\n\nfinding anagrams using Brute Force Approach ");
            double start = DateTime.Now.TimeOfDay.TotalMilliseconds;
            usingBruteForceApproach usingBruteForceApproch = new usingBruteForceApproach();
            usingBruteForceApproch.findAnagram(wordListBackup);
            double end = DateTime.Now.TimeOfDay.TotalMilliseconds;
            double timeforBrute = end - start;


            // finding anagrams using Dictionary.
            Console.WriteLine("\n\nfinding anagrams using  Dictionary");
            start = DateTime.Now.TimeOfDay.TotalMilliseconds;
            usingDictionary usingDictionary = new usingDictionary();
            usingDictionary.AreAnagram(map);
            end = DateTime.Now.TimeOfDay.TotalMilliseconds;
            double timeforDictionary = end - start;


            // finding anagrams using Linq.
            Console.WriteLine("\n\nfinding anagrams using Linq");
            start = DateTime.Now.TimeOfDay.TotalMilliseconds;
            usingLinq usingLinq = new usingLinq();
            usingLinq.findAnagram(wordsList);
            end = DateTime.Now.TimeOfDay.TotalMilliseconds;
            double timeforLinq = end - start;
         
            // to print logs 
            Console.WriteLine("\n\n\n\n\n\n\nWord count: " + wordCount);
            Console.WriteLine("Number of anagrams: " + usingLinq.NoOfAnagrams);
            Console.WriteLine("\nTime required in milliseconds for Brute Force Approach  :  " +Convert.ToInt32(timeforBrute));
            Console.WriteLine("\nTime required in milliseconds Dictionary:  " + Convert.ToInt32(timeforDictionary));
            Console.WriteLine("\nTime required in milliseconds for Linq:  " + Convert.ToInt32(timeforLinq));
            
            Console.ReadKey(); 
        }
        public static ArrayList readInput(string fileName)
        {
            ArrayList WordsList = new ArrayList();
            String path = Environment.CurrentDirectory + "\\"+ fileName;
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                WordsList.Add(line.ToLower());
            }
            return WordsList;
        }
        public static Dictionary<int, ArrayList> createMap(ArrayList wordsList)
        {
            Dictionary<int, ArrayList> map = new Dictionary<int, ArrayList>();
            foreach (string str in wordsList)
            {
                if (!map.ContainsKey(str.Length))
                {
                    ArrayList newList = new ArrayList();
                    newList.Add(str);
                    map.Add(str.Length, newList);
                }
                else
                {
                    ArrayList oldList = new ArrayList();
                    oldList = map[str.Length];
                    oldList.Add(str);
                    map[str.Length] = oldList;
                }
            }
            return map;
        }
    }    
}
