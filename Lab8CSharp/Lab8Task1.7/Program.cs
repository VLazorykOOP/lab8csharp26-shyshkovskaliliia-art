using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab8.Lab8Task1._7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            string filePath = "input.txt";
            StreamReader filein = new StreamReader(filePath);
            string text = filein.ReadToEnd();
            filein.Close();
            string pattern = @"\b(?:https?://|www\.)?[\w.-]+\.cv\.ua\b";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection matches = r.Matches(text);

            string outputFile = "cvua_sites.txt";
            StreamWriter fileout = new StreamWriter(outputFile);
            foreach (Match m in matches)
            {
                fileout.WriteLine(m.Value);
            }
            fileout.Close();

            Console.WriteLine($"Знайдено адрес web-сайтів домена cv.ua: {matches.Count}");
            Console.WriteLine($"Результати записано у файл: {outputFile}\n");

            Console.Write("Бажаєте замінити знайдені адреси в оригінальному тексті? (y/n): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "y")
            {
                Console.Write("Введіть нове значення для заміни (Enter — видалити): ");
                string replacement = Console.ReadLine();

                string newText = r.Replace(text, replacement);

                string modifiedFile = "modified_text.txt";
                StreamWriter modOut = new StreamWriter(modifiedFile);
                modOut.Write(newText);
                modOut.Close();

                Console.WriteLine($"\nЗмінений текст записано у файл: {modifiedFile}");
            }
            else
            {
                Console.WriteLine("Заміна не виконана. Оригінальний файл text.txt залишився без змін.");
            }

            Console.WriteLine("\nРобота завершена. Натисніть будь-яку клавішу...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
