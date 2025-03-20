using System;
using System.Collections.Generic;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text to convert to Morse Code:");
            string input = Console.ReadLine().ToUpper();

            string morseCode = ConvertToMorse(input);

            Console.WriteLine("Morse Code:");
            Console.WriteLine(morseCode);
        }

        static string ConvertToMorse(string input)
        {
            Dictionary<char, string> morseAlphabet = new Dictionary<char, string>()
            {
                { 'A', ".-" },
                { 'B', "-..." },
                { 'C', "-.-." },
                { 'D', "-.." },
                { 'E', "." },
                { 'F', "..-." },
                { 'G', "--." },
                { 'H', "...." },
                { 'I', ".." },
                { 'J', ".---" },
                { 'K', "-.-" },
                { 'L', ".-.." },
                { 'M', "--" },
                { 'N', "-." },
                { 'O', "---" },
                { 'P', ".--." },
                { 'Q', "--.-" },
                { 'R', ".-." },
                { 'S', "..." },
                { 'T', "-" },
                { 'U', "..-" },
                { 'V', "...-" },
                { 'W', ".--" },
                { 'X', "-..-" },
                { 'Y', "-.--" },
                { 'Z', "--.." },
                { '0', "-----" },
                { '1', ".----" },
                { '2', "..---" },
                { '3', "...--" },
                { '4', "....-" },
                { '5', "....." },
                { '6', "-...." },
                { '7', "--..." },
                { '8', "---.." },
                { '9', "----." },
                { ' ', "/" }
            };

            string result = string.Empty;

            foreach (char c in input)
            {
                if (morseAlphabet.ContainsKey(c))
                {
                    result += morseAlphabet[c] + " ";
                }
            }

            return result.Trim();
        }
    }
}
