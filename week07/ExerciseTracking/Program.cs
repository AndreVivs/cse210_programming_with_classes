
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Workout> activities = new()
        {
            new Running(new DateTime(2026, 10, 14), 30, 5.0),
            new Cycling(new DateTime(2026, 10, 14), 45, 20.0),
            new Swimming(new DateTime(2026, 10, 14), 30, 20)
        };

        foreach (Workout activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
