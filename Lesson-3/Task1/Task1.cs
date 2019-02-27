using System;

namespace Task1
{
    class Task1
    {
        //Северин Андрей

        //1.	а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры.
        //      б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса.
        //      в) Добавить диалог с использованием switch демонстрирующий работу класса.

        static void Main(string[] args)
        {
            ComplexStruct complexA = new ComplexStruct(1, 2);
            ComplexStruct complexB = new ComplexStruct(3, 4);

            Console.WriteLine("Комплексные числа - структура");
            Console.WriteLine("Первое комплексное число: " + complexA);
            Console.WriteLine("Второе комплексное число: " + complexB);
            Console.WriteLine();

            Console.WriteLine("Сложение через метод Add: {0}", complexA.Add(complexB));
            Console.WriteLine("Сложение оператором \"+\": {0}", complexA + complexB);
            Console.WriteLine();

            Console.WriteLine($"Вычитание из {complexA} числа {complexB} через метод Subtract: {complexA.Subtract(complexB)}");
            Console.WriteLine($"Вычитание из {complexA} числа {complexB} оператором \"-\": {complexA - complexB}");
            Console.WriteLine();

            Console.WriteLine("Умножение методом Multiply: {0}", complexA.Multiply(complexB));
            Console.WriteLine("Умножение оператором \"*\": {0}", complexA * complexB);
            Console.WriteLine();

            Console.WriteLine($"Деление числа {complexA} на число {complexB} через метод Devide: {complexA.Devide(complexB)}");
            Console.WriteLine($"Деление числа {complexA} на число {complexB} оператором \"/\": {complexA / complexB}");
            Console.WriteLine();

            ComplexStruct complexC = new ComplexStruct(1, 2);
            Console.WriteLine($"Устверждение - число {complexA} равно числу {complexB}: {complexA == complexB}");
            Console.WriteLine($"Устверждение - число {complexA} равно числу {complexC}: {complexA == complexC}");
            Console.ReadKey();

            ComplexClass complexAClass = new ComplexClass(5, 2);
            ComplexClass complexBClass = new ComplexClass(3, 4);

            Console.WriteLine();
            Console.WriteLine("Проверка работы класса комплексных чисел");
            Console.WriteLine($"Даны комплексные числа A = {complexAClass} и B = {complexBClass}");
            ShowOperation();

            string answer;
            while ((answer = Console.ReadLine()) != "0")
            {
                switch (answer)
                {
                    case "-":
                        Console.WriteLine($"{complexAClass} - {complexBClass} = {complexAClass - complexBClass}\n");
                        break;
                    case "+":
                        Console.WriteLine($"{complexAClass} + {complexBClass} = {complexAClass + complexBClass}\n");
                        break;
                    case "*":
                        Console.WriteLine($"{complexAClass} * {complexBClass} = {complexAClass * complexBClass}\n");
                        break;
                    case "/":
                        Console.WriteLine($"{complexAClass} / {complexBClass} = {complexAClass / complexBClass}\n");
                        break;
                    case "!=":
                        Console.WriteLine($"{complexAClass} != {complexBClass} = {complexAClass != complexBClass}\n");
                        break;
                    case "==":
                        Console.WriteLine($"{complexAClass} == {complexBClass} = {complexAClass == complexBClass}\n");
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция");
                        ShowOperation();
                        break;
                }
                ShowOperation();
            }
            
        }

        static void ShowOperation()
        {
            Console.WriteLine("Доступные операции \"!=\" \"==\" \"/\" \"*\" \"+\" \"-\"");
            Console.Write("Выберите операцию. Для выхода введите 0: ");
        }

    }
}
