using System;
using System.Text;

namespace Lab8
{
    internal class Menu
    {
        static void Main(string[] args)
        {
            // Налаштування кирилиці
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Головне меню Лабораторної роботи №8 ===");
                Console.WriteLine("1. Завдання 1.7 (Пошук сайтів cv.ua)");
                Console.WriteLine("2. Завдання 2.7 (Робота з англійськими словами)");
                Console.WriteLine("3. Завдання 3.22 (вилучення повторних літер)");
                Console.WriteLine("4. Завдання 4.3 (числа Фібоначчі у двійковий файл)");
                Console.WriteLine("5. Завдання 5 (робота з файловою системою)");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВаш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Lab8.Lab8Task1._7.Program.Main(new string[0]);
                        BreakToMenu();
                        break;
                    case "2":
                        Console.Clear();
                        Lab8.Lab8Task2._7.Program.Main(new string[0]);
                        BreakToMenu();
                        break;
                    case "3":
                        Lab8.Lab8Task3._22.Program.Execute();
                        BreakToMenu();
                        break;
                    case "4":
                        Lab8.Lab8Task4._3.Program.Execute();
                        BreakToMenu();
                        break;
                    case "5":
                        Lab8.Lab8Task5.Lab8Task5 task5 = new Lab8.Lab8Task5.Lab8Task5();
                        task5.Execute();
                        BreakToMenu();
                        break;
                    case "0":
                    case "": 
                        running = false;
                        Console.WriteLine("\nВихід з програми...");
                        break;
                    default:
                        Console.WriteLine("\nНевірний вибір! Спробуйте ще раз.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void BreakToMenu()
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в меню...");
            Console.ReadKey(true);
        }
    }
}
