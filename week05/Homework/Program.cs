using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("John Doe", "Mathematics");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WrittingAssignment writtingAssignment = new WrittingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writtingAssignment.GetWritingInformation());
    }
}