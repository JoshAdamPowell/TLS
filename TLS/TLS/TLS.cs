using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace TLS
{
    class ThreeLetterSequences
    {
        static void Main(string[] args)
        {
            Dictionary <string, int> CreateDictionary (string fileLocation)
            {
                //This function makes a dictionary from an file found in location. The dictionary has all 3 alphabetical sequences possible, with the amount
                //of times each appears as the value.
                string input = File.ReadAllText(fileLocation);
                int length = input.Length;
                Dictionary<string, int> tls = new Dictionary<string, int>();

                Regex characters = new Regex(@"[A-Za-z]{3}");

                for (var i = 0; i < length - 2; i++)
                {
                    string test = input.Substring(i, 3);
                    test = test.ToLower();
                    if (characters.IsMatch(test))
                    {


                        if (tls.ContainsKey(test))
                        {
                            tls[test] = tls[test] + 1;
                        }
                        else
                        {
                            tls.Add(test, 1);
                        }
                    }


                }
                return tls;
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


            var threeLetterSequences = CreateDictionary(@"c:\work\training\TLS\SampleText.txt");

            Console.WriteLine("I can find all the three letter sequences that appear x times. How many times is x?");
            int valueToFind = Int32.Parse(Console.ReadLine());

            Console.WriteLine("These are all the TLSs which occur " + valueToFind + " times.");
         
            var whichTLSs = howManyTLSs(threeLetterSequences, valueToFind);

            foreach (string i in whichTLSs)
            {
                Console.WriteLine(i);
            }


            var keys = mostCommonTLS(threeLetterSequences);
            Console.WriteLine("These are the 10 most common TLSs");
            foreach(string i in keys)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();

        }
    }
}
