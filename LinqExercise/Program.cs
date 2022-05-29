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
            Console.WriteLine(sum);
            Console.WriteLine("------------------");

            //TODO: Print the Average of numbers
            int average = (int)numbers.Average();
            Console.WriteLine(average);

            Console.WriteLine("------------------");

            //TODO: Order numbers in ascending order and print to the console
            var ascendingOrder = numbers.OrderBy(item => item);
            foreach (var number in ascendingOrder)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("------------------");
            //TODO: Order numbers in decsending order adn print to the console
            var decendingOrder = numbers.OrderByDescending(item => item);
            foreach(var number in decendingOrder)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("------------------");
            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(number => number > 6);
            foreach(var number in greaterThanSix)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("------------------");

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            foreach(var num in ascendingOrder.Take(4))
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("------------------");
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 26;
            var decOrder = numbers.OrderByDescending(item => item);
            foreach (var number in decOrder)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------------");
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S
            //and order this in acesnding order by FirstName.
            var SFirstName = employees.Where(person => person.FirstName.ToLower().StartsWith('c') || person.FirstName.ToLower()[0] == 's')
                            .OrderBy(person => person.FirstName);
            var CFirstName = employees.FindAll(name => name.FirstName.ToLower()[0] == 'c' || name.FirstName.ToLower()[0] == 's')
                                .OrderBy(name => name.FirstName);

            Console.WriteLine("------------------");
            foreach (var person in SFirstName)
            {
                Console.WriteLine(person.FullName);
            }
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first
            //and then by FirstName in the same result.
            var overTwentySix = employees.Where(y => y.Age > 26).OrderByDescending(y => y.Age).ThenBy(y => y.FirstName);
            foreach(var number in overTwentySix)
            {
                Console.WriteLine($"{number.FullName}, {number.Age}");
            }
            Console.WriteLine("------------------");

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var yearsOfService = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            foreach(var yearOfExperience in yearsOfService)
            {
                Console.WriteLine($"Sum of years of service: {yearsOfService.Sum(x => x.YearsOfExperience)}");
                Console.WriteLine($"Average of years of service:{yearsOfService.Average(x => x.YearsOfExperience)}");
            }

            Console.WriteLine("------------------");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Kayla", "Finelstein", 26, 1)).ToList();
            foreach(var name in employees)
            {
                Console.WriteLine(name.FullName);
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
