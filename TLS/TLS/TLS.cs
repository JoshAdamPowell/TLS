using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;


namespace TLS
{
    class ThreeLetterSequences
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> CreateDictionary(string fileToRead)
            {
                //This function makes a dictionary from an file found in location. The dictionary has all 3 alphabetical sequences possible, with the amount
                //of times each appears as the value.

                int fileLength = fileToRead.Length;
                Dictionary<string, int> threeLetterSequenceDictionary = new Dictionary<string, int>();

                Regex regexToApply = new Regex(@"[A-Za-z]{3}");

                for (var i = 0; i < fileLength - 2; i++)
                {
                    string test = fileToRead.Substring(i, 3);
                    test = test.ToLower();
                    if (regexToApply.IsMatch(test))
                    {


                        if (threeLetterSequenceDictionary.ContainsKey(test))
                        {
                            threeLetterSequenceDictionary[test] = threeLetterSequenceDictionary[test] + 1;
                        }
                        else
                        {
                            threeLetterSequenceDictionary.Add(test, 1);
                        }
                    }


                }
                return threeLetterSequenceDictionary;
            }
            List<string> howManyTLSs(Dictionary<string, int> dictionary, int valueSearch)
            {
                //This function takes a dictionary <string, int> and and int and returns the keys which have the same value as the supplied int.
                var keysToFind = dictionary.Where(x => x.Value == valueSearch).Select(x => x.Key).ToList();
                return keysToFind;
            }

            List<string> mostCommonTLS(Dictionary<string, int> dictionary)
            {
                //This function takes a dictionary <string, int> and returns a list with the keys corresponding to the 10 highest values.
                var mostCommonKeys = dictionary.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

                int lengthOfList = mostCommonKeys.Count;
                mostCommonKeys.RemoveRange(10, lengthOfList - 10);
                return mostCommonKeys;
            }


            string rawData = File.ReadAllText(@"c:\work\training\TLS\SampleText.txt");

            var threeLetterSequences = CreateDictionary(rawData);

            Console.WriteLine("I can find all the three letter sequences that appear x times. How many times is x?");
            int valueToFind = Int32.Parse(Console.ReadLine());

            Console.WriteLine("These are all the TLSs which occur " + valueToFind + " times.");

            var whichTLSs = howManyTLSs(threeLetterSequences, valueToFind);

            foreach (string i in whichTLSs)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            var keys = mostCommonTLS(threeLetterSequences);
            Console.WriteLine("These are the 10 most common TLSs");
            foreach (string i in keys)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();

        }
    }
}
