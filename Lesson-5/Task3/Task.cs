using System;
using System.Linq;

namespace Task3
{
    class Task
    {
        //Северин Андрей

    //    3.	*Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
    //Например:
    //badc являются перестановкой abcd.

        static void Main(string[] args)
        {
            Console.Write("Введите первую строку: ");
            string s1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string s2 = Console.ReadLine();
            Console.WriteLine(Transposition(s1,s2));
            Console.ReadKey();

        }

        static bool Transposition(string s1, string s2)
        {
            var g1 = s1.OrderBy(o => o).GroupBy(o => o).ToDictionary(x => x.Key, x => x.Count());
            var g2 = s2.OrderBy(o => o).GroupBy(o => o).ToDictionary(x => x.Key, x => x.Count());
            return g1.SequenceEqual(g2);
        }

    }
}
