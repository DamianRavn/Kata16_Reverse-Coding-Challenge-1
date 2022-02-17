using System;
using System.Collections.Generic;
using System.Text;

namespace Kata16_Reverse_Coding_Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteOutCharacters("A4B5C2", "AAAABBBBBCC");
            WriteOutCharacters("C2F1E5", "CCFEEEEE");
            WriteOutCharacters("T4S2V2", "TTTTSSVV");
            WriteOutCharacters("A1B2C3D4", "ABBCCCDDDD");
            WriteOutCharacters("A10", "AAAAAAAAAA");
            WriteOutCharacters("A1000B50", "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
        }

        /// <summary>
        /// Write out full string from string shortcut
        /// </summary>
        /// <param name="characterNumberString">a string with character-number pair eg C4</param>
        /// <returns>a string where the number has been turned into the character eg CCCC</returns>
        static string WriteOutCharacters(string characterNumberString, string expected)
        {
            characterNumberString = characterNumberString.Trim();
            StringBuilder bob = new StringBuilder();
            Queue<char> charQ = new Queue<char>();
            Queue<int> numberQ = new Queue<int>();

            for (int i = 0; i < characterNumberString.Length; i++)
            {
                char c = characterNumberString[i];
                if (Char.IsLetter(c))
                {
                    StringBuilder numberBuilder = new StringBuilder();
                    for (int j = i+1; j < characterNumberString.Length; j++)
                    {
                        char n = characterNumberString[j];
                        if (Char.IsLetter(n))
                        {
                            i = j-1;
                            break;
                        }
                        numberBuilder.Append(n);
                    }
                    charQ.Enqueue(c);
                    numberQ.Enqueue(int.Parse(numberBuilder.ToString()));
                }
            }

            if (charQ.Count != numberQ.Count) throw new InvalidOperationException();

            while(charQ.Count != 0)
            {
                char c = charQ.Dequeue();
                int n = numberQ.Dequeue();

                for (int i = 0; i < n; i++)
                {
                    bob.Append(c);
                }
            }

            string actual = bob.ToString();
            Console.WriteLine($"expected: {expected}, actual: {actual}, is the same: {expected == actual}");
            return actual;
        }
    }
}
