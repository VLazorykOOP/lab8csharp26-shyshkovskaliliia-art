using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab8.Lab8Task3._22
{
    internal class Program
    {
        public static void Execute()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string filePath = "input3.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Помилка: Файл {filePath} не знайдено!");
                return;
            }

            string text = File.ReadAllText(filePath, Encoding.UTF8);

            Console.WriteLine("--- Оригінальний текст ---");
            Console.WriteLine(text);
            Console.WriteLine(new string('-', 25));

            string[] words = Regex.Split(text, @"(\s+|[^\w\u0400-\u04FF]+)");

            StringBuilder resultBuilder = new StringBuilder();

            foreach (string word in words)
            {
                if (Regex.IsMatch(word, @"[\w\u0400-\u04FF]"))
                {
                    resultBuilder.Append(RemoveDuplicateLetters(word));
                }
                else
                {
                    resultBuilder.Append(word); 
                }
            }

            string result = resultBuilder.ToString();

            Console.WriteLine("\n--- Текст після обробки ---");
            Console.WriteLine(result);
            Console.WriteLine(new string('-', 25));

            string outputFile = "output_3_22.txt";
            File.WriteAllText(outputFile, result, Encoding.UTF8);

            Console.WriteLine($"\nРезультат успішно записано у файл: {outputFile}");
            Console.WriteLine("Натисніть будь-яку клавішу, щоб повернутися в меню...");
            Console.ReadKey(true);
        }

        static string RemoveDuplicateLetters(string word)
        {
            if (string.IsNullOrEmpty(word)) return word;

            StringBuilder uniqueChars = new StringBuilder();
            string seenChars = "";

            foreach (char c in word)
            {
                char lowerC = char.ToLower(c);
                if (!seenChars.Contains(lowerC))
                {
                    uniqueChars.Append(c); 
                    seenChars += lowerC; 
                }
            }

            return uniqueChars.ToString();
        }
    }
}
