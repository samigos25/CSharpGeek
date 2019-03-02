using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Task2;

namespace MyArrays
{
    //Северин Андрей

    //3.	а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив
    //определенного размера и заполняющий массив числами от начального значения с заданным шагом.
    //Создать свойство Sum, которое возвращает сумму элементов массива,
    //метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),
    //метод Multi, умножающий каждый элемент массива на определённое число,
    //свойство MaxCount, возвращающее количество максимальных элементов. 
    public class MyArray
    {
        int[] a;

        /// <summary>
        /// Создает массив заданного размера и заполняющий массив числами от начального значения с заданным шагом
        /// </summary>
        /// <param name="amount">количество элементов в массиве</param>
        /// <param name="start">начальное значение</param>
        /// <param name="step">шаг элементов</param>
        public MyArray(int amount, int start, int step)
        {
            a = Enumerable.Range(start, amount).Select((o, i) => new {item = o, index = i})
                .Select(o => o.index * step + start).ToArray();
        }

        /// <summary>
        /// Создает массив из файла filename
        /// </summary>
        /// <param name="filename">имя файла</param>

        public MyArray(int[] arr)
        {
            a = arr;
        }
        public MyArray() { }
        public MyArray(string filename)
        {
            a = StaticClass.ReadArrayFromFile(filename);
        }

        /// <summary>
        /// возвращает новый массив с измененными знаками у всех элементов массива
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public MyArray Inverse()
        {

            return new MyArray() {a = a.Select(o => -o).ToArray()};

        }
    
        /// <summary>
        /// возвращает количество максимальных элементов
        /// </summary>
        /// <returns></returns>
        public int MaxCount()
        {
            return a.Count(o => o == a.Max());
        }

        /// <summary>
        /// умножает каждый элемент массива на заданное число,
        /// </summary>
        /// <param name="number"></param>
        public void Multi(int number)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] *= number;
            }
        }
        public int Length
        {
            get
            {
                return a.Length;
            }
        }
        public long Sum
        {
            get { return a.Sum(); }
        }
        public int Max
        {
            get
            {
                //  Находим максимальный элемент
                return a.Max();
            }
        }
        public int Min
        {
            get
            {
                //  Находим минимальный элемент
                return a.Min();
            }
        }
        public void BubbleSort()
        {
            //  Сортируем методом пузырька
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length - 1; j++)
                    if (a[j] > a[j + 1])//Сравниваем соседние элементы
                    {
                        //  Обмениваем элементы местами
                        int t = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = t;
                    }
        }
        public void Print()
        {
            foreach (int el in a)
                Console.Write("{0,4}", el);
        }
        public void Print(string msg)
        {
            Console.WriteLine(msg);
            Print();
        }

        /// <summary>
        /// Возвращает Dictionary&lt;int, int&gt; где ключем является эелемент массива значением количество его повторов в массиве
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, int> CreateDictionary()
        {
            return a.Distinct().ToDictionary(key => key, value => a.Where(o => o == value).Count());
        }
         
        public int this[int i]
        {
            get { return a[i]; }
            set { a[i] = value; }
        }

    }
}
