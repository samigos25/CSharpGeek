using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace Task2
{
    //Северин Андрей
    //2.	а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке).
    //Требуется подсчитать сумму всех нечётных положительных чисел.
    //Сами числа и сумму вывести на экран, используя tryParse. 

    //!! Как это вывести на экран используя TryParse??? 
    class Task2
    {
        //Не до конца понятно условие. Есть два варианта.
        //1. Нечетные это введенные с клавиатуры по порядковому номеру. То есть первое введенное, третье, пятое и тд.
        //   И если оно положительно то считать его
        //2. Нечетные это если пользователь ввел нечетное. То есть независимо от порядкового номера. Например 1, 11, 3 и тд

        static void Main(string[] args)
        {
            //Первый вариант. Все нечетные по порядковому номеру ввода
            List<int> numbers = new List<int>();
            int k = 1;
            Console.WriteLine("Сумма всех положительных нечетных чисел по порядковому номеру ввода");
            int a = Tools.ReadInt($"Введите число номер {k}: ");
            while (a != 0)
            {
                if (a > 0 && k % 2 != 0) numbers.Add(a);
                k++;
                a = Tools.ReadInt($"Введите число номер {k}: ");
            }

            Console.WriteLine("Введенные нечетные по порядковому номеру числа: ");
            foreach (var number in numbers.Take(numbers.Count - 1))
            {
                Console.Write($"{number}, ");
            }
            Console.WriteLine(numbers.LastOrDefault());
            Console.WriteLine($"Их сумма равна {numbers.Sum()}");
            Console.ReadKey();

            //Второй вариант. Все четные по значению
            Console.WriteLine();
            Console.WriteLine("Сумма всех положительных нечетных чисел по значению");
            a = Tools.ReadInt($"Введите число: ");
            while (a != 0)
            {
                if (a > 0 && a % 2 != 0) numbers.Add(a);
                a = Tools.ReadInt($"Введите число: ");
            }

            Console.WriteLine("Введенные нечетные положительные числа: ");
            foreach (var number in numbers.Take(numbers.Count - 1))
            {
                Console.Write($"{number}, ");
            }
            Console.WriteLine(numbers.LastOrDefault());
            Console.WriteLine($"Их сумма равна {numbers.Sum()}");
            Console.ReadKey();
        }
    }
}
