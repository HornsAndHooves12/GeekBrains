using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L5;

internal class Pupil
{
    public Pupil(ReadOnlySpan<char> surname, ReadOnlySpan<char> name, int sum)
    {
        SurName = new string(surname);
        Name = new string(name);
        Sum = sum;
    }

    public string Name;

    public string SurName;

    public int Sum;

}
