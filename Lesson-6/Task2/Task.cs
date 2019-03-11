using System;
using System.Collections.Generic;
using System.IO;
using Helper;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //Северин Андрей

    //2.	Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    //а) Сделать меню с различными функциями и представить пользователю выбор,
    //  для какой функции и на каком отрезке находить минимум.Использовать массив(или список) делегатов, в котором хранятся различные функции.
    //б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.
    //  Пусть она возвращает минимум через параметр(с использованием модификатора out). 


    delegate double func(double x);
    class Task
    {
       
        public static void SaveFunc(string fileName, double a, double b, double h, func rFunc)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    double x = a;
                    while (x <= b)
                    {
                        bw.Write(rFunc(x));
                        x += h;// x=x+h;
                    }
                }
            }
        }

        public static List<double> Load(string fileName, out double min)
        {
            List<double> list = new List<double>();
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader bw = new BinaryReader(fs))
                {
                    min = double.MaxValue;
                    double d;
                    for (int i = 0; i < fs.Length / sizeof(double); i++)
                    {
                        // Считываем значение и переходим к следующему
                        d = bw.ReadDouble();
                        list.Add(d);
                        if (d < min) min = d;
                    }
                }
            }
            return list;
        }

        public static List<func> arrFunc = new List<func>()
        {
            o => Math.Sin(o),
            o => o * o * o,
            o => o * o,
            o => o * o * o + o * o - 10 * o + 18,
            o => o * o - 50 * o + 10
        };

        static void Main(string[] args)
        {
            double min;
            double a, b;
            int funcNumber;
            do
            {
                ShowMenu();
                funcNumber = Tools.ReadInt("Введите номер фнкции (0 для выхода): ", o => o >= 0 && o <= arrFunc.Count);
                if (funcNumber != 0)
                {
                    Console.WriteLine("необходимо ввести интервал функции от a до b");
                    a = Tools.ReadDouble("Введите a: ");
                    b = Tools.ReadDouble("Введите b: ");
                    SaveFunc("data.bin", a, b, 0.5, arrFunc[funcNumber - 1]);
                    Load("data.bin", out min);
                    Console.WriteLine($"Минимальной функции {funcNumber}: {min}");
                    Console.ReadKey();
                }
            } while (funcNumber != 0);
        }

        static void ShowMenu()
        {
            Console.WriteLine("Доступные фнкции: \n" +
                              "1: F(x) = Sin(x)\n" +
                              "2: F(x) = x^3\n" +
                              "3: F(x) = X^2\n" +
                              "4: F(x) = x^3 + x^2 - 10x + 18\n" +
                              "5: F(x) = x^2 - 50x + 10");
        }
    }

}
