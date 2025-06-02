using System;

namespace case_study_EmployeeManagement
{
   
        // 1. Base class
        public class Employee
        {
            public int EmpCode { get; set; }
            public string EmpName { get; set; }
            public string Email { get; set; }
            public string DeptName { get; set; }
            public string Location { get; set; }
        }

        // 2. Generic interface
        public interface IEmployee<T> where T : Employee
        {
            string PrintEmployeeDetails(T employee);
        }

        // 3. IFullTimeEmployee interface
        public interface IFullTimeEmployee : IEmployee<Employee>
        {
            double Basic { get; set; }
            double Hra { get; set; }
            double Da { get; set; }
            double NetSalary { get; set; }

            double CalculateSalary();
        }

        // 4. IPartTimeEmployee interface
        public interface IPartTimeEmployee : IEmployee<Employee>
        {
            double Basic { get; set; }
            double Da { get; set; }
            double NetSalary { get; set; }

            double CalculateSalary();
        }

        // 5. FullTimeEmployee class
        public class FullTimeEmployee : Employee, IFullTimeEmployee
        {
            public double Basic { get; set; }
            public double Hra { get; set; }
            public double Da { get; set; }
            public double NetSalary { get; set; }

            public double CalculateSalary()
            {
                Hra = 0.15 * Basic;
                Da = 0.10 * Basic;
                NetSalary = Basic + Hra + Da;
                return NetSalary;
            }

            public string PrintEmployeeDetails(Employee employee)
            {
                return $"Employee Details:\n" +
                       $"ID: {employee.EmpCode}\n" +
                       $"Name: {employee.EmpName}\n" +
                       $"Email: {employee.Email}\n" +
                       $"Department: {employee.DeptName}\n" +
                       $"Location: {employee.Location}\n" +
                       $"The net salary of full-time employee is: {NetSalary:C}";
            }
        }

        // 6. PartTimeEmployee class
        public class PartTimeEmployee : Employee, IPartTimeEmployee
        {
            public double Basic { get; set; }
            public double Da { get; set; }
            public double NetSalary { get; set; }

            public double CalculateSalary()
            {
                Da = 0.05 * Basic;
                NetSalary = Basic + Da;
                return NetSalary;
            }

            public string PrintEmployeeDetails(Employee employee)
            {
                return $"Employee Details:\n" +
                       $"ID: {employee.EmpCode}\n" +
                       $"Name: {employee.EmpName}\n" +
                       $"Email: {employee.Email}\n" +
                       $"Department: {employee.DeptName}\n" +
                       $"Location: {employee.Location}\n" +
                       $"The net salary of part-time employee is: {NetSalary:C}";
            }
        }

        // 7. Main Program
        class Program
        {
            static void Main(string[] args)
            {
                // a. Base Employee object (not used in display but kept for reference)
                Employee emp = new Employee
                {
                    EmpCode = 1001,
                    EmpName = "Kevin",
                    Email = "kevin@example.com",
                    DeptName = "IT",
                    Location = "Trichy"
                };

                // b. Part-Time Employee
                PartTimeEmployee emp2 = new PartTimeEmployee
                {
                    EmpCode = 2002,
                    EmpName = "John",
                    Email = "john@abc.com",
                    DeptName = "Support",
                    Location = "Chennai",
                    Basic = 10000
                };
                emp2.CalculateSalary();
                Console.WriteLine(emp2.PrintEmployeeDetails(emp2));
                Console.WriteLine(); // spacer

                // c. Full-Time Employee
                FullTimeEmployee emp3 = new FullTimeEmployee
                {
                    EmpCode = 3003,
                    EmpName = "Sara",
                    Email = "sara@abc.com",
                    DeptName = "Development",
                    Location = "Bangalore",
                    Basic = 40000
                };
                emp3.CalculateSalary();
                Console.WriteLine(emp3.PrintEmployeeDetails(emp3));
            }
        }
    }

