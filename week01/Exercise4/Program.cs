using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (number != 0)
        {            
            Console.WriteLine("Enter number (0 to finish):");
            string userNumber = Console.ReadLine();
            number = int.Parse(userNumber);

            if (number != 0)
            {
                numbers.Add(number);
            }
            else if (string.IsNullOrEmpty(userNumber))
            {
                Console.WriteLine("Please enter a number or 0 to finish:");
            }
            else
            {
                Console.WriteLine($"The sum is: {numbers.Sum()}");
                Console.WriteLine($"The average is: {numbers.Average()}");
                Console.WriteLine($"The largest number is: {numbers.Max()}");
                Console.WriteLine($"The smallest positive number is: {numbers.Where(n => n > 0).DefaultIfEmpty().Min()}");
                Console.WriteLine($"The sorted list is: {string.Join(", ", numbers.OrderBy(n => n))}");
            }
        }
    }
}