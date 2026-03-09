// 3 data types
// array
// foreach
// 2 methods

using System;
using System.Collections;
using System.Collections.Generic;

public class Student {
	public string Name { get; set; }
	public int Grade { get; set; }
	public double GradeAverage { get; set; }

	public Student(string name, int grade, double gradeAverage) {
		Name = name;
		Grade = grade;
		GradeAverage = gradeAverage;
	}
}

public class Program {
	public static void Main(string[] args) {
		string name;
		int grade;
		double gradeAverage;

		int studentCount = 0;

		List<Student> students = new List<Student>();

		Console.WriteLine("Would you like to add a student? (y/n)");
		if (Console.ReadLine().ToLower() == "y") {
			Console.Write("Name: ");
			name = Console.ReadLine();

			Console.Write("Current Grade Level: ");
			grade = int.Parse( Console.ReadLine() );

			Console.Write("Grade Average: ");
			gradeAverage = double.Parse(Console.ReadLine());

			AddStudentToRecord(studentCount, name, grade, gradeAverage, students);
			studentCount++;
		}

		PrintStudents(students);
	}

	// method 1
	public static void AddStudentToRecord(int studentCount, string name, int grade, double gradeAverage, List<Student> students) {
		Student studentToAdd = new Student(name, grade, gradeAverage);
		students.Add(studentToAdd);
	}

	// method 2
	public static void PrintStudents(List<Student> list) {
		foreach (Student student in list) {
			Console.WriteLine($"Name: {student.Name}, Grade Level: {student.Grade}, Grade Average: {student.GradeAverage}");
		}
	}
}
