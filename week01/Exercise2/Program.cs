using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int gradeNumber = int.Parse(grade);
        string letter;
        string letterSimbol;
        int lastDigit = gradeNumber % 10;

        if (gradeNumber >= 90)
        {
            letter = "A";
        }
        else if (gradeNumber >= 80)
        {
            letter = "B";
 
        }
        else if (gradeNumber >= 70)
        {
            letter = "C";            
        }
        else if (gradeNumber >= 60)
        {
            letter = "D";           
        }
        else
        {
            letter = "F";          
        }

        // Stretch Challenge
        if (gradeNumber < 60)
        {
            letterSimbol = letter;  
        }
        else if (lastDigit >= 7)
        {
            letterSimbol = $"{letter}+";
        }
        else if (lastDigit < 3)
        {
            letterSimbol = $"{letter}-";   
        }
        else
        {
            letterSimbol = letter;
        }

        Console.WriteLine($"Your grade is {letterSimbol}.");


        if (gradeNumber >= 60)
        {
            Console.WriteLine("Congratulations!");
        }
        else
        {
            Console.WriteLine("Keep trying, you can do it!");
        }
    }
}