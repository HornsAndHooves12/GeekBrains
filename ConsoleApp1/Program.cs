using ConsoleApp1.Common.Interfaces;
using ConsoleApp1.L1;
using ConsoleApp1.L2;
using ConsoleApp1.L3;
using ConsoleApp1.L4;

namespace ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        var lessons = new List<IGeekBrains> {
                new Lesson1(),
                new Lesson2(),
                new Lesson3(),
                new Lesson4(),
            };
        lessonPosition(lessons).Test();
    }

    private static IGeekBrains lessonPosition(List<IGeekBrains> lessons)
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"Выберите урок от 1 до {lessons.Count}");
                for (int i = 0; i < lessons.Count; i++)
                {
                    var lesson = lessons[i];
                    Console.WriteLine($"{i + 1} {lesson.LessonName}");
                }
                var number = int.Parse(Console.ReadLine());
                Console.Clear();
                return lessons[number - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Все херня, давай по новому");
            }
        }
    }
}