using ConsoleApp1.Common;
using ConsoleApp1.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L6;

[Lesson("Lesson 6")]
internal class Lesson6 : IGeekBrains
{
    private List<Action> tasks;

    public Lesson6()
    {
        tasks = new List<Action>() { L6Task1.MainTest, L6Task2.MainTest, L6Task3.MainTest };
    }
    public void Test()
    {
        Console.WriteLine("Выберите задачу: ");
        for (int i = 0; i < tasks.Count(); i++)
        {
            Console.WriteLine($"Task {i + 1}");
        }
        int taskNumber;
        while (!int.TryParse(Console.ReadLine(), out taskNumber))
        {
            Console.Clear();
            Console.WriteLine("Ошибка ввода - давай исщо :");
            for (int i = 0; i < tasks.Count(); i++)
            {
                Console.WriteLine($"Task{i + 1}");
            }
        }
        if (taskNumber > tasks.Count || taskNumber < 0)
        {
            Console.WriteLine("Такой задачи нет");
        }
        else
        {
            tasks[taskNumber - 1]();
        }
    }
  
}

    
