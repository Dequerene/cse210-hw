using System;
using System.IO;

public class ActivityLogger
{
    private string _fileName;

    public ActivityLogger(string fileName)
    {
        _fileName = fileName;
    }

    public void LogActivity(string activityName, int duration)
    {
        string logEntry = $"{DateTime.Now}: Completed {activityName} for {duration} seconds";
        File.AppendAllText(_fileName, logEntry + Environment.NewLine);
    }

    public void DisplayLogSummary()
    {
        Console.Clear();
        Console.WriteLine("Activity Log");
        Console.WriteLine("============");
        Console.WriteLine();

        if (!File.Exists(_fileName))
        {
            Console.WriteLine("No activities have been completed yet.");
        }
        else
        {
            string[] lines = File.ReadAllLines(_fileName);

            Console.WriteLine($"Total activities completed: {lines.Length}");
            Console.WriteLine();

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press enter to return to the menu.");
        Console.ReadLine();
    }
}