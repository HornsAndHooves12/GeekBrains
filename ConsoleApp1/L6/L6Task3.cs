using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L6;

internal class L6Task3
{

    static int AgeSort(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
    {

        return st1.age - st2.age;          // Сравниваем две строки
    }
    public static void MainTest()
    {
        var numOf5and6CourseStudents = 0;
        var numOfSudentsOnCourse = new int[6];
        List<Student> list = new List<Student>();                             // Создаем список студентов
        DateTime dt = DateTime.Now;
        StreamReader sr = new StreamReader("L6\\students.csv");
        while (!sr.EndOfStream)
        {
            try
            {
                string[] s = sr.ReadLine().Split(';');
                // Добавляем в список новый экземпляр класса Student
                var student = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]);
                list.Add(student);
                // Одновременно подсчитываем количество бакалавров и магистров
                if (student.course == 5 || student.course ==6 ) numOf5and6CourseStudents++;
                if (student.age >= 18 && student.age <=20) numOfSudentsOnCourse[student.course - 1]++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                // Выход из Main
                if (Console.ReadKey().Key == ConsoleKey.Escape) return;
            }
        }
        sr.Close();
        list.Sort(new Comparison<Student>(AgeSort));
        Console.WriteLine("Всего студентов:" + list.Count);

        Console.WriteLine("Всего на 5 и 6 курсе:" + numOf5and6CourseStudents);
        Console.WriteLine("В возврасте от 18 до 20 лет всего учатся:");
        for (int i = 0; i < numOfSudentsOnCourse.Length; i++)
        {
            Console.WriteLine($"на {i + 1} курсе учатся {numOfSudentsOnCourse[i]} студентов");
        }
        
        for (int i = 0; i < list.Count; i++)
        {
            Student student = list[i];
            Console.WriteLine($"{i + 1} имя - {student.firstName} {student.lastName}: возвраст - {student.age}");
        }

     

        for (int i = 0; i < list.Count; i++)
        {
            Student student = list[i];
            Console.WriteLine($"{i + 1} имя - {student.firstName} {student.lastName}: возвраст - {student.age}: курс - {student.course}");
        }
        Console.WriteLine(DateTime.Now - dt);
        Console.ReadKey();
    }

}


