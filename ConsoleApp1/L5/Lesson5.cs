using ConsoleApp1.Common;
using ConsoleApp1.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.L5;

[Lesson("Lesson 5")]
internal class Lesson5 : IGeekBrains
{

    private List<Action> tasks;

    public Lesson5()
    {
        tasks = new List<Action>() { Task1, Task2, Task3, Task4 };
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
        Console.WriteLine("Введите логин: ");
        var login = Console.ReadLine();
        var isValid1 = IsValid1(login);
        var isValid2 = IsValid2(login);
        LoginVerification(isValid1);
        LoginVerification(isValid2);
    }

    private bool IsValid1(string login)
    {
        if (login == null) return false;
        if (login.Length < 2 || login.Length > 10) return false;
        if (!IsLatinLetter(login[0])) return false;
        return login.Skip(1).All(x => IsDigitLetter(x) || IsLatinLetter(x));
    }

    private bool IsValid2(string login)
    {
        if (login == null) return false;
        return new Regex("^[a-zA-Z][a-zA-Z0-9]{1,9}$").IsMatch(login);
    }

    private bool IsLatinLetter(char letter) => (letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z');

    private bool IsDigitLetter(char letter) => letter >= '0' && letter <= '9';

    private void LoginVerification(bool isValid)
    {
        if (isValid)
        {
            Console.WriteLine("Логин валидный");
        }
        else
        {
            Console.WriteLine("Неверный логин");
        }
    }

    private void Task2()
    {
        var text = "Урок 5. Символы, строки, регулярные выражения Символы, строки регулярные";
        Message.PrintWordWithNLetter(text, 7);
        Console.WriteLine("------------------------");
        Message.PrintWordWithoutLastLetter(text, 'ы');
        Console.WriteLine("------------------------");
        Message.PrintWordWithLongestLength(text);
        Console.WriteLine("------------------------");
        Message.PrintLongestWords(text);
    }
    private void Task3()
    {

        var text = Console.ReadLine(); 
        var test = Console.ReadLine(); 

        var dict = new Dictionary<char, int>();
        foreach (char c in test)
        {
            if (!dict.ContainsKey(c))
            {
                dict[c] = 1;
            }
            else
            {
                dict[c]++;
            }
        }
        foreach (char c in text)
        {
            if (!dict.TryGetValue(c, out var count) && count > 0)
            {
                Console.WriteLine("досвидания - не перестановка");
                return;
            }
            else
            {
                dict[c]--;
            }
        }
        if (dict.Any(kvp => kvp.Value > 0))
        {
            Console.WriteLine("досвидания - не перестановка");
            return;
        }
        Console.WriteLine("здрасте - это перестановка");
    }

    private void Task4()
    {
        using var stream = new StreamReader("L5\\Pupils.txt");
        string line = stream.ReadLine();
        var count = int.Parse(line);
        
        Span<char> surnameBuffer = stackalloc char[20];
        Span<char> nameBuffer = stackalloc char[15];
        
        var minPupils = new List<Pupil>(3);

        minPupils.Add(new Pupil(ReadString(stream, surnameBuffer), ReadString(stream, nameBuffer), ReadDigit(stream) + ReadDigit(stream) + ReadDigit(stream)));
        ReadNewLine(stream);

        for (int i = 1; i < count; i++)
        {
            var surname = ReadString(stream, surnameBuffer);
            var name = ReadString(stream, nameBuffer);
            var sum = ReadDigit(stream) + ReadDigit(stream) + ReadDigit(stream);
            Console.WriteLine($"{surname} {name} {sum}");
            ReadNewLine(stream);

            if (minPupils[minPupils.Count - 1].Sum < sum)
            {
                continue;
            }

            if (minPupils[minPupils.Count - 1].Sum == sum)
            {
                minPupils.Add(new Pupil(surname, name, sum));
                continue;
            }

            for (int j = 0; j < minPupils.Count; j++)
            {
                if(minPupils[j].Sum > sum)
                {
                    if (j == 2 || (minPupils.Count > 2 && minPupils[1] != minPupils[2]))
                    {
                        minPupils.RemoveRange(3, minPupils.Count - 3);
                    }
                    minPupils.Insert(j, new Pupil(surname, name, sum));
                    break;
                }
            }
        }

        foreach (var pupil in minPupils)
        {
            Console.WriteLine($"{pupil.SurName} {pupil.Name} {pupil.Sum / 3.0:N2}");
        }
    }

    private void ReadNewLine(StreamReader stream)
    {
        stream.Read();
    }

    private int ReadDigit(StreamReader stream)
    {
        var digit = stream.Read() - '0';
        stream.Read();
        return digit;
    }

    private Span<char> ReadString(StreamReader stream, Span<char> buffer)
    {
        var c = 0;
        char ch;
        while((ch = (char)stream.Read()) != ' ')
        {
            buffer[c] = ch;
            c++;
        }
        return buffer[0..c];
    }
}
