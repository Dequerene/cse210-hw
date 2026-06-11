using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        )
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");

            int breatheInTime = Math.Min(4, GetRemainingSeconds(endTime));
            ShowCountdown(breatheInTime);

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Breathe out...");

            int breatheOutTime = Math.Min(6, GetRemainingSeconds(endTime));
            ShowCountdown(breatheOutTime);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}