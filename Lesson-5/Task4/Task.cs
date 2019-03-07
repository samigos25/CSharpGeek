﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Helper;

namespace Task4
{
    class Task
    {
        //Северин Андрей

        //4.	 *Задача ЕГЭ.
        // На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
        // В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100,
        // каждая из следующих N строк имеет следующий формат:
        //      <Фамилия> <Имя> <оценки>,
        // где  <Фамилия> — строка, состоящая не более чем из 20 символов,
        //      <Имя> — строка, состоящая не более чем из 15 символов,
        //      <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе.
        // <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
        // Иванов Петр 4 5 3
        // Требуется написать как можно более эффективную программу,
        // которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников.
        // Если среди остальных есть ученики, набравшие тот же средний балл,
        // что и один из трёх худших, следует вывести и их фамилии и имена.
        // 
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            List<string> listForWork = new List<string>();
            using (StreamReader streamReader = new StreamReader("..\\..\\list.csv"))
            {
                while (!streamReader.EndOfStream)
                {
                    list.Add(streamReader.ReadLine());
                }
            }
            int num = Tools.ReadInt("Введите число от 10 до 100: ", o => (o >= 10 && o <= 100));
            listForWork.AddRange(list.GetRange(0, num));
            list = Task.VeryBad(listForWork);
            Console.WriteLine(list.Count);
            foreach (string str in list)
            {
                Console.WriteLine(str);
            }
            Console.ReadKey();
        }

        private static List<string> VeryBad(List<string> list)
        {
            short grade1;
            short grade2;
            short grade3;
            List<string> result = new List<string>();
            var t = list.Select((item, index) =>(item: item, index: index)).Select(o => {
                string[] arr = o.item.Split(new char[] { ' ' });
                grade1 = short.Parse(arr[2]);
                grade2 = short.Parse(arr[3]);
                grade3 = short.Parse(arr[4]);
                return (GradesSum:grade1 + grade2 + grade3, Index: o.index);
            });
            var groupings = t.OrderBy(o => o.GradesSum).GroupBy(o => o.GradesSum).ToList();
            for (int i = 0; i < 3; i++)
            {
                foreach (var (_, index) in groupings[i])
                {
                    result.Add(list[index]);
                }
            }
            return result;
        }
    }
}
