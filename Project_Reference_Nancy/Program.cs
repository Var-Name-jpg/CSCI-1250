// Standard headers, I do this for every project
using System;
using System.Collections;
using System.Collections.Generic;

// This is a class (object) that we use to create students
public class Student {
	public string Name { get; set; }
	public int Grade { get; set; }
	public double GradeAverage { get; set; }

	// Constructor for the class
	public Student(string name, int grade, double gradeAverage) {
		Name = name;
		Grade = grade;
		GradeAverage = gradeAverage;
	}
}

// main method
public class Program {
	public static void Main(string[] args) {
		// here are your three variable types
		string name;
		int grade;
		double gradeAverage;

		int studentCount = 0;

		// Here is your 'array'
		// (tell Matt to email me or talk to me in person and I'll school him)
		List<Student> students = new List<Student>();

		// Here we are asking the user if they want to add a student
		// if they don't we just ignore everything and coninue the code
		// (which will cause an error)
		Console.WriteLine("Would you like to add a student? (y/n)");
		if (Console.ReadLine().ToLower() == "y") {
			Console.Write("Name: ");
			name = Console.ReadLine(); // Parsing things

			Console.Write("Current Grade Level: ");
			grade = int.Parse( Console.ReadLine() );

			Console.Write("Grade Average: ");
			gradeAverage = double.Parse(Console.ReadLine());

			// Calling one of our methods
			AddStudentToRecord(studentCount, name, grade, gradeAverage, students);
			studentCount++;
		}

		// Here is the second method
		PrintStudents(students);
	}

	// method 1: This takes student information as parameters and adds it to our list
	public static void AddStudentToRecord(int studentCount, string name, int grade, double gradeAverage, List<Student> students) {
		Student studentToAdd = new Student(name, grade, gradeAverage);
		students.Add(studentToAdd);
	}

	// method 2: This loops through the student list and displays all the students
	public static void PrintStudents(List<Student> list) {
		foreach (Student student in list) {
			Console.WriteLine($"Name: {student.Name}, Grade Level: {student.Grade}, Grade Average: {student.GradeAverage}");
		}
	}
}
