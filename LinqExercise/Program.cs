using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            int sum = numbers.Sum();
            Console.WriteLine($"Sum: {sum}");

            //TODO: Print the Average of numbers
            double average = numbers.Average();
            Console.WriteLine($"Average: {average}");

            //TODO: Order numbers in ascending order and print to the console
            var ascending = numbers.OrderBy(n => n);
            Console.WriteLine("Numbers in ascending order");
            foreach (var num in ascending)
            {
                Console.WriteLine(num);
            }

            //TODO: Order numbers in descending order and print to the console
            var descending = numbers.OrderByDescending(n => n);
            Console.WriteLine("Numbers in descending order");
            foreach(var num in descending)
            {
                Console.WriteLine(num);
            }

            //TODO: Print to the console only the numbers greater than 6
            var greaterThenSix = numbers.Where(n => n > 6);
            Console.WriteLine("Numbers greater than 6");
            foreach(var num in greaterThenSix)
            {
                Console.WriteLine(num);
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Array.Sort(numbers);
            Console.WriteLine("First 4 numbers in ascending order");
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 40;
            var newDescending = numbers.OrderByDescending(n => n);
            Console.WriteLine("Numbers in descending order");
            foreach (var num in newDescending)
            {
                Console.WriteLine(num);
            }


            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var csEmployees = employees
                .Where(e => e.FirstName.StartsWith("C") || e.FirstName.StartsWith("S"))
                .OrderBy(e => e.FirstName);
            Console.WriteLine("Employees with First Name starting with 'C' or 'S':");
            foreach(var employee in csEmployees)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var over26Employees = employees
                .Where(e => e.Age > 26)
                .OrderBy(e => e.Age)
                .ThenBy(e => e.FirstName);
            Console.WriteLine("Employees over the age of 26");
            foreach(var employee in over26Employees)
            {
                Console.WriteLine($"{employee.FullName}, Age: {employee.Age}");
            }
            Console.WriteLine();


            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sumYOE = employees
                .Where(e => e.YearsOfExperience <= 10 && e.Age > 35)
                .Sum(e => e.YearsOfExperience);
            Console.WriteLine("Sum of Years of Experience");
            Console.WriteLine(sumYOE);
            Console.WriteLine();

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var averageYOE = employees
                .Where(e => e.YearsOfExperience <= 10 && e.Age > 35)
                .Average(e => e.YearsOfExperience);
            Console.WriteLine("Average of Years of Experiece");
            Console.WriteLine(averageYOE);
            Console.WriteLine();

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Jonathan", "Borja", 40, 10)).ToList();

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
