using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace Task6
{
    class Task6
    {
        static void Main()
        {
            //Северин Андрей
            //6.  * Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
            //«Хорошим» называется число, которое делится на сумму своих цифр.
            //Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
            
            
            
            //Решение из интернета. Красота
            //var res = Enumerable.Range(1, 1000000)
            //  .Select(n => n.ToString().Select(c => (int)char.GetNumericValue(c)))
            //  .Select(n => n.Sum())
            //  .Where((n, i) => (i + 1) % n == 0)
            //  .Count();


            DateTime startTime = DateTime.Now;
            int startNumber = 1;
            int endNumber = 1_000_000;
            int count = 0;
            for (int i = startNumber; i <= endNumber; i++)
            {
                if (isGood(i)) count++;
            }

            Console.WriteLine($"Количество хороших чисел в диапазоне от {startNumber} до {endNumber} равно: {count}");
            Console.WriteLine($"Время выполнения программы составило {((TimeSpan)(DateTime.Now - startTime)).Milliseconds} милисекунд");
            Console.ReadKey();
        }

        static bool isGood(int number)
        {
            return (number % Tools.SumOfDigits(number) == 0) ? true : false;
        }
    }
}
