using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Helper;

namespace ExtraTask
{
    class ExtraTask
    {
        static void Main(string[] args)
        {
            int userNumber = Tools.ReadInt("Введите положительное целое число: ", o => o > 0);
            List<List<int>> Groups = new List<List<int>>();
            for (int i = 2; i <= userNumber; i++)
            {
                var t = new List<int>() {i};
                Groups.Add(t);
            }

            bool cont = false;
            int groupForRemove = 0;
            do
            {
                cont = false;
                for (int i = groupForRemove + 1; i < Groups.Count; i++)
                {
                    if (CanUnite(Groups[groupForRemove], Groups[i]))
                    {
                        foreach (var element1 in Groups[groupForRemove])
                        {
                            Groups[i].Add(element1);
                        }

                        cont = true;
                        break;
                    }

                }
                if (cont) Groups.RemoveAt(groupForRemove);
                if (!cont && groupForRemove < Groups.Count - 1)
                {
                    cont = true;
                    groupForRemove++;
                } 

            } while (cont);

            Console.WriteLine("\n" + 1);
            foreach (var group in Groups)
            {
                group.Reverse();
                group.ForEach(o => Console.Write($"{o}, "));
                Console.WriteLine();
            }

            Console.ReadKey();

        }

        static bool CanUnite(List<int> ListA, List<int> ListB)
        {
            foreach (var a in ListA)
            {
                foreach (var b in ListB)
                {
                    if (b > a && b % a == 0) return false;
                    if (a > b && a % b == 0) return false;
                }
            }

            return true;
        }
    }
}
