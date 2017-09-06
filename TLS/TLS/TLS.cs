using System;
using System.IO;
using System.Text;

namespace TLS
{
    class ThreeLetterSequences
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText(@"c:\work\training\TLS\SampleText.txt");
            int length = input.Length;
            int counter = 0;
            for (var i = 0; i < length; i++)
            {
               
                if ((input[i] == 't'|| input[i] == 'T') && (input[i+1] == 'r'|| input[i + 1] == 'R') && (input[i+2] == 'a'|| input[i + 2] == 'A'))
                {
                    counter = counter + 1;
                }
            }


            Console.WriteLine(counter);
            Console.ReadKey();

        }
    }
}
