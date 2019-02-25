using System;
using Helper;
namespace Task1
{
    //Северин Андрей
    //1.	Написать метод, возвращающий минимальное из трёх чисел.
    class Task1
    {
        static void Main()
        {
            int a = -60, b = -55, c = 11;
            Console.WriteLine($"Минимальное из трех чисел {a}, {b}, {c} будет : {Min3(a, b, c)}");

            a = Tools.ReadInt("Введите первое целое число: ");
            b = Tools.ReadInt("Введите второе целое число: ");
            c = Tools.ReadInt("Введите третье целое число: ");
            Console.WriteLine($"Минимальное из введенных чисел будет : {Min3(a, b, c)}");
            Console.ReadKey();
        }

        /// <summary>
        /// Возвращает минимальное из трех целых
        /// </summary>
        /// <returns></returns>
        static int Min3(int a, int b, int c)
        {
            if (a < b && a < c) return a;
            if (b < a && b < c) return b;
            return c;
        }

    }
}
