using ConsoleApp1.Common;
using ConsoleApp1.Common.Interfaces;
using Lesson4ArrayLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoDimensialLib;

namespace ConsoleApp1.L4;

[Lesson("Lesson 4")]
internal class Lesson4 : IGeekBrains
{

    private List<Action> tasks;

    public Lesson4()
    {
        tasks = new List<Action>() { Task1, Task2, Task3, Task4, Task5 };
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

    private void Task1()
    {
        var arr = new int[20];
        var random = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = 10000 - random.Next(20000);
        }
        var count = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if ((arr[i - 1] % 3 == 0) != (arr[i] % 3 == 0))
            {
                Console.WriteLine(arr[i - 1] + " " + arr[i]);
                count++;
            }
        }
        Console.WriteLine(string.Join(",", arr));
        Console.WriteLine(count);
    }


    private void Task2()
    {
        var arr = new int[20];
        var random = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = 10000 - random.Next(20000);
        }
        var count = StaticClass.SolveCount(arr);

        Console.WriteLine(string.Join(",", arr));
        Console.WriteLine(count);
        Console.WriteLine("б задача -----------------------------------------------------");

        var list = StaticClass.ReadFile("L4\\Numbers.txt");
        Console.WriteLine(string.Join(",", list));
        Console.WriteLine("с задача -----------------------------------------------------");
        try
        {
            StaticClass.ReadFile("L4\\NumbersБлАблабла.txt");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(" такого файла не существует");
        }
    }

    private void Task3()
    {
        var library = new ArrayClass(10, 2, 2);
        Console.WriteLine(library);

        Console.WriteLine($"sum = {library.Sum}");

        Console.WriteLine($"inverse = {string.Join(",", library.Inverse())}");

        library.Multi(3);
        Console.WriteLine($"multi * 3 = {library}");

        Console.WriteLine($"maxCount = {library.MaxCount}");
        var lines = library.CountFrequency().Select(kvp => kvp.Key + ": " + kvp.Value.ToString());
        Console.WriteLine($"maxCount = {string.Join(",", lines)}");
        library[8] = library[8] + 6;

        Console.WriteLine($"maxCount = {library.MaxCount}");
       
        lines = library.CountFrequency().Select(kvp => kvp.Key + ": " + kvp.Value.ToString());
        Console.WriteLine($"maxCount = {string.Join(",",lines)}");
      
    }

    private void Task4()
    {
        var accounts = GetAccounts();
        var count = 3;
        do
        {

            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            var account = new Account
            {
                Login = login,
                Password = password,
            };
            if (accounts.Any( a=> a.Login == account.Login && a.Password == account.Password))
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

    public static List<Account> GetAccounts()
    {
      
        using var stream = new StreamReader("L4\\Accounts.txt");
        string line;
        var accounts = new List<Account>();
        while ((line = stream.ReadLine()) != null)
        {
            var account = new Account
            {
                Login = line,
                Password = stream.ReadLine(),
            };
            accounts.Add(account);
         
        }
        return accounts;
    }

    private void Task5()
    {
        File.Delete("L4\\TwoDimensial.txt");
        var twoDim = new TwoDimensialArray(5, 5);
        Console.WriteLine(twoDim);
        Console.WriteLine(twoDim.Min);
        Console.WriteLine(twoDim.Max);
        Console.WriteLine(twoDim.Sum());
        Console.WriteLine(twoDim.Sum(50));

        twoDim.IndexOfMin(out var x, out var y);
        Console.WriteLine(x);

        Console.WriteLine(y);
        var twoDim2 = new TwoDimensialArray(3, 3);
        Console.WriteLine(twoDim2);
        try
        {
            twoDim2.FetchFromFile("L4\\TwoDimensial.txt");
        }catch (FileNotFoundException ex)
        {

        }
        twoDim.SaveToFile("L4\\TwoDimensial.txt");
        twoDim2.FetchFromFile("L4\\TwoDimensial.txt");

        Console.WriteLine(twoDim2);
    }
}
