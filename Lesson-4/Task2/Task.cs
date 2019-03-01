using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Task
    {
        //Северин Андрей
        //2.	Реализуйте задачу 1 в виде статического класса StaticClass;
        //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        //б) *Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
        //в)**Добавьте обработку ситуации отсутствия файла на диске.

        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            int amount = 20;
            int minRange = -10000;
            int maxRange = 10000;
            int delimetr = 3;
            string pathfile = @"Array.txt";

            Console.WriteLine($"нижняя граница чисел {minRange}, верхняя {maxRange}");
            Console.WriteLine($"Создаем массив случайных целых чисел размера {amount}");
            int[] numbers = StaticClass.GenerateRandomArray(amount,minRange, maxRange);
            StaticClass.PrintArray(", ", 8, numbers);

            amount = 40;
            Console.WriteLine($"\nСоздаем файл с количеством строк {amount}, в каждой строке случайное число\n");
            if (StaticClass.CreateTextFileWithArray(pathfile, amount, minRange, maxRange))
            {
                Console.WriteLine($"Создан файл {pathfile} содержащий {amount} строк");
            }

            Console.WriteLine($"Читаем файл {pathfile} и на его основе создаем массив\n");
            numbers = StaticClass.ReadArrayFromFile(pathfile);
            StaticClass.PrintArray(", ", 8, numbers);
            Console.WriteLine($"количество пар элементов массива, в которых только одно число делится на {delimetr}: {StaticClass.FindPairInArray(numbers,delimetr)}");

            Console.WriteLine($"Читаем файл {pathfile + "f"} и на его основе создаем массив\n");
            numbers = StaticClass.ReadArrayFromFile(pathfile + "f");
            StaticClass.PrintArray(", ", 8, numbers);
            Console.WriteLine($"количество пар элементов массива, в которых только одно число делится на {delimetr}: {StaticClass.FindPairInArray(numbers, delimetr)}");


            Console.ReadKey();
        }

    }
}
