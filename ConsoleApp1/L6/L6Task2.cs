using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L6;

internal class L6Task2
{

    private static List<(string name, FFun f)> _funcs;

    public static void MainTest()
    {
        _funcs = new List<(string name, FFun f)> { ("x * x - 50 * x + 10", F), ("x * x + 10", FF), ("x * 50", FFF) };
        Console.WriteLine("Выбери метод ");
        for (int i = 0; i < _funcs.Count; i++)
        { 
            Console.WriteLine($"{ i }: {_funcs[i].name} ");
        }
        var position = int.Parse(Console.ReadLine());

        Console.WriteLine("Выбери начало отрезка ");
        var a = int.Parse(Console.ReadLine());
        Console.WriteLine("Выбери конец отрезка ");
        var b = int.Parse(Console.ReadLine());
        SaveFunc(_funcs[position].f,"data.bin", a, b, 0.5);
        double min;
        var list = Load("data.bin", out min);
        Console.WriteLine(min);
        Console.WriteLine(string.Join(",", list));
        Console.ReadKey();
    }

    private delegate double FFun(double x);

    public static double F(double x)
    {
        return x * x - 50 * x + 10;
    }

    public static double FF(double x)
    {
        return x * x + 10;
    }
    public static double FFF(double x)
    {
        return x * 50;
    }
    private static void SaveFunc(FFun f, string fileName, double a, double b, double h)
    {
        FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        double x = a;
        while (x <= b)
        {
            bw.Write(f(x));
            x += h;// x=x+h;
        }
        bw.Close();
        fs.Close();
    }
    private static double[] Load(string fileName, out double min)
    {
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader bw = new BinaryReader(fs);
        min = double.MaxValue;
        double d;
        double[] a = new double[fs.Length / sizeof(double)];
        for (int i = 0; i < fs.Length / sizeof(double); i++)
        {
            // Считываем значение и переходим к следующему
            d = bw.ReadDouble();
            if (d < min) min = d;
            a[i] = d;

        }
        bw.Close();
        fs.Close();
        return a;
    }




}
