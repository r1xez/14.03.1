using System;
using System.Collections.Generic;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Translate text to Morse code");
            Console.WriteLine("2. Translate Morse code to text");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Enter text to convert to Morse Code:");
                string input = Console.ReadLine().ToUpper();
                string morseCode = ConvertToMorse(input);
                Console.WriteLine("Morse Code:");
                Console.WriteLine(morseCode);
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter Morse code to convert to text:");
                string morseInput = Console.ReadLine();
                string text = ConvertFromMorse(morseInput);
                Console.WriteLine("Text:");
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
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

        static string ConvertFromMorse(string morseInput)
        {
            Dictionary<string, char> morseToText = new Dictionary<string, char>()
            {
                { ".-", 'A' },
                { "-...", 'B' },
                { "-.-.", 'C' },
                { "-..", 'D' },
                { ".", 'E' },
                { "..-.", 'F' },
                { "--.", 'G' },
                { "....", 'H' },
                { "..", 'I' },
                { ".---", 'J' },
                { "-.-", 'K' },
                { ".-..", 'L' },
                { "--", 'M' },
                { "-.", 'N' },
                { "---", 'O' },
                { ".--.", 'P' },
                { "--.-", 'Q' },
                { ".-.", 'R' },
                { "...", 'S' },
                { "-", 'T' },
                { "..-", 'U' },
                { "...-", 'V' },
                { ".--", 'W' },
                { "-..-", 'X' },
                { "-.--", 'Y' },
                { "--..", 'Z' },
                { "-----", '0' },
                { ".----", '1' },
                { "..---", '2' },
                { "...--", '3' },
                { "....-", '4' },
                { ".....", '5' },
                { "-....", '6' },
                { "--...", '7' },
                { "---..", '8' },
                { "----.", '9' },
                { "/", ' ' }
            };

            string[] morseWords = morseInput.Split('/');
            string result = string.Empty;

            foreach (string word in morseWords)
            {
                string[] morseChars = word.Trim().Split(' ');
                foreach (string morseChar in morseChars)
                {
                    if (morseToText.ContainsKey(morseChar))
                    {
                        result += morseToText[morseChar];
                    }
                }
                result += " ";
            }

            return result.Trim();
        }
    }
}
