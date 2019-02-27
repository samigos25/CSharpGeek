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

            DoGroups(Groups);

            Console.WriteLine("\n" + 1);
            foreach (var group in Groups)
            {
                group.Reverse();
                group.ForEach(o => Console.Write($"{o}, "));
                Console.WriteLine("\n");
            }

            Console.WriteLine($"Количество групп {Groups.Count+1}");

            int countGroups=0;
            for (int j = 1; j < 512; j++)
            {
                Groups.Clear();
                for (int i = 2; i <= j; i++)
                {
                    var t = new List<int>() { i };
                    Groups.Add(t);
                }
                DoGroups(Groups);

                if (countGroups != Groups.Count + 1)
                {
                    countGroups = Groups.Count + 1;
                    Console.WriteLine($"Число {j}, количество групп {Groups.Count + 1}");
                }
            }

            Console.WriteLine("\nОчень интересный результат. \nВидно что количество групп увеличивается на 1 с каждой новой степенью 2.");
            Console.WriteLine("Фактически чтобы определить количество групп для любого числа нужно узнать ближайую степень 2 к этому числу и прибавить один\n");
            Console.ReadKey();

            
            do
            {
                userNumber = Tools.ReadInt("Введите Большое положительное целое число(0 для выхода): ", o => o >= 0);
                Console.WriteLine($"Число {userNumber}, количество групп {NearPower2(userNumber) + 1}");
            } while(userNumber != 0);

            Console.ReadKey();
        }

        static int NearPower2(int num)
        {
            if (num == 1) return 0;
            int pow = 1;
            while (num - (int)Math.Pow(2,pow) >= Math.Pow(2, pow))
            {
                pow++;
            }

            return pow;
        }

        static void DoGroups(List<List<int>> Groups)
        {
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
