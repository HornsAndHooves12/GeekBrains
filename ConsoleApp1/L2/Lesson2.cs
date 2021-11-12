using ConsoleApp1.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L2;

internal class Lesson2 : IGeekBrains
{


    private List<Action> tasks;

    public Lesson2()
    {
        tasks = new List<Action>() { Task1, Task2, Task3, Task4, Task5, Task6, Task7 };
    }

    public string LessonName => "Lesson 2";

    public void Test()
    {

        Console.WriteLine("Выберите задачу: ");
        for (int i = 0; i < tasks.Count(); i++)
        {
            Console.WriteLine($"Task{i + 1}");
        }
        var taskNumber = int.Parse(Console.ReadLine()) - 1;
        tasks[taskNumber].Invoke();
      
    }

    private void Task1()
    {
        Console.Write("Первое число: ");
        var first = int.Parse(Console.ReadLine());
        Console.Write("Второе число: ");
        var second = int.Parse(Console.ReadLine());
        Console.Write("Третье число: ");
        var third = int.Parse(Console.ReadLine());

        var min = MinValue(first, second, third);
        Console.WriteLine($"наименьшее число: v1 {min}");
    }

    private int MinValue(int first, int second, int third)
    {
        var min = first;
        if (second < min)
        {
            min = second;
        }
        if (third < min)
        {
            min = third;
        }
        return min;
    }

    private void Task2()
    {
        Console.Write("Введите число: ");

        var enterValue = 0;
        var value = enterValue = int.Parse(Console.ReadLine());
        var count = CountDigit(value);
        Console.WriteLine($"В числе {enterValue} - {count} цифр");
    }
    private int CountDigit(int value)
    {
        var count = 0;
        if (value == 0)
        {
            return 1;
        }
        while (value != 0)
        {
            value /= 10;
            count++;
        }
        return count;
    }
    private void Task3()
    {
        int summ = 0;
        int value = 0;

        Console.Write("Введите число: ");
        do
        {
            value = int.Parse(Console.ReadLine());
            if (value > 0 && value % 2 == 1) summ += value;

            Console.Write("Введите ещё число: ");
        } while (value != 0);

        Console.WriteLine("Sum: {0}", summ);
    }

    private void Task4()
    {
    
        var count = 3;
        do
        {
           
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            var cred = new Credentials(login, password);
            if (cred.IsValid)
            {
                Console.WriteLine("You are logged in");
                return;
            }
            else
            {
                Console.WriteLine("Wrong credentials");
            }

        } while (--count > 0);


        Console.WriteLine("Login or password is wrong");

    }

    private void Task5()
    {
        Console.Write("Рост: ");
        var height = Console.ReadLine();
        Console.Write("Вес: ");
        var weight = double.Parse(Console.ReadLine());
        var heightInMeter = double.Parse(height) / 100;
        var bmi = weight / (heightInMeter * heightInMeter);
        Console.WriteLine($"bmi is: {bmi:F2}");

        if (bmi >= 18.5 && bmi <= 24.9)
        {
            Console.WriteLine("ты совсем не жирный - а даже красивый");
            Console.WriteLine("и тебе совсем не надо худеть и толстеть");

        }
        else if (bmi > 24.9)
        {
            var needWeight = 24.9 * (heightInMeter * heightInMeter);
            Console.WriteLine("ты жирный как поезд пассажирный");
            Console.WriteLine($"тебе жирному надо скинуть - {weight - needWeight:F2} кг"); 
        }
        else
        {
            var needWeight = 18.5 * (heightInMeter * heightInMeter);
            Console.WriteLine("ты совсем не жирный - а дрыщ");
            Console.WriteLine($"тебе дрыщ надо стать гурманом и нажрать - {needWeight - weight:F2} кг");
        }
    }
    private void Task6()
    {
        var count = 0;
        var before = DateTime.Now;
        for (int i = 1; i < 1_000_000_000; i++)
        {
            if (IsHorowoeChislo(i))
            {
                count++;
            }
            if(i % 1000000 == 0)
            {
                Console.WriteLine($"i - {i}");
            }
        }

        var after = DateTime.Now;
        Console.WriteLine($"Времячко - {after - before}");
    }

    private bool IsHorowoeChislo(int value)
    {
        var initialValue = value;
        var result = 0;
        while (value > 0)
        {
            result += value % 10;
            value /= 10;
        }
        return initialValue % result == 0;
    }

    private void Task7()
    {
        Console.Write("Введите a - ");
        var a = int.Parse(Console.ReadLine());

        Console.Write("Введите b - ");
        var b = int.Parse(Console.ReadLine());

        ALessThanB(a, b);
        var result = APlusB(a, b);
        Console.WriteLine($"result = {result}");
    }

    private void ALessThanB(int a, int b)
    {
        Console.WriteLine(a);
        if (a < b) ALessThanB(a + 1, b);
    }

    private int APlusB(int a, int b)
    {
        if (a <= b) return a + APlusB(a + 1, b);
        return 0;
    }

}
