using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MyArrays;
namespace Task5
{
    class Task
    {
        //Северин Андрей

        //5.*а) Реализовать библиотеку с классом для работы с двумерным массивом.
        //      Реализовать конструктор, заполняющий массив случайными числами.
        //      Создать методы,
        //      которые возвращают сумму всех элементов массива,
        //      сумму всех элементов массива больше заданного,
        //      свойство, возвращающее минимальный элемент массива,
        //      свойство, возвращающее максимальный элемент массива,
        //      метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
        //  **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        //  ** в) Обработать возможные исключительные ситуации при работе с файлами

        static void Main(string[] args)
        {
            int size1 = 2;
            int size2 = 10;

            Console.WriteLine($"Создаем массив размерности {size1} на {size2} заполненный числами от -10 до 10");
            MyArrayTwoDim a = new MyArrayTwoDim(size1, size2, -10, 10);
            Console.WriteLine(a);
            Console.WriteLine($"Сумма всех элементов массива {a.Sum()}");
            Console.WriteLine($"Сумма элементов массива более 5 {a.Sum(o => o > 5)}");
            Console.WriteLine($"Сумма элементов массива которые равны 5 {a.Sum(o => o == 5)}");
            Console.WriteLine($"Минимальный элемент массива {a.Min}");
            Console.WriteLine($"максимальный элемент массива {a.Max}");
            a.PositionMax(out int rowMax, out int colMax);
            Console.WriteLine($"Максимальный элемент находится в позиции [{rowMax}, {colMax}]");
            size1 = 5;
            size2 = 7;
            string pathFile = "Array.txt";
            Console.WriteLine($"Создадим новый массив размерности {size1} на {size2} заполненный числами от -15 до 15\nЗапишем его в файл {pathFile}");
            MyArrayTwoDim b = new MyArrayTwoDim(size1, size2, -15, 15);
            Console.WriteLine(b);
            string secondPathFile = "ArrayNew.txt";
            Console.WriteLine($"Запишем новый массив в файл {secondPathFile}");
            b.ArrayToFile(secondPathFile);
            Console.WriteLine($"Запишем первый массив в файл {pathFile} \nЗатем считаем во второй массив файл {pathFile}");
            a.ArrayToFile(pathFile);
            b.ReadArrayFromFile(pathFile);
            Console.WriteLine("Второй массив теперь:");
            Console.WriteLine(b);
            Console.WriteLine($"Создадим третий массив из файла {secondPathFile}");
            MyArrayTwoDim c = new MyArrayTwoDim(secondPathFile);
            Console.WriteLine(c);

            Console.ReadKey();
        }
    }
}
