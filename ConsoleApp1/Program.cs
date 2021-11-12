using ConsoleApp1.Common.Interfaces;
using ConsoleApp1.L1;
using ConsoleApp1.L2;

namespace ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        var lessons = new List<IGeekBrains> {
                new Lesson1(),
                new Lesson2(),
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

    private static void dododo()
    {
        var a = new Dictionary<string, object>();
        a.ExtendyaNeZnau();
    }

  


}
public static class Exstentions
{
    public static void ExtendyaNeZnau(this Dictionary<String, object> imya)
    {
        imya["vasu"] = "petya";
    }
}