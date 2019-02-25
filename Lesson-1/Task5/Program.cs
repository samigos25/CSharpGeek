using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const string FisrtName = "Северин";
            const string SecondName = "Андрей";
            const string OwnTown = "Москва";

            ConsoleTools.Print(SecondName,40 - FisrtName.Length/2,9);
            ConsoleTools.Print(FisrtName, 40 - FisrtName.Length / 2, 10);
            ConsoleTools.Print(OwnTown, 40 - FisrtName.Length / 2, 11);
            ConsoleTools.Pause();


        }
    }
}
