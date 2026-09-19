using System;

//I exceeded the requirements by implementing JSON file storage using System.Text.Json instead of a basic text file.
//The program can serialize journal entries to JSON and deserialize them back into Entry objects when loading.
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        string option = "";

        while (option != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Please select an option from the menu below:");
            Console.WriteLine("1. Create a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save entries to a file");
            Console.WriteLine("4. Load entries from a file");
            Console.WriteLine("5. Exit");

            Console.Write("> ");
            option = Console.ReadLine() ?? "";

            if (option == "1")
            {
                Entry entry = new Entry();

                entry.WriteEntry();

                if (entry.HasResponse())
                {
                    journal.AddEntry(entry);
                }
            }
            else if (option == "2")
            {
                journal.DisplayAll();
            }
            else if (option == "3")
            {
                Console.Write("Enter the file name (example: journal.json): ");
                string fileName = Console.ReadLine() ?? "";

                journal.SaveToFile(fileName);

                Console.WriteLine("Journal saved successfully.");
            }
            else if (option == "4")
            {
                Console.Write("Enter the file name (example: journal.json): ");
                string fileName = Console.ReadLine() ?? "";

                journal.LoadFromFile(fileName);

                Console.WriteLine("Journal loaded successfully.");
            }
            else if (option == "5")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }
}