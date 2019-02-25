using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        //Северин Андрей

        /*Написать программу обмена значениями двух переменных:
            а) с использованием третьей переменной;
            б) *без использования третьей переменной.*/
        static void Main(string[] args)
        {
            string a;
            string b;

            Console.Write("Введите первую переменную A: ");
            a = Console.ReadLine();

            Console.Write("Введите первую переменную B: ");
            b = Console.ReadLine();
            //использование кортежей для обмена значений переменных. 
            (a, b) = (b, a);

            Console.WriteLine($"После обмена значение переменной A: {a}, значение переменной B: {b}");
            Console.WriteLine();

            int x = 10;
            int y = 15;
            Console.WriteLine($"Значение до обмена X={x}, Y={y}");
            Swap(ref x, ref y);
            Console.WriteLine($"Значение после обмена X={x}, Y={y}");
            Console.WriteLine();

            int x1 = 55;
            int y1 = 100;
            Console.WriteLine($"Значение до обмена X1={x1}, Y1={y1}");
            y1 = y1 + x1;
            x1 = y1 - x1;
            y1 = y1 - x1;
            Console.WriteLine($"Значение после обмена X1={x1}, Y1={y1}");
            Console.ReadKey();

        }

        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}
