using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        Fraction fraction1 = new Fraction(6);
        Fraction fraction2 = new Fraction(1,3);

        fraction.Display();
        fraction1.Display();
        fraction2.Display();

        fraction.SetTopNumerator(3);
        Console.WriteLine($"Top Numerator: {fraction.GetTopNumerator()}");

        fraction1.SetBottomDenominator(2);
        Console.WriteLine($"Bottom Denominator: {fraction1.GetBottomDenominator()}");

        Console.WriteLine($"Using Get & Set Methods:");

        fraction.Display();
        fraction1.Display();

        Console.WriteLine($"Using GetFractionString Method: {fraction2.GetFractionString()}");
        Console.WriteLine($"Using GetDecimalValue Method: {fraction2.GetDecimalValue()}");
   }

}