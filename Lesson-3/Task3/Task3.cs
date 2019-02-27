using System;

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
            Fraction D = new Fraction(150, 5);

            Console.WriteLine("Даны дроби:");
            Console.WriteLine($"A = {A}, B = {B}, C = {C}, D = {D}\n");
            Console.WriteLine("Проверка операторов + - / *. Все операторы реализованы через методы,\n" +
                              " так что одновременно проверяются и методы.\n" +
                              "В конце операции вызывается упрощение");
            Console.WriteLine($"{A} + {B} - {C} = {A + B - C}");
            Console.WriteLine($"{B} * {D}  = {B * D}");
            Console.WriteLine($"{B} / {C}  = {B / C} \n");
            Console.WriteLine("Десятичное отображение дроби через поле");
            Console.WriteLine($"{A} = {A.DecimalFraction}");
            Console.WriteLine($"{D} = {D.DecimalFraction}");

            Console.WriteLine($"Упрощение дроби {C} = {C.Simplify(C)}");
            Console.WriteLine($"Упрощение дроби {D} = {C.Simplify(D)}");


            Console.ReadKey();
            

           
        }
    }
}
