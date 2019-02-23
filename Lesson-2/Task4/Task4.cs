using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Task4
    {
        //4.    Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль.
        //      На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
        //      Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль,
        //      программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.
        static void Main(string[] args)
        {
            string login;
            string pass;
            int trySign = 0;
            Console.Write("Введите логин: ");
            login = Console.ReadLine();
            Console.Write("Введите Пароль: ");
            pass = Console.ReadLine();
            while (!SignIn(login, pass) && trySign < 2)
            {
                trySign++;
                Console.Write("Пара логин/пароль неверная повторите ввод пароля: ");
                pass = Console.ReadLine();
            }

            if (!SignIn(login, pass))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Access denied");
                Console.ReadKey();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Access granted");
            Console.ReadKey();
        }

        static bool SignIn(string login, string password)
        {
            return ((login == "root") && (password == ("GeekBrains"))) ? true : false;
        }
    }
}
