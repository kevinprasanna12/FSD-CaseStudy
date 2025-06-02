using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementList
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int choice;
            int idCounter = 1;

            do
            {
                Console.WriteLine("\n--- Student Management Menu ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student by Name");
                Console.WriteLine("4. Remove Student by Name");
                Console.WriteLine("5. Count Total Students");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                bool isValid = int.TryParse(Console.ReadLine(), out choice);
                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter student name: ");
                        string name = Console.ReadLine();
                        students.Add(new Student { Id = idCounter++, Name = name });
                        Console.WriteLine("Student added successfully.");
                        break;

                    case 2:
                        Console.WriteLine("\nAll Students:");
                        foreach (var student in students)
                        {
                            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
                        }
                        break;

                    case 3:
                        Console.Write("Enter name to search: ");
                        string searchName = Console.ReadLine();
                        var found = students.FirstOrDefault(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
                        if (found != null)
                            Console.WriteLine($"Found: ID={found.Id}, Name={found.Name}");
                        else
                            Console.WriteLine("Student not found.");
                        break;

                    case 4:
                        Console.Write("Enter name to remove: ");
                        string removeName = Console.ReadLine();
                        var toRemove = students.FirstOrDefault(s => s.Name.Equals(removeName, StringComparison.OrdinalIgnoreCase));
                        if (toRemove != null)
                        {
                            students.Remove(toRemove);
                            Console.WriteLine("Student removed.");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;

                    case 5:
                        Console.WriteLine($"Total number of students: {students.Count}");
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 6);
        }
    }
}
