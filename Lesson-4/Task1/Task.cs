using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task
    {
        //Северин Андрей
        //1.	Дан  целочисленный  массив  из 20 элементов.
        //Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно.
        //Заполнить случайными числами.  Написать программу,
        //позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3.
        //В данной задаче под парой подразумевается два подряд идущих элемента массива.
        //Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
        static void Main(string[] args)
        {
            OneMore(20, -10000, 10000);
            OneMore();
            Console.ReadKey();


        }

        static void OneMore(int amount = 10, int minRange = -10, int maxRange = 10) { 
            Random rnd = new Random();
            int[] numbers = new int[amount];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(minRange, maxRange);
            }

            int count = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] % 3 != 0 && numbers[i] % 3 == 0) count++;
                if (numbers[i - 1] % 3 == 0 && numbers[i] % 3 != 0) count++;
            }

            Console.WriteLine("Дан массив: ");
            for (int i = 0; i < (numbers.Length/2); i++)
            {
                Console.Write($"{numbers[i], 5}, ");
            }
            Console.WriteLine();
            for (int i = (numbers.Length / 2); i < numbers.Length - 1; i++)
            {
                Console.Write($"{numbers[i],5}, ");
            }
            Console.WriteLine($"{numbers.Last(),5}\n");
            Console.WriteLine("количество пар элементов массива, в которых только одно число делится на 3: {0}", count);
        }
    }
}
