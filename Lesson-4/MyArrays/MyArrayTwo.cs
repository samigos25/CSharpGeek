using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace MyArrays
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
    public class MyArrayTwoDim
    {
        private int[,] _a;

        /// <summary>
        /// Создает двумерный массив размерности [n, n] заполненный заданным числом
        /// </summary>
        /// <param name="n"></param>
        /// <param name="number"></param>
        public MyArrayTwoDim(int n, int number)
        {
            _a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    _a[i, j] = number;
        }
        /// <summary>
        /// Создает двумерный массив размерности [n, n] заполненный случайными числами от min до max
        /// </summary>
        /// <param name="n"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public MyArrayTwoDim(int n, int min, int max):this (n,n,min, max)
        {
        }
        /// <summary>
        /// Создает двумерный массив размерности [row, col] заполненный случайными числами от min до max
        /// </summary>
        /// <param name="n"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public MyArrayTwoDim(int row, int col, int min, int max)
        {
            _a = new int[row, col];
            Random rnd = new Random();
            for (int i = 0; i < row; i++)
            for (int j = 0; j < col; j++)
                _a[i, j] = rnd.Next(min, max+1);
        }

        public MyArrayTwoDim(string pathFile)
        {
            ReadArrayFromFile(pathFile);
        }

        public int Sum() => Sum(o => true);
        /// <summary>
        /// Возвращает сумму элементов массива которые удовлетворяют условию заданному Func<int, bool>
        /// </summary>
        /// <param name="rFunc"></param>
        /// <returns></returns>
        public int Sum(Func<int, bool> rFunc) => _a.Cast<int>().Where(rFunc).Sum();

        public bool ReadArrayFromFile(string pathToFile)
        {
            List<List<int>> list = new List<List<int>>();
            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] oneDimention = sr.ReadLine().Split(new char[] {';'},StringSplitOptions.RemoveEmptyEntries);
                        List<int> tempList = new List<int>();
                        foreach (string s in oneDimention)
                        {
                            
                            if (Int32.TryParse(s, out int temp))
                                tempList.Add(temp);
                        }
                        if (tempList.Count > 0) list.Add(tempList);
                    }
                }

                int size1 = list.Count;
                int size2 = list[0].Count;
                _a = new int[size1,size2];
                for (int i = 0; i < size1; i++)
                {
                    for (int j = 0; j < size2; j++)
                    {
                        _a[i, j] = list[i][j];
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    
        public bool ArrayToFile(string pathToFile = "ArrayTwoDim.txt")
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(pathToFile))
                {
                    sw.WriteLine(ToString(";"));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public void PositionMax(out int Row, out int Col)
        {
            Col = 0;
            Row = 0;
            int max = Max;
            for (int row = 0; row < _a.GetLength(0); row++)
            {
                for (int col = 0; col < _a.GetLength(1); col++)
                {
                    if (_a[row, col] == max)
                    {
                        Col = col;
                        Row = row;
                        return;
                    }
                }
            }
        }
        public int Min
        {
            get
            {
                return _a.Cast<int>().Min();
            }
        }
        public int Max
        {
            get
            {
                return _a.Cast<int>().Max();
            }
        }
        // Свойство - подсчет количества положительных
        public int CountPositive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _a.GetLength(0); i++)
                    for (int j = 0; j < _a.GetLength(1); j++)
                        if (_a[i, j] > 0) count++;
                return count;
            }
        }
        // Свойство - подсчет среднего арифметического
        public double Average
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < _a.GetLength(0); i++)
                    for (int j = 0; j < _a.GetLength(1); j++)
                        sum += _a[i, j];
                return sum / _a.GetLength(0) / _a.GetLength(1);
            }

        }
        // Метод, который возвращает массив в виде строки
        private string ToString(string Delimetr)
        {
            string s = "";
            for (int i = 0; i < _a.GetLength(0); i++)
            {
                for (int j = 0; j < _a.GetLength(1); j++)
                {

                    s += _a[i, j] + Delimetr;
                }
                s += "\n"; // Переход на новую строчку
            }
            return s;
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < _a.GetLength(0); i++)
            {
                for (int j = 0; j < _a.GetLength(1); j++)
                {

                    s += _a[i, j].ToString().PadLeft(5);
                }
                    
                s += "\n"; // Переход на новую строчку
            }
            return s;
        }
    }

}
