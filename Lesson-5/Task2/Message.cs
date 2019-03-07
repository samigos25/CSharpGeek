using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    //Северин Андрей

    //2.	Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
    //а) Вывести только те слова сообщения,  которые содержат не более n букв.
    //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    //в) Найти самое длинное слово сообщения.
    //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    //д) *** Создать метод, который производит частотный анализ текста.
    //      В качестве параметра в него передается массив слов и текст,
    //      в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.
    //      Здесь требуется использовать класс Dictionary.
    public static class Message
    {
        /// <summary>
        ///Ищет все слова во фразе
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string[] FindAllWords(string msg)
        {
            string[] result;
            string pattern = @"\b[a-zA-Zа-яёА-ЯЁ]+\b";
            Regex rx = new Regex(pattern, RegexOptions.Multiline);
            result = rx.Matches(msg).Cast<Match>().Select(m => m.Value).ToArray();
            return result;
        }

        /// <summary>
        /// Возвращает строку которая состоит слов длина которых соответствуети заданному условиюразделенных заданным разделителем
        /// </summary>
        /// <param name="msg">исходная фраза</param>
        /// <param name="separator">разделитель</param>
        /// <param name="rFunc">Функция для проверки длины</param>
        /// <returns></returns>
        public static string Words(string msg, char separator, Func<int, bool> rFunc)
        {
            StringBuilder result = new StringBuilder();
            foreach (string s in FindAllWords(msg))
            {
                if (rFunc(s.Length)) result.Append(s + separator);
            }
            return result.ToString().TrimEnd(separator);
        }

        /// <summary>
        /// Ищет все слова во фразе которые длинее заданного. Слова разделены пробелами
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string MoreThаnN(string msg, int number)
        {
            return Words(msg, ' ', o => o > number);
        }
        /// <summary>
        /// Ищет все слова во фразе которые длинее заданного. Слова разделены пробелами
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string LessThаnN(string msg, int number)
        {
            return Words(msg, ' ', o => o < number);
        }

        /// <summary>
        /// Удаляет все слова во фразе а также пробельный символ рядом с ним которые заканчиваются на заданный символ
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static string RemoveWithLast(string msg, char symbol)
        {
            string result = msg;
            string[] arr = FindAllWords(msg);
            string s;
            for (int i = 0; i < arr.Length; i++)
            {
                s = arr[i];
                if (s.Last() == symbol)
                {
                    string pattern;
                    if (s.Length == 1)
                    {
                        pattern = i == 0 ? @"^" + s + @"\s?\b" :
                            i == arr.Length - 1 ? @"\b\s?" + s + @"$" : @"\s?\b" + s + @"\b\s?";
                    } else
                    pattern = s + @"\s?\b";
                    result = Regex.Replace(result, pattern, "");
                }
            }
            return result;
        }

        /// <summary>
        ///Ищет самое  длинное слово во фразе. Если таких слов несколько то возвращает первое
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string LongestWord(string msg)
        {
            int max = 0;
            string[] words = FindAllWords(msg);
            for (int i = 0; i < words.Length; i++)
            {
                max = words[max].Length < words[i].Length ? i : max;
            }
            return words[max];
        }

        /// <summary>
        /// Создает фразу из самых длинных слов с указанным разбросом по длине. Слова разделяются пробелами.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="scatter"></param>
        /// <returns></returns>
        public static string PraseOfTheLongestWords(string msg, int scatter)
        {
            return MoreThаnN(msg, LongestWord(msg).Length - scatter - 1);
        }

        public static Dictionary<string, int> Freak(string[] arr, string ftext)
        {
            List<string> words = arr.Select(o => o.ToLower()).ToList();
            List<string> text = FindAllWords(ftext.ToLower()).ToList();
            var result = text.GroupBy(o => o).Where(o => words.Contains(o.Key)).ToDictionary(x => x.Key, x => x.Count());
            return result;

        }
    }
}
