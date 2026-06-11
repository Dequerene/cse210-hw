using System;
using System.Threading;

/*
Creativity and Exceeding Requirements:
1. I added an ActivityLogger class that saves completed activities to a file named mindfulness_log.txt.
2. I added a menu option that lets the user view the activity log.
3. I used logic in the ReflectionActivity so prompts and questions are not repeated until all options have been used once in that session.
*/

class Program
{
    static void Main(string[] args)
    {
        ActivityLogger logger = new ActivityLogger("mindfulness_log.txt");

        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                Activity activity = new BreathingActivity();
                RunActivity(activity, logger);
            }
            else if (choice == "2")
            {
                Activity activity = new ReflectionActivity();
                RunActivity(activity, logger);
            }
            else if (choice == "3")
            {
                Activity activity = new ListingActivity();
                RunActivity(activity, logger);
            }
            else if (choice == "4")
            {
                logger.DisplayLogSummary();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Thread.Sleep(2000);
            }
        }
    }

    static void RunActivity(Activity activity, ActivityLogger logger)
    {
        activity.Run();
        logger.LogActivity(activity.GetName(), activity.GetDuration());
    }
}