using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Common;

internal class Methods
{

    public static void Print(string text, int x = 0, int y = 0)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(text);
    }


    public static void Pause(string text)
    {
        Console.WriteLine(text);
    }

}