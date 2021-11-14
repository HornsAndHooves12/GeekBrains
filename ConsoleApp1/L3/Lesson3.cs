using ConsoleApp1.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L3;

internal class Lesson3 : IGeekBrains
{

    private List<Action> tasks;

    public Lesson3()
    {
        tasks = new List<Action>() { Task1, Task2, Task3 };
    }

    public string LessonName => "Lesson 3";

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

        Console.WriteLine("Выберите подзадачу: ");
        Console.WriteLine("структура выберите - 1");
        Console.WriteLine("класс выберите - 2");

        var number = int.Parse(Console.ReadLine());
        switch (number)
        {
            case 1:
                StructComplex();
                break;
            case 2:
                ClassComplex();
                break;
        }
    }

    private void StructComplex()
    {
        Console.Write("Re число для 1 структуры ");
        var re1 = double.Parse(Console.ReadLine());
        Console.Write("Im число для 1 структуры ");
        var im1 = double.Parse(Console.ReadLine());
        var stComplex1 = new SComplex(re1, im1);

        Console.Write("Re число для 2 структуры ");
        var re2 = double.Parse(Console.ReadLine());
        Console.Write("Im число для 2 структуры ");
        var im2 = double.Parse(Console.ReadLine());
        var stComplex2 = new SComplex(re2, im2);

        Console.WriteLine($"первое комплексное число {stComplex1}");
        Console.WriteLine($"второе комплексное число {stComplex2}");
      
        Console.WriteLine($"сумма равна {stComplex1 + stComplex2}");
        Console.WriteLine($"разница равна {stComplex1 - stComplex2}");
    }

    private void ClassComplex()
    {
        Console.Write("Re число для 1 класса ");
        var re1 = double.Parse(Console.ReadLine());
        Console.Write("Im число для 1 класса ");
        var im1 = double.Parse(Console.ReadLine());
        var clComplex1 = new CComplex(re1, im1);

        Console.Write("Re число для 2 класса ");
        var re2 = double.Parse(Console.ReadLine());
        Console.Write("Im число для 2 класса ");
        var im2 = double.Parse(Console.ReadLine());
        var clComplex2 = new CComplex(re2, im2);


      
        while (true)
        {

            Console.WriteLine($"первое комплексное число {clComplex1}");
            Console.WriteLine($"второе комплексное число {clComplex2}");
            Console.WriteLine("Выберите операцию над комплексным числом: ");
            Console.WriteLine("сумма - 1");
            Console.WriteLine("разница - 2");
            Console.WriteLine("произведенеи - 3");
            Console.WriteLine("выход - 0");
            var number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 0:
                    return;
                case 1:
                    Console.WriteLine($"сумма равна {clComplex1 + clComplex2}");
                    break;
                case 2:
                    Console.WriteLine($"разница равна {clComplex1 - clComplex2}");
                    break;
                case 3:
                    Console.WriteLine($"произведенеи равна {clComplex1 * clComplex2}");
                    break;
            }

            Console.WriteLine("нажмите на энтер что бы пойти дальше");
            Console.ReadLine();
            Console.Clear();
        }
       
    }

    private void Task2()
    {
        var summ = 0;
        var value = 0;

   
        do
        {
            do
            {
                Console.Write("Введите число: ");
            } while (!int.TryParse(Console.ReadLine(), out value));
            if (value > 0 && value % 2 == 1) summ += value;
        } while (value != 0);

        Console.WriteLine("Sum: {0}", summ);

    }

    private void Task3()
    {


    }

}