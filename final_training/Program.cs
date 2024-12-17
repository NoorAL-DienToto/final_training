using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    //بيانات الطالب
    public int Id { get; set; }
    public string Name { get; set; }
    public double FirstExam { get; set; }
    public double SecondExam { get; set; }

    public string Grade { get; set; }

    public double AverageScore => (FirstExam + SecondExam) / 2;
    public void CalculateGrade()
    {
        if (AverageScore < 60)
            Grade = "راسب";
        else if (AverageScore < 75)
            Grade = "جيد";
        else if (AverageScore < 90)
            Grade = "جيد جدا";
        else
            Grade = "ممتاز";
    }
}

class Program
{
    //الفرز
    static void QuickSort(List<Student> students, int left, int right)
    {
        int i = left, j = right;
        double count = students[(left + right) / 2].AverageScore;

        while (i <= j)
        {
            while (students[i].AverageScore < count) i++;
            while (students[j].AverageScore > count) j--;
            if (i <= j)
            {
                var temp = students[i];
                students[i] = students[j];
                students[j] = temp;
                i++;
                j--;
            }
        }

        if (left < j) QuickSort(students, left, j);
        if (i < right) QuickSort(students, i, right);
    }

    static void Main(string[] args)

    //ادخال البيانات
    {
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "noor", FirstExam = 70, SecondExam = 80 },
            new Student { Id = 2, Name = "ahmad", FirstExam = 50, SecondExam = 60 },
            new Student { Id = 3, Name = "sara", FirstExam = 90, SecondExam = 95 },
            new Student { Id = 4, Name = "khaled", FirstExam = 85, SecondExam = 88 }
        };

        foreach (var student in students)
        {
            student.CalculateGrade();
        }

        QuickSort(students, 0, students.Count - 1);

        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Average Score: {student.AverageScore}, Grade: {student.Grade}");
        }
    }
}
