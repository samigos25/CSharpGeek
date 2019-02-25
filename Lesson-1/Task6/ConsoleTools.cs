using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public static class ConsoleTools
    {
        /// <summary>
        /// dawdwwd
        /// </summary>
        /// <param name="message">сообщение для вывода</param>
        /// <param name="x">горизонтальная координата</param>
        /// <param name="y">вертикальная координата</param>
        //Северин Андрей
        public static void Print(string message, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(message);
        }

        public static void Pause()
        {
            Console.ReadKey();
        }
    }
}
