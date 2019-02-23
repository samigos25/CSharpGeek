using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace Task3
{
    class Task3
    {
        //Северин Андрей
        //3.	С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех не чётных положительных чисел.

        //Не до конца понятно условие. Есть два варианта.
        //1. Нечетные это введенные с клавиатуры по порядковому номеру. То есть первое введенное, третье, пятое и тд.
        //   И если оно положительно то считать его
        //2. Нечетные это если пользователь ввел нечетное. То есть независимо от порядкового номера. Например 1, 11, 3 и тд

        static void Main(string[] args)
        {
            //Первый вариант. Все четные по порядковому номеру ввода

            long s = 0;
            int k = 1;
            Console.WriteLine("Сумма всех положительных четных чисел по порядковому номеру ввода");
            int a = Tools.ReadInt($"Введите число номер {k}: ");
            while (a != 0)
            {
                if (a > 0 && k % 2 == 0) s = s + a;
                k++;
                a = Tools.ReadInt($"Введите число номер {k}: ");
            }
            Console.WriteLine($"Сумма равна {s}");
            Console.ReadKey();

            //Второй вариант. Все четные по значению
            Console.WriteLine();
            s = 0;
            Console.WriteLine("Сумма всех положительных четных чисел по значению");
            a = Tools.ReadInt($"Введите число: ");
            while (a != 0)
            {
                if (a > 0 && a % 2 == 0) s = s + a;
                a = Tools.ReadInt($"Введите число: ");
            }
            Console.WriteLine($"Сумма равна {s}");
            Console.ReadKey();
        }
    }
}
