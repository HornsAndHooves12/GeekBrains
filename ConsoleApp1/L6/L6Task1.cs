using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L6;

internal class L6Task1
{

    public delegate double Fun(double x);

    public delegate double TaskFun(double x, double y);

    // с такой же сигнатурой, как у делегата
    public static void Table(Fun F, double x, double b)
    {
        Console.WriteLine("----- X ----- Y -----");
        while (x <= b)
        {
            Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
            x += 1;
        }
        Console.WriteLine("---------------------");
    }
    public static void TableTask(TaskFun F, double x, double a, double b)
    {
        Console.WriteLine("----- X ----- Y -----");
        while (x <= b)
        {
            Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
            x += 1;
        }
        Console.WriteLine("---------------------");
    }
    public static double MyTaskFunc(double a, double x)
    {
        return a * x * x;
    }

    // Создаем метод для передачи его в качестве параметра в Table
    public static double MyFunc(double x)
    {
        return x * x * x;
    }

    public static void MainTest()
    {
        // Создаем новый делегат и передаем ссылку на него в метод Table
        Console.WriteLine("Таблица функции MyFunc:");
        // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
        Table(new Fun(MyFunc), -2, 2);
        Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
        // Упрощение(c C# 2.0).Делегат создается автоматически.            
        Table(MyFunc, -2, 2);
        Console.WriteLine("Таблица функции Sin:");
        Table(Math.Sin, -2, 2);      // Можно передавать уже созданные методы
        Console.WriteLine("Таблица функции x^2:");
        // Упрощение(с C# 2.0). Использование анонимного метода
        Table(delegate (double x) { return x * x; }, 0, 3);


        TableTask(MyTaskFunc, -2, 5, 2);

        TableTask(delegate (double a, double x) { return a * Math.Sin(x); }, -2, 5, 2);
    }
}
