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


            List<int> Yposition = new List<int>();
            DateTime now = DateTime.Now;
            List<long> list = new List<long>();
            int startNumber = 1;
            int endNumber = 100_000_000;
            int count = 0;
            long digitSum = 0;
            long Xposition = 0;
            int ZeroCount = 1;

            Yposition = Enumerable.Repeat(0, 10).ToList();

            for (long i = startNumber; i <= endNumber; i++)
            {

                digitSum = i % 10 == 0 ? Tools.SumOfDigits(i) : digitSum + 1;
                if (i % digitSum == 0)
                {
                    count++;
                    Xposition = i % 10;
                    //if (Xposition != 0)
                    //{
                    //    Console.SetCursorPosition((int)Xposition * 6, Yposition[(int)Xposition]++);
                    //    Console.WriteLine(i);
                    //}
                    
                    
                }
            }
            Console.WriteLine($"Количество хороших чисел в диапазоне от {startNumber} до {endNumber:N0} равно: {count}");
            Console.WriteLine($"Время выполнения программы составило {(DateTime.Now - now)}");
            count = 0;
            now = DateTime.Now;
            for (int i = startNumber; i <= endNumber; i++)
            {
                if (IsGood(i))
                {
                    count++;
                }

            }

            Console.WriteLine($"Количество хороших чисел в диапазоне от {startNumber} до {endNumber:N0} равно: {count}");
            Console.WriteLine($"Время выполнения программы составило {(DateTime.Now - now)}");
            Console.ReadKey();
        }


        static bool IsGood(int number)
        {
            return (number % Tools.SumOfDigits(number) == 0) ? true : false;
        }
    }
}
