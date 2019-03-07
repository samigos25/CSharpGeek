using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task1
{
    class Task
    {
        //Северин Андрей

        //1.	Создать программу, которая будет проверять корректность ввода логина.
        //Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры,
        //при этом цифра не может быть первой:
        //а) без использования регулярных выражений;
        //б) **с использованием регулярных выражений.

        static void Main(string[] args)
        {
            string login;
            do
            {
                Console.ResetColor();
                Console.Write("Введите логин, 0 для выхода: ");
                login = Console.ReadLine();
                if (login == "0") break;
                Console.ForegroundColor = LoginIsCorrect(login) ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(LoginIsCorrect(login) ? "Корректный логин" : "Не корректный логин");

                Console.ForegroundColor = LoginIsCorrectWithRegex(login) ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(LoginIsCorrectWithRegex(login) ? "Корректный логин" : "Не корректный логин");
            } while (login != "0");
        }

        //Моджно использовать IgnoreCase тогда pattern уменьшится до @"^[a-z]{1}[a-z0-9]{1,9}$"
        static bool LoginIsCorrectWithRegex(string login)
        {
            string pattern = @"^[a-zA-Z]{1}[a-zA-Z0-9]{1,9}$";
            Regex rx = new Regex(pattern);
            if (!rx.IsMatch(login)) return false;
            return true;
        }
        static bool LoginIsCorrect(string login){

            List<int> range = Enumerable.Range('a', 'z' - 'a' + 1).ToList();
            range.AddRange(Enumerable.Range('A', 'Z' - 'A' + 1));
            range.AddRange(Enumerable.Range('0', '9' - '0' + 1));
            if (login.Length < 2 || login.Length > 10) return false;
            char[] chars = login.ToCharArray();
            if (!Char.IsLetter(chars[0])) return false;
            for (int i = 1; i < chars.Length; i++)
            {
                if (!range.Contains(chars[i])) return false;
            }
            return true;
        }
   }
}
