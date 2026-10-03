using System;

class Program
{
    static void Main(string[] args)
    {
        Activity activity = new Activity();
        activity.DisplayMenu();
        List<object> baseClassData = activity.GetBaseClassData();
        string name = (string)baseClassData[0];
        string description = (string)baseClassData[1];
        if (name == "Breathing Activity")
        {
            BreathingActivity breathingActivity = new BreathingActivity();
            breathingActivity.Run(name, description);
        }
        else if (name == "Reflecting Activity")
        {
            ReflectingActivity reflectingActivity = new ReflectingActivity();
            reflectingActivity.Run(name, description);
        }
        else if (name == "Listing Activity")
        {
            // ListingActivity listingActivity = new ListingActivity();
            // listingActivity.Run();
        }
        else if (name == "Quit")
        {
            Console.WriteLine(baseClassData[0]);
            return;
        }
    }
}