using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    class Program
    {
        //Северин Андрей

        /*Написать
            программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
        а) используя склеивание;
        б) используя форматированный вывод;
        в) используя вывод со знаком $.
        Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h* h); где m — масса тела в килограммах, h — рост в метрах.*/




        static void Main(string[] args)
        {
            string FirstName;
            string SecondName;
            double Weight;
            double Growth;
            int Age;
            string temp;
            Console.WriteLine("Здравствуйте");
            Console.Write("Введите пожалуйста ваше имя: ");
            SecondName = Console.ReadLine();

            Console.Write("Введите пожалуйста вашу фамилию: ");
            FirstName = Console.ReadLine();

            Console.Write("Введите ваш Возраст: ");
            temp = Console.ReadLine();
            while (!Int32.TryParse(temp, out Age))
            {
                Console.Write("Некорректный ввод. Введите ваш Возраст: ");
                temp = Console.ReadLine();
            }

            Console.Write("Введите ваш Рост (в сантиметрах): ");
            temp = Console.ReadLine();
            while (!Double.TryParse(temp, out Growth))
            {
                Console.Write("Некорректный ввод. Введите ваш Рост (в сантиметрах): ");
                temp = Console.ReadLine();
            }

            Console.Write("Введите ваш Вес (в килограммах): ");
            temp = Console.ReadLine();
            while (!Double.TryParse(temp, out Weight))
            {
                Console.Write("Некорректный ввод. Введите ваш Вес  (в килограммах): ");
                temp = Console.ReadLine();
            }

            Console.WriteLine("Еще раз здавствуйте " + SecondName + " " + FirstName);
            Console.WriteLine($"Ваш рост {Growth:F2} сантиметров при весе {Weight:N} килограмм в возрасте {Age:G} лет");
            Console.WriteLine("Ваш индекс массы тела ИМТ равен: {0 :F2}", Weight / (Growth / 100 * Growth / 100));
            Console.ReadKey();
        }
    }
}

