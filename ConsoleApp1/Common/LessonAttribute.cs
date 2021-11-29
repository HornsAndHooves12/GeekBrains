using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Common;

[AttributeUsage(AttributeTargets.Class)]
internal class LessonAttribute: Attribute
{
    public LessonAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
