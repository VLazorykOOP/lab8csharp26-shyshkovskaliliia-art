using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab8.Lab8Task2._7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            string filePath = "input1.txt";
            StreamReader filein = new StreamReader(filePath);
            string text = filein.ReadToEnd();
            filein.Close();

            Console.WriteLine("Оригінальний текст:");
            Console.WriteLine(text);
            Console.WriteLine();

            string pattern = @"\b[a-zA-Z]+\b";
            Regex r = new Regex(pattern);

            string newText = r.Replace(text, "...");

            Console.WriteLine("Текст після заміни англійських слів на три крапки:");
            Console.WriteLine(newText);
            Console.WriteLine();

            string outputFile = "output_2_7.txt";
            StreamWriter fileout = new StreamWriter(outputFile);
            fileout.Write(newText);
            fileout.Close();

            Console.WriteLine($"Результат записано у файл: {outputFile}");

            Console.WriteLine("\nРобота завершена. Натисніть будь-яку клавішу...");
            Console.ReadLine();
        }
    }
}
