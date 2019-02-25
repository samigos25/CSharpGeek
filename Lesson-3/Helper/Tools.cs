using System;

namespace Helper
{
    public class Tools
    {
        /// <summary>
        /// Ввод от пользователя числа с плавающей точкой. Повторы до корректного ввода
        /// </summary>
        /// <param name="massage">сообщение для запроса</param>
        /// <returns></returns>
        public static double ReadDouble(string massage)
        {
            string temp;
            double result;
            Console.Write(massage);
            temp = Console.ReadLine();
            while (!Double.TryParse(temp, out result))
            {
                Console.Write("Некорректный ввод. " + massage);
                temp = Console.ReadLine();
            }
            return result;
        }

        /// <summary>
        /// Ввод от пользователя целого числа. Повторы до корректного ввода
        /// </summary>
        /// <param name="massage">сообщение для запроса</param>
        /// <returns></returns>
        public static int ReadInt(string massage)
        {
            string temp;
            int result;
            Console.Write(massage);
            temp = Console.ReadLine();
            while (!Int32.TryParse(temp, out result))
            {
                Console.Write("Некорректный ввод. " + massage);
                temp = Console.ReadLine();
            }

            return result;
        }

        /// <summary>
        /// Рекурсивный метод подсчета суммы цифр числа методички
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static long SumOfDigits(long a)                    // рекурсивный метод
        {
            if (a == 0)                                  // если a =0
                return 0;                              // возвращаем 0
            else return SumOfDigits(a / 10) + a % 10;   // иначе вызываем рекурсивно сами себя
        }
    }
}
