using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TLS
{
    class ThreeLetterSequences
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText(@"c:\work\training\TLS\SampleText.txt");
            int length = input.Length;
            int counter = 0;
            Regex tra = new Regex("tra", RegexOptions.IgnoreCase);

            var matches = tra.Matches(input);
            counter = matches.Count;

            Console.WriteLine(counter);
            Console.ReadKey();

        }
    }
}
