using System;

class Program
{
    static void Main(string[] args)
    {
        string option = "";

        while (option != "4")
        {
            Activity activity = new Activity();

            option = activity.DisplayMenu();

            if (option == "4")
            {
                break;
            }

            List<object> baseClassData = activity.GetBaseClassData();

            string name = (string)baseClassData[0];
            string description = (string)baseClassData[1];

            if (name == "Breathing Activity")
            {
                BreathingActivity breathingActivity =
                    new BreathingActivity();

                breathingActivity.Run(name, description);
            }
            else if (name == "Reflecting Activity")
            {
                ReflectingActivity reflectingActivity =
                    new ReflectingActivity();

                reflectingActivity.Run(name, description);
            }
            else if (name == "Listing Activity")
            {
                ListingActivity listingActivity =
                    new ListingActivity();

                listingActivity.Run(name, description);
            }

            Console.Clear();
        }

        Console.WriteLine(
            $"You completed {Activity.GetActivityCount()} activities."
        );

        Console.WriteLine("Goodbye!");
    }
}