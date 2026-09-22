using System;
using System.Collections.Generic;

// EXCEEDED REQUIREMENTS
// I exceeded the requirements adding a ScriptureGenerator class that generates random scriptures from a predefined list.
class Program
{
    static void Main(string[] args)
    {
        ScriptureGenerator generator = new ScriptureGenerator();

        Scripture scripture = generator.GenerateScripture();

        scripture.Display();

        Console.WriteLine("Press Enter to hide words OR type 'quit' to exit the program.");
        string input = Console.ReadLine() ?? "";

        if (input.ToLower() == "quit")
        {
            return;
        }

        while (true)
        {
            scripture.HideRandomWords(3);

            Console.Clear();
            scripture.Display();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Exiting the program.");
                break;
            }

            Console.WriteLine("Press Enter to hide more words OR type 'quit' to exit the program.");
            input = Console.ReadLine() ?? "";

            if (input.ToLower() == "quit")
            {
                break;
            }
        }
    }
}