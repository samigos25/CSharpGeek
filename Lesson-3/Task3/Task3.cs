using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Task3
    {
        //Северин Андрей

    //3.    *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
    //        Предусмотреть методы сложения, вычитания, умножения и деления дробей.
    //        Написать программу, демонстрирующую все разработанные элементы класса.

    //      * Добавить свойства типа int для доступа к числителю и знаменателю;
    //      * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
    //      ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
    //      *** Добавить упрощение дробей.

        static void Main(string[] args)
        {
           
            Fraction A = new Fraction(-1, 2);
            Fraction B = new Fraction(2, 3);
            Fraction C = new Fraction(6, 9);
            Console.WriteLine(A);
            Console.WriteLine(B);
            Console.WriteLine(" - {0}", A.Substract(B));
            Console.WriteLine(" + {0}", A.Add(B));
            Console.WriteLine(" / {0}", A.Devide(B));
            Console.WriteLine(" * {0}", A.Multiply(B));
            Console.WriteLine(A.DecimalFraction);
            Console.WriteLine(B.DecimalFraction);
            Console.WriteLine(A.Simplify(C));
            C.Simplify();
            Console.WriteLine("Упрощение {0}", C);
            Console.WriteLine(A == C);
            Console.WriteLine(A != C);
            C.Denominator = 2;
            C.Numerator = -1;
            Console.WriteLine(A == C);
            Console.WriteLine(A != C);

            Console.ReadKey();
            

           
        }
    }
}
