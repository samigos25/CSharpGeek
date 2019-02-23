using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace Task4
{
    class Task5
    {
        //Северин Андрей
        //5.  а) Написать программу, которая запрашивает массу и рост человека, вычисляет
        //      его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
        //    б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

        //Начиная с C# 7.0 есть возможность указать диапазон в опереаторе switch
        //используя Оператор case и предложение when

        static void Main()
        {
            double weight = Tools.ReadDouble("Введите ваш вес в килограммах: ");
            int growth = Tools.ReadInt("Введите ваш рост в сантиметрах: ");
            double BMI = weight / Math.Pow( ((double)growth / 100.0), 2);
            double offset = 0;
            if (BMI <= 18.5) offset = 18.51 * Math.Pow(((double)growth / 100.0), 2) - weight;
            if (BMI > 25) offset = 25 * Math.Pow(((double)growth / 100.0), 2) - weight;




            Console.WriteLine($"Индекс массы вашего тела BMI равен: {BMI:F2}");
            Console.WriteLine("Состояние: ");
            switch (BMI)
            {
                case double n when (n <= 16):
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Выраженный дефицит массы тела");
                    Console.WriteLine($"Вам необходимо набрать {Math.Abs(offset):F2} килограмм");
                    break;
                case double n when ((n > 16) && (n <= 18.5)):
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Недостаточная (дефицит) масса тела");
                    Console.WriteLine($"Вам необходимо набрать {Math.Abs(offset):F2} килограмм");
                    break;
                case double n when ((n > 18.5) && (n <= 25)):
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Норма");
                    Console.WriteLine($"Вы в идеальной форме. Так держать");
                    break;
                case double n when ((n > 25) && (n <= 30)):
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Избыточная масса тела (предожирение)");
                    Console.WriteLine($"Вам необходимо сбросить {Math.Abs(offset):F2} килограмм");
                    break;
                case double n when ((n > 30) && (n <= 35)):
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ожирение");
                    Console.WriteLine($"Вам необходимо сбросить {Math.Abs(offset):F2} килограмм");
                    break;
                case double n when ((n > 35) && (n <= 40)):
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ожирение резкое");
                    Console.WriteLine($"Вам необходимо сбросить {Math.Abs(offset):F2} килограмм");
                    break;
                case double n when (n > 40):
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Очень резкое ожирение");
                    Console.WriteLine($"Вам необходимо сбросить {Math.Abs(offset):F2} килограмм");
                    break;
            }

            Console.ReadKey();
        }
    }
}
