class Program
{
    static void Main(string[] args)
    {
        Activity activity = new Activity();

        BreathingActivity breathingActivity =
            new BreathingActivity();

        ReflectingActivity reflectingActivity =
            new ReflectingActivity();

        ListingActivity listingActivity =
            new ListingActivity();

        string option = "";

        while (option != "4")
        {
            option = activity.DisplayMenu();

            if (option == "4")
            {
                break;
            }

            List<object> baseClassData =
                activity.GetBaseClassData();

            string name =
                (string)baseClassData[0];

            string description =
                (string)baseClassData[1];

            if (name == "Breathing Activity")
            {
                breathingActivity.Run(
                    name,
                    description
                );
            }
            else if (name == "Reflecting Activity")
            {
                reflectingActivity.Run(
                    name,
                    description
                );
            }
            else if (name == "Listing Activity")
            {
                listingActivity.Run(
                    name,
                    description
                );
            }
        }

        Console.WriteLine();
        Console.WriteLine($"CONGRATS!! You completed {Activity.GetActivityCount()} activities.");
        Console.WriteLine("Exiting program...");

    }
}