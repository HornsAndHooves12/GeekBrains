using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L1
{
    internal class Lesson1 : IGeekBrains
    {
        public string LessonName => "Lesson 1";

        public void Test()
        {
            // (имя, фамилия, возраст, рост, вес)
            Console.Write("Имя: ");
            var name = Console.ReadLine();
            Console.Write("Фамилия: ");
            var lastName = Console.ReadLine();
            Console.Write("Возраст: ");
            var age = Console.ReadLine();
            Console.Write("Рост: ");
            var height = Console.ReadLine();
            Console.Write("Вес: ");
            var weight = Console.ReadLine();

            Console.WriteLine(name + " " + lastName + " " + age + " " + height + " " + weight);
            Console.WriteLine($"{name} {lastName} {age} {height} {weight}");
            Console.WriteLine("{0} {1} {2} {3} {4}", name, lastName, age, height, weight);

            //////////////////////////////////////////////////////////////


        }

        

    }
}
