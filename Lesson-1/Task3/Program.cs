using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        //Северин Андрей

        /*а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле
                r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
          б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.*/
        static void Main(string[] args)
        {
            double x1, x2, y1, y2;
            string temp;

            Console.Write("Введите X1: ");
            temp = Console.ReadLine();
            while (!Double.TryParse(temp, out x1))
            {
                Console.Write("Некорректный ввод. Введите X1: ");
                temp = Console.ReadLine();
            }

            Console.Write("Введите Y1: ");
            temp = Console.ReadLine();
            while (!Double.TryParse(temp, out y1))
            {
                Console.Write("Некорректный ввод. Введите Y1: ");
                temp = Console.ReadLine();
            }

            Console.Write("Введите X2: ");
            temp = Console.ReadLine();
            while (!Double.TryParse(temp, out x2))
            {
                Console.Write("Некорректный ввод. Введите X2: ");
                temp = Console.ReadLine();
            }

            Console.Write("Введите Y2: ");
            temp = Console.ReadLine();
            while (!Double.TryParse(temp, out y2))
            {
                Console.Write("Некорректный ввод. Введите Y2: ");
                temp = Console.ReadLine();
            }

            Console.WriteLine($"Расстояние между двумя точками составляет {DistanceTwoPoints(x1, y1, x2, y2):F2}");
            Console.ReadKey();
        }

        static double DistanceTwoPoints(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

    }
}
