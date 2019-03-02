using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MyArrays;
using Task2;

namespace Task3
{
    //Северин Андрей

    //3.	а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив
    //определенного размера и заполняющий массив числами от начального значения с заданным шагом.
    //Создать свойство Sum, которое возвращает сумму элементов массива,
    //метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),
    //метод Multi, умножающий каждый элемент массива на определённое число,
    //свойство MaxCount, возвращающее количество максимальных элементов. 
    //б)** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки
    //е) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)

    class Task
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Создадим массив из 20 элементов начиная с 15 с шагом -3");
            MyArray b = new MyArray(20, 15, -3);
            b.Print();
            b.BubbleSort();
            b.Print("Отсортированный по возрастанию массив");
            Console.WriteLine();

            (b.Inverse()).Print("Новый массив с измененными знаками каждого элемента");
            Console.WriteLine("Создадим файл со 100 строками с числами от -10 до 10");
            StaticClass.CreateTextFileWithArray("data.txt", 100, minRange: -10, maxRange: 10);
            Console.WriteLine("Создадим массив на основе файл Data.txt");
            b = new MyArray("Data.txt");
            b.Print("Массив из файла");
            b.Multi(5);
            b.Print("Умножим каждый элемент массива на 5");
            Console.WriteLine($"Максимальный элемент в массиве {b.Max}, количество вхождений максимального элемента {b.MaxCount()}");
            b.BubbleSort();
            b.Print("Еще раз отсортируем массив");
            var elements = b.CreateDictionary();
            foreach (var element in elements)
            {
                Console.WriteLine($"Элемент {element.Key} содержится в массиве {element.Value} раз");
            }
            Console.ReadKey();
        }
    }
}
