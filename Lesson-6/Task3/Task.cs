using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

//Северин Андрей

///3.	Переделать программу Пример использования коллекций для решения следующих задач:
//а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
//б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
//в) отсортировать список по возрасту студента;
//г) * отсортировать список по курсу и возрасту студента

class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string University { get; set; }
    public string Faculty { get; set; }
    public int Course { get; set; }
    public int Group { get; set; }
    public string City { get; set; }
    public int Age { get; set; }

    public Student() { }
    // Создаем конструктор
    public Student(string lastName, string firstName, string university, string faculty, int course, int age, int group, string city)
    {
        this.LastName = lastName;
        this.FirstName = firstName;
        this.University = university;
        this.Faculty = faculty;
        this.Course = course;
        this.Age = age;
        this.Group = group;
        this.City = city;
    }
}
class Task
{
    static int MyDelegat(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
    {
        return String.Compare(st1.FirstName, st2.FirstName);          // Сравниваем две строки
    }
    static void Main(string[] args)
    {
        int bakalavr = 0;
        int magistr = 0;
        List<Student> list = new List<Student>(); 
        DateTime dt = DateTime.Now;
        using (StreamReader sr = new StreamReader("..\\..\\list.csv", Encoding.UTF8))
        {
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student()
                    {
                        LastName = s[0],
                        FirstName = s[1],
                        City = s[7],
                        University = s[2],
                        Course = int.Parse(s[4]),
                        Faculty = s[3],
                        Age = int.Parse(s[6]),
                        Group = int.Parse(s[5]),
                    });

                    if (list.Last().Course < 5) bakalavr++; else magistr++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
        }

        list.Sort(new Comparison<Student>(MyDelegat));
        Console.WriteLine("Всего студентов:" + list.Count);
        Console.WriteLine("Магистров:{0}", magistr);
        Console.WriteLine("Бакалавров:{0}", bakalavr);
        //foreach (var v in list) Console.WriteLine(v.FirstName);

        Console.WriteLine($"Количество студентов учищихся на 5 и 6 курсах: {list.Where(o => (o.Course == 5 || o.Course == 6)).Count()}\n");

        Console.WriteLine("Студенты в возрасте от 18 до 20 лет учатся:");
        foreach (IGrouping<int, Student> students in list.Where(o => (o.Age >= 18 && o.Age <= 20)).OrderBy(o => o.Course).GroupBy(o => o.Course))
        {
            Console.WriteLine($"На {students.Key} курсе учится {students.Count()} студентов");
        }

        var l1 = list.OrderBy(o => o.Age); //Сортировка по возрасту
        var l2 = list.OrderBy(o => o.Course).ThenBy(o => o.Age); //Сортировка по курсу и возрасту студента
        Console.WriteLine(DateTime.Now - dt);
        Console.ReadKey();
    }
}
