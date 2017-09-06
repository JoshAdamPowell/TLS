using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;


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


            Console.WriteLine("There are " + tls["tra"] + " instances of tra");
            Console.WriteLine(tls["rat"]);
            Console.WriteLine(tls["pre"]);
            Console.ReadKey();

        }
    }
}
