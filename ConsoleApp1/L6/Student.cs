using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L6;

internal class Student: IComparable<Student>
{
    public string lastName;
    public string firstName;
    public string university;
    public string faculty;
    public int course;
    public string department;
    public int group;
    public string city;
    public int age;
    // Создаем конструктор
    public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.university = university;
        this.faculty = faculty;
        this.department = department;
        this.course = course;
        this.age = age;
        this.group = group;
        this.city = city;
    }

    public int CompareTo(Student? other)
    {
       var result = course - other.course;
        if (result == 0)
        {
            return age - other.age;
        }
       return result;
    }
}
