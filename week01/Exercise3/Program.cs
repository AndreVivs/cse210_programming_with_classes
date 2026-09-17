using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumberInt = randomGenerator.Next(1,101);

        int guessNumberInt;
        int guessCountInt = 0;

        do
        {
            Console.WriteLine("What is your guess? ");
            guessNumberInt = int.Parse(Console.ReadLine());
            guessCountInt++;
            
            if (guessNumberInt < magicNumberInt)
            {
                Console.WriteLine("Higher");  
            }
            else if (guessNumberInt > magicNumberInt)
            {
                Console.WriteLine("Lower"); 
            }
            else
            {
                Console.WriteLine("You guess it!"); 
                Console.WriteLine($"It took you {guessCountInt} guesses.");
            }
        } while (guessNumberInt != magicNumberInt);
    }
}