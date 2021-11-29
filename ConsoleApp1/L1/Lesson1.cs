using ConsoleApp1.Common;
using ConsoleApp1.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L1;

[Lesson("Lesson 1")]
internal class Lesson1 : IGeekBrains
{

    private List<Action> tasks;

    public Lesson1()
    {
        tasks = new List<Action>() { Task1, Task2, Task3, Task4, Task5, Task6 };
    }

    public void Test()
    {
        foreach (var task in tasks)
        {
            task.Invoke();
            Console.Write("что бы продолжить нажмите энтер");
            Console.ReadLine();
            Console.Clear();
        }
    }

    public void Task1()
    {
        // (имя, фамилия, возраст, рост, вес)
        Console.Write("Имя: ");
        var name = Console.ReadLine();
        Console.Write("Фамилия: ");
        var lastName = Console.ReadLine();
        Console.Write("Возраст: ");
        var age = Console.ReadLine();
        Console.Write("Рост: ");
        var height = Console.ReadLine();
        Console.Write("Вес: ");
        var weight = Console.ReadLine();

        Console.WriteLine(name + " " + lastName + " " + age + " " + height + " " + weight);
        Console.WriteLine($"{name} {lastName} {age} {height} {weight}");
        Console.WriteLine("{0} {1} {2} {3} {4}", name, lastName, age, height, weight);
    }

    public void Task2()
    {
        Console.Write("Рост: ");
        var height = Console.ReadLine();
        Console.Write("Вес: ");
        var weight = Console.ReadLine();
        float heightInMeter = float.Parse(height) / 100;
        float bmi = int.Parse(weight) / (heightInMeter * heightInMeter);
        Console.WriteLine("bmi is: " + bmi);

    }


    public void Task3()
    {
        Console.Write("x1: ");
        var x1 = double.Parse(Console.ReadLine());
        Console.Write("y1: ");
        var y1 = double.Parse(Console.ReadLine());

        Console.Write("x2: ");
        var x2 = double.Parse(Console.ReadLine());
        Console.Write("x2: ");
        var y2 = double.Parse(Console.ReadLine());

        var result = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        Console.WriteLine($"{result:F2}");
    }

    public void Task4()
    {

        Console.Write("x: ");
        var x = int.Parse(Console.ReadLine());
        Console.Write("y: ");
        var y = int.Parse(Console.ReadLine());

        var z = x;
        x = y;
        y = z;
        Console.WriteLine($"x: {x} y: {y}");
        Console.WriteLine("_____________________________________________________________");

        Console.Write("x: ");
        x = int.Parse(Console.ReadLine());
        Console.Write("y: ");
        y = int.Parse(Console.ReadLine());

        x = x + y;
        y = x - y;
        x = x - y;

        Console.WriteLine($"x: {x} y: {y}");
    }
    public void Task5()
    {
        Methods.Print("Александр Ключник, г.Днепропетровск", Console.WindowWidth / 2, Console.WindowHeight / 2);
    }

    public void Task6()
    {
        Methods.Pause("не знаю что там в методе надо сделать");
    }


}