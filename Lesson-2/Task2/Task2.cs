
using Helper;
using System;

namespace Task2
{
    //Северин Андрей
    //2.	Написать метод подсчета количества цифр числа.

    //number.ToString().Length - зачем отдельный метод для этого?
    //Написал методы подчета суммы цифр числа
    class Task2
    {
        static void Main()
        {
            int number = Tools.ReadInt("Введите число: ");
            Console.WriteLine("Количество цифр в числе {0} равно: {1}",number ,number.ToString().Length);
            Console.WriteLine($"Сумма цифр числа {number} равна (цикл While): {SumOfDigits(number)}");
            Console.WriteLine($"Сумма цифр числа {number} равна (Рекурсия из методички): {RecursiveSum(number)}");
            Console.WriteLine($"Сумма цифр числа {number} равна (Рекурсия): {SumOfDigits(0, number)}");
            Console.ReadKey();
        }

        /// <summary>
        /// Рекурсивный метод из методички
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static long RecursiveSum(long a)                    // рекурсивный метод
        {
            if (a == 0)                                  // если a =0
                return 0;                              // возвращаем 0
            else return RecursiveSum(a / 10) + a % 10;   // иначе вызываем рекурсивно сами себя
        }


        /// <summary>
        /// Рекурсивный метод подчета суммы цифр числа
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        static int SumOfDigits(int sum, int number)
        {
            if (number > 0)
            {
                sum += number % 10;
                return SumOfDigits(sum, number / 10);
            }
            return sum;
        }

        /// <summary>
        /// Сумма цифр целого числа. Цикл while
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static int SumOfDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int digit = number % 10;
                number /= 10;
                sum += digit;
            }

            return sum;
        }
    }
}
