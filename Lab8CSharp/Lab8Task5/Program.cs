using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab8.Lab8Task5
{
    internal class Lab8Task5
    {
        private const string StudentName = "Shyshkovska"; // <-- ЗАМІНИТИ

        private readonly string _folder1;
        private readonly string _folder2;
        private readonly string _folderAll;

        public Lab8Task5()
        {
            string baseDir = @"d:\temp";
            _folder1 = Path.Combine(baseDir, StudentName + "1");
            _folder2 = Path.Combine(baseDir, StudentName + "2");
            _folderAll = Path.Combine(baseDir, "ALL");
        }

        public void Execute()
        {
            Console.WriteLine("=== Lab8 Task5 ===\n");

            Step1_CreateDirectories();
            Step2_CreateTextFiles();
            Step3_CreateCombinedFile();
            Step4_PrintFileInfo();
            Step5_MoveFile();
            Step6_CopyFile();
            Step7_RenameAndDelete();
            Step8_PrintAllFolderInfo();

            Console.WriteLine("\nГотово! Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }

        private void Step1_CreateDirectories()
        {
            Console.WriteLine("── Крок 1: Створення папок ──");

            Directory.CreateDirectory(_folder1);
            Console.WriteLine($"  Створено: {_folder1}");

            Directory.CreateDirectory(_folder2);
            Console.WriteLine($"  Створено: {_folder2}\n");
        }

        private void Step2_CreateTextFiles()
        {
            Console.WriteLine("── Крок 2: Запис t1.txt та t2.txt ──");

            string t1Path = Path.Combine(_folder1, "t1.txt");
            string t2Path = Path.Combine(_folder1, "t2.txt");

            File.WriteAllText(t1Path,
                "Шевченко Степан Іванович, 2001 року народження, " +
                "місце проживання м. Суми",
                Encoding.UTF8);

            File.WriteAllText(t2Path,
                "Комар Сергій Федорович, 2000 року народження, " +
                "місце проживання м. Київ",
                Encoding.UTF8);

            Console.WriteLine($"  Записано: {t1Path}");
            Console.WriteLine($"  Записано: {t2Path}\n");
        }

        private void Step3_CreateCombinedFile()
        {
            Console.WriteLine("── Крок 3: Створення t3.txt (t1 + t2) ──");

            string t1Path = Path.Combine(_folder1, "t1.txt");
            string t2Path = Path.Combine(_folder1, "t2.txt");
            string t3Path = Path.Combine(_folder2, "t3.txt");

            using StreamWriter sw = new StreamWriter(t3Path, false, Encoding.UTF8);
            using (StreamReader sr1 = new StreamReader(t1Path, Encoding.UTF8))
                sw.WriteLine(sr1.ReadToEnd());
            using (StreamReader sr2 = new StreamReader(t2Path, Encoding.UTF8))
                sw.WriteLine(sr2.ReadToEnd());

            Console.WriteLine($"  Записано: {t3Path}\n");
        }

        private void Step4_PrintFileInfo()
        {
            Console.WriteLine("── Крок 4: Інформація про файли ──");

            string[] paths =
            {
                Path.Combine(_folder1, "t1.txt"),
                Path.Combine(_folder1, "t2.txt"),
                Path.Combine(_folder2, "t3.txt")
            };

            foreach (string path in paths)
                PrintFileDetails(new FileInfo(path));

            Console.WriteLine();
        }

        private void Step5_MoveFile()
        {
            Console.WriteLine("── Крок 5: Переміщення t2.txt у Student2 ──");

            string src = Path.Combine(_folder1, "t2.txt");
            string dest = Path.Combine(_folder2, "t2.txt");

            File.Move(src, dest);
            Console.WriteLine($"  {src}  →  {dest}\n");
        }

        private void Step6_CopyFile()
        {
            Console.WriteLine("── Крок 6: Копіювання t1.txt у Student2 ──");

            string src = Path.Combine(_folder1, "t1.txt");
            string dest = Path.Combine(_folder2, "t1.txt");

            File.Copy(src, dest, overwrite: true);
            Console.WriteLine($"  {src}  →  {dest}\n");
        }

        private void Step7_RenameAndDelete()
        {
            Console.WriteLine("── Крок 7: Перейменування та видалення ──");

            if (Directory.Exists(_folderAll))
                Directory.Delete(_folderAll, recursive: true);

            Directory.Move(_folder2, _folderAll);
            Console.WriteLine($"  Перейменовано: {_folder2}  →  {_folderAll}");

            Directory.Delete(_folder1, recursive: true);
            Console.WriteLine($"  Видалено:      {_folder1}\n");
        }
        private void Step8_PrintAllFolderInfo()
        {
            Console.WriteLine("── Крок 8: Повна інформація про папку ALL ──");

            DirectoryInfo dir = new DirectoryInfo(_folderAll);
            Console.WriteLine($"  Папка : {dir.FullName}");
            Console.WriteLine($"  Дата  : {dir.CreationTime:dd.MM.yyyy HH:mm:ss}\n");

            foreach (FileInfo fi in dir.GetFiles())
                PrintFileDetails(fi);
        }

        private static void PrintFileDetails(FileInfo fi)
        {
            Console.WriteLine($"  ┌─ {fi.Name}");
            Console.WriteLine($"  │  Повний шлях   : {fi.FullName}");
            Console.WriteLine($"  │  Розмір        : {fi.Length} байт");
            Console.WriteLine($"  │  Розширення    : {fi.Extension}");
            Console.WriteLine($"  │  Дата створення: {fi.CreationTime:dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"  │  Остання зміна : {fi.LastWriteTime:dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"  └─ Атрибути      : {fi.Attributes}\n");
        }
    }
}

