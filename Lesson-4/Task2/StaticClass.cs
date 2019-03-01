using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //2.	Реализуйте задачу 1 в виде статического класса StaticClass;
    //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
    //б) *Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
    //в)**Добавьте обработку ситуации отсутствия файла на диске.
    static class StaticClass
    {
        private static Random rnd = new Random();

        /// <summary>
        /// Возвращает масси целых чисел полученных из файла
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <returns></returns>
        public static int[] ReadArrayFromFile(string pathToFile = "Array.txt")
        {
            int temp;
            List<int> list = new List<int>();
            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    while (!sr.EndOfStream)
                    {
                        Int32.TryParse(sr.ReadLine(), out temp);
                        list.Add(temp);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return list.ToArray();
        } 
        
        /// <summary>
        /// Записывает массив целых чисел в файл. Каждое число в новой строке
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="pathToFile"></param>
        /// <returns></returns>
        public static bool WriteArrayToFile(int[] arr, string pathToFile = "Array.txt")
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(pathToFile))
                {
                    arr.ToList().ForEach(o => sw.WriteLine(o));
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

        /// <summary>
        /// Возвращает одномерный массив заполненный случайными числами
        /// </summary>
        /// <param name="Size">Количество элементов в массиве</param>
        /// <param name="minRange">Нижний предел значеий в массиве</param>
        /// <param name="maxRange">Верхний предел значений в массиве</param>
        /// <returns></returns>
        public static int[] GenerateRandomArray(int Size = 20, int minRange = -10000, int maxRange = 10000)
        {
            
            return Enumerable.Repeat(0, Size).Select(o => rnd.Next(minRange, maxRange)).ToArray();
        }

        /// <summary>
        /// Создает файл заполненный случайными числами. Каждое число в новой строке.
        /// Перезаписывает или если файл не существует - создает новый.
        /// </summary>
        /// <param name="pathToFile">Путь до создаваемого файла файла</param>
        /// <param name="linesCount">Количество строк в файле</param>
        /// <param name="minRange">Нижний предел значеий</param>
        /// <param name="maxRange">Верхний предел значений</param>
        /// <exception cref="safew"></exception>
        public static bool CreateTextFileWithArray(string pathToFile = "Array.txt", int linesCount = 20, int minRange = -10000, int maxRange = 10000)
        {
            List<int> arr = GenerateRandomArray(linesCount, minRange, maxRange).ToList();
            return WriteArrayToFile(arr.ToArray(),pathToFile);
        }

        /// <summary>
        /// Возвращает количество пар элементов массива, в которых только одно число делится на заданное
        /// </summary>
        /// <param name="numbers">массив</param>
        /// <param name="delimetr">Делитель</param>
        /// <returns></returns>
        public static int FindPairInArray(int[] numbers, int delimetr)
        {
            if (numbers is null)
            {
                Console.WriteLine("Массив null");
                return -1;
            }
            int count = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] % delimetr != 0 && numbers[i] % delimetr == 0) count++;
                if (numbers[i - 1] % delimetr == 0 && numbers[i] % delimetr != 0) count++;
            }
            return count;
        }

        /// <summary>
        /// Выводит массив на экран
        /// </summary>
        /// <param name="delimetr">разделитель чисел</param>
        /// <param name="fieldSize">Размер поля для записи одного числа вместе с разделителем</param>
        /// <param name="numbers">массив</param>
        public static void PrintArray(string delimetr, int fieldSize, int[] numbers)
        {
            if (numbers is null)
            {
                Console.WriteLine("Массив null");
                return;
            }
            int y = Console.CursorTop;
            int delimetrLength = delimetr.Length;
            int inOneLine = 80 / (fieldSize + delimetrLength);
            int ind = 0;
            for (int i = 0; i <= numbers.Length / inOneLine; i++)
            {
                if (ind >= numbers.Length) break;
                for (int j = 0; j < inOneLine; j++)
                {
                    string s = numbers[ind].ToString() + delimetr;
                    if (s.Length < fieldSize) s = s.PadLeft(fieldSize);
                    Console.SetCursorPosition(j * fieldSize, y);
                    Console.WriteLine($"{s}");
                    ind++;
                    if (ind >= numbers.Length) break;
                }
                y++;
            }
        }
    }
}
