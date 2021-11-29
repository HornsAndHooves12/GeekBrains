using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L4;

internal class StaticClass
{

    public static int SolveCount(int[] arr)
    {
        var count = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if ((arr[i - 1] % 3 == 0) != (arr[i] % 3 == 0))
            {
                Console.WriteLine(arr[i - 1] + " " + arr[i]);
                count++;
            }
        }
        return count;
    }
    public static int[] ReadFile(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException(filename);  
        }
        using var stream = new StreamReader(filename);
        string line;
        var full = new int[1000];
        var count = 0;  
        while ((line = stream.ReadLine()) != null)
        {
            full[count++] = int.Parse(line);
        }
        var arr = new int[count];
        Array.Copy(full, 0, arr, 0, count); 
        return arr;
    }

}
