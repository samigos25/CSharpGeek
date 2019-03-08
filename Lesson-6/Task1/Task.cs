using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    //Северин Андрей

    //1.	Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double).
    //Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

    public delegate double Fun(double x, double y);

    class Program
    {
        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("----- a ----- X ----- Y -----");
            while (a <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x,F(a, x));
                a += 1;
            }
            Console.WriteLine("---------------------");
        }

        static void Main()
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc a*x^2:");
            Table((a,x) => a * x * x, -2, 3 ,2);
            Console.WriteLine("Таблица функции MyFunc a*sin(x):");
            Table((a,x) => a * Math.Sin(x), -2, 3, 2);

            Console.ReadKey();
        }
    }

}
