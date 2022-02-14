using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L5;

internal static class Message
{

    private static readonly char[] separators = { '.', ',', '?', '!', ':', ';', ' ', };

    public static void PrintWordWithNLetter(string text, int n)
    {
        var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            if (word.Length <= n)
            {
                Console.WriteLine(word);
            }
        }
    }

    public static void PrintWordWithoutLastLetter(string text, char c)
    {
        var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            if (word[word.Length - 1] != c)
            {
                Console.WriteLine(word);
            }
        }

    }

    public static void PrintWordWithLongestLength(string text)
    {
        var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        if (!words.Any())
        {
            Console.WriteLine("сообщение пустое");
            return;
        }
        var biggestWord = words.First();
        foreach (var word in words)
        {
            if (biggestWord.Length < word.Length)
            {
                biggestWord = word;
            }
        }
        Console.WriteLine($"biggestWord - {biggestWord}");

    }

    public static void PrintLongestWords(string text)
    {
        var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        if (!words.Any())
        {
            Console.WriteLine(" ");
            return;
        }

        var longest = words.Select(word => word.Length).Max();

        var stringBuilder = new StringBuilder();
        foreach (var word in words.Where(w => w.Length == longest))
        {
            stringBuilder.Append(word);
            stringBuilder.Append(" ");
        }
        Console.WriteLine(stringBuilder.ToString());
    }
}
