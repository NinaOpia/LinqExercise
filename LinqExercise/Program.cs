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
            Console.WriteLine($"Sum of numbers: {numbers.Sum()}");
            Console.WriteLine();

            //TODO: Print the Average of numbers
            Console.WriteLine($"Avg of numbers: {numbers.Average()}");
            Console.WriteLine();

            //TODO: Order numbers in ascending order and print to the console
            var ascOrder = numbers.OrderBy(item => item);
            Console.WriteLine("Asc Order");
            foreach (var num in ascOrder)
            {
                Console.WriteLine($"Asc Order: {num}");
            }
            Console.WriteLine();

            //TODO: Order numbers in decsending order and print to the console
            var descOrder = numbers.OrderByDescending(item => item);
            Console.WriteLine("Desc Order");
            foreach (var num in descOrder)
            {
                Console.WriteLine($"Desc Order: {num}");
            }
            Console.WriteLine();

            //Or
            //Console.WriteLine("Desc Order");
            ////numbers.OrderByDescending(item => item).ToList().ForEach(Console.WriteLine);
            //Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("> 6:");
            numbers.Where(x => x > 6).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var only4 = numbers.OrderBy(num => num).Take(4);

            Console.WriteLine("Asc Take 4:");
            foreach(var num in only4)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            //numbers[4] = 16;This is the answer, but below we could also do it the LINQ way:
            numbers.SetValue(16, 4);

            Console.WriteLine("4 to Age:");
            numbers.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filteredCS = employees.Where(person => person.FirstName.ToLower().StartsWith('c')
            || person.FirstName.ToLower()[0] == 's')
                .OrderBy(name => name.FirstName);

            Console.WriteLine("C || S");
            filteredCS.ToList().ForEach(x => Console.WriteLine(x.FullName));
            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var twentySix = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);

            Console.WriteLine("> 26");
            foreach(var emp in twentySix)
            {
                Console.WriteLine($"Age: {emp.Age} Name: {emp.FullName}");
            }
            Console.WriteLine();

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sumAndYOE = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35);

            Console.WriteLine($"Sum YOE: {sumAndYOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Avg YOE: {sumAndYOE.Average(x => x.YearsOfExperience)}");
            Console.WriteLine();

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Ishi", "Jonah", 16, 3)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.FullName);
            }

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
