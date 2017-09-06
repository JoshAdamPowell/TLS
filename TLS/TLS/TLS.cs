﻿using System;
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
            string input = File.ReadAllText(@"c:\work\training\TLS\SampleText.txt");
            int length = input.Length;
            Dictionary<string, int> tls = new Dictionary<string, int>();

            Regex characters = new Regex(@"\w{3}");

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

            Console.WriteLine("I can find all the three letter sequences that appear x times. How many times is x?");
            int valueToFind = Int32.Parse(Console.ReadLine());
            var keysToFind = tls.Where(x => x.Value == valueToFind).Select(x => x.Key).ToList();




            Console.WriteLine("There are " + tls["tra"] + " instances of tra");

            Console.WriteLine("These are all the TLSs which occur " + valueToFind + " times.");
            foreach (string i in keysToFind)
            {
                Console.WriteLine(i);
            }

            int mostCommonValue = 0;
            string mostCommonKey = "";

            foreach (KeyValuePair<string, int> kvp in tls)
            {
                if (kvp.Value > mostCommonValue)
                {
                    mostCommonKey = kvp.Key;
                    mostCommonValue = kvp.Value;
                }

            }
            Console.WriteLine("The most common TLS is " + mostCommonKey);



            Console.ReadKey();

        }
    }
}
