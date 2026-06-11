using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public abstract void Run();

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = GetValidDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }

    private int GetValidDuration()
    {
        int duration = 0;
        bool isValid = false;

        while (!isValid)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out duration) && duration > 0)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Please enter a positive number.");
            }
        }

        return duration;
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>()
        {
            "|", "/", "-", "\\"
        };

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];

            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected int GetRemainingSeconds(DateTime endTime)
    {
        TimeSpan remainingTime = endTime - DateTime.Now;
        int remainingSeconds = (int)Math.Ceiling(remainingTime.TotalSeconds);

        if (remainingSeconds < 0)
        {
            remainingSeconds = 0;
        }

        return remainingSeconds;
    }
}