using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Task
    {
        static void Main(string[] args)
        {
            string pathToFile = @"..\..\logins.csv";
            Console.WriteLine($"Файл со список логинов и паролей {pathToFile}");
            var list = ReadFileLP(pathToFile);

            bool acces = false;
            int loginCount = 0;
            if (!(list is null))
            foreach (var (login, pass) in list)
            {
                loginCount++;
                if (LogIn(login, pass))
                {
                    acces = true;
                    break;
                }
            }
            if (!acces)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Access denied");
                Console.ReadKey();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Access granted");
            Console.ResetColor();
            Console.WriteLine($"Нужная пара содержалась на {loginCount} строке");
            Console.ReadKey();



        }


        static bool LogIn(string login, string password)
        {
            return ((login == "root") && (password == ("GeekBrains"))) ? true : false;
        }
        static List<(string Login, string Pass)> ReadFileLP(string pathFile)
        {
            List < (string Login, string Pass)> list  = new List<(string Login, string Pass)>();
            try
            {
                using (StreamReader sr = new StreamReader(pathFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string s = sr.ReadLine();
                        string[] temp = s.Split(new char[] {';'});
                        if (temp.Length >= 2) list.Add((temp[0], temp[1]));
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
            return list;
        }
    }
}
