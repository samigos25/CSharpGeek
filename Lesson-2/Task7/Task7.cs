using System;

namespace Task7
{
    class Task7
    {
        //  Северин Андрей
        //7.	a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
        //б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.

        static void Main(string[] args)
        {
            int a = 1;
            int b = 120;
            ShowNumbers(a, b);
            Console.WriteLine();
            Console.WriteLine($"Сумма чисел от {a} до {b} равна: {SumNumbers(a, b)}");
            Console.ReadKey();

        }

        /// <summary>
        /// Рекурсивный подсчет суммы чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int SumNumbers(int a, int b)
        {
            if (a == b) return b;
            else
            {
                int t = a + 1;
                return SumNumbers(t, b) + a;
            }
        }

        /// <summary>
        /// Рекурсивное отображение чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void ShowNumbers(int a, int b)
        {
            if (a > b) return;
            else
            {
                Console.WriteLine(a);
                ShowNumbers(++a, b);
            }
        }
    }
}
