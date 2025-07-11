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

            var sumNumbers = numbers.Sum(x => x);

            Console.WriteLine(sumNumbers.ToString());

            //TODO: Print the Average of numbers

            var averageNumbers = numbers.Average(x => x);

            Console.WriteLine(averageNumbers.ToString());

            //TODO: Order numbers in ascending order and print to the console

            var ascendingNumbers = numbers.OrderBy(x => x);

            foreach (var num in ascendingNumbers)
            {
                Console.WriteLine(num.ToString());
            }

            //TODO: Order numbers in descending order and print to the console

            var descendingNumbers = numbers.OrderByDescending(x => x);

            foreach (var num in descendingNumbers)
            {
                Console.WriteLine(num.ToString());
            }

            //TODO: Print to the console only the numbers greater than 6

            var numbersAboveSix = numbers.Where(x => x > 6); 

            foreach ( var num in numbersAboveSix)
            {
                Console.WriteLine(num.ToString());
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            var printFourNumbers = numbers.OrderBy(x=>x).Take(4);

            foreach (var num in printFourNumbers)
            {
                Console.WriteLine(num.ToString());
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            numbers[4] = 31; 

            var myAgeInNumbers = numbers.OrderByDescending(x => x);

            foreach (var num in myAgeInNumbers)
            { 
                Console.WriteLine(num.ToString()); 
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            var firstNames = employees.Where(x => x.FirstName.StartsWith("C") || x.FirstName.StartsWith("S")).OrderBy(x => x.FirstName);

            foreach (var employee in firstNames)
            {
                Console.Write(employee.FullName);
                Console.WriteLine();
            }

            Console.WriteLine(); 
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            var overAgeTwentySix = employees
                .Where(x => x.Age > 26)
                .OrderBy(x => x.Age)
                .ThenBy(x => x.FirstName); 

            foreach (var age in overAgeTwentySix)
            {
                Console.WriteLine($"{age.FullName}, Age: {age.Age}");
                Console.WriteLine();
            }

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var yearsOfExperienceSum = employees
                .Where(x => x.YearsOfExperience <= 10 && x.Age > 35)
                .Sum(x => x.YearsOfExperience);

            Console.WriteLine($"Total YOE: {yearsOfExperienceSum}");

            Console.WriteLine();
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var averageYearsOfExperience = employees
                .Where(x => x.YearsOfExperience <= 10 && x.Age > 35)
                .Average(x => x.YearsOfExperience);

            Console.WriteLine($"Average YOE: {averageYearsOfExperience}") ;

            //TODO: Add an employee to the end of the list without using employees.Add()

            var newEmployeeList = employees
                .Append( new Employee("Michael", "Rose", 45, 12)) 
                .ToList(); 


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
