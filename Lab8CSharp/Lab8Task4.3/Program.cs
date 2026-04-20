using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab8.Lab8Task4._3
{
    internal class Program
    {
        public static void Execute()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            FileStream f = new FileStream("fib.dat", FileMode.Create);
            BinaryWriter fout = new BinaryWriter(f);

            long a = 0; 
            long b = 1; 

            if (n >= 1)
            {
                fout.Write(a);
            }
            if (n >= 2)
            {
                fout.Write(b);
            }
            for (int i = 3; i <= n; i++)
            {
                long c = a + b;
                fout.Write(c);
                a = b;
                b = c;
            }
            fout.Close();

            f = new FileStream("fib.dat", FileMode.Open);
            BinaryReader fin = new BinaryReader(f);
            long m = f.Length; 

            Console.Write("\nКомпоненти файлу з порядковим номером, не кратним 3: ");

            for (long i = 0; i < m; i += 8)
            {
                long elementNumber = i / 8 + 1;
                if (elementNumber % 3 != 0)
                {
                    f.Seek(i, SeekOrigin.Begin);
                    long value = fin.ReadInt64();
                    Console.Write("{0} ", value);
                }
            }

            fin.Close();
            f.Close();

            Console.WriteLine("\n\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}
