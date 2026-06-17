using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = GetIntInput();
            Console.WriteLine();

            if (choice == 1)
            {
                CreateGoal();
            }
            else if (choice == 2)
            {
                ListGoalDetails();
            }
            else if (choice == 3)
            {
                SaveGoals();
            }
            else if (choice == 4)
            {
                LoadGoals();
            }
            else if (choice == 5)
            {
                RecordEvent();
            }
            else if (choice == 6)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        int level = (_score / 1000) + 1;
        string rank = GetRank();

        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level: {level}");
        Console.WriteLine($"Rank: {rank}");
    }

    private string GetRank()
    {
        if (_score >= 5000)
        {
            return "Eternal Champion";
        }
        else if (_score >= 3000)
        {
            return "Quest Master";
        }
        else if (_score >= 1000)
        {
            return "Goal Achiever";
        }
        else
        {
            return "Beginner";
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        int goalType = GetIntInput();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = GetIntInput();

        if (goalType == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
            Console.WriteLine("Simple goal created successfully.");
        }
        else if (goalType == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
            Console.WriteLine("Eternal goal created successfully.");
        }
        else if (goalType == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = GetIntInput();

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = GetIntInput();

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            Console.WriteLine("Checklist goal created successfully.");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int choice = GetIntInput();

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        Goal selectedGoal = _goals[choice - 1];

        int pointsEarned = selectedGoal.RecordEvent();
        _score += pointsEarned;

        if (pointsEarned > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("This goal is already complete, so no points were added.");
        }

        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            int colonIndex = lines[i].IndexOf(":");

            if (colonIndex == -1)
            {
                continue;
            }

            string goalType = lines[i].Substring(0, colonIndex);
            string goalData = lines[i].Substring(colonIndex + 1);

            string[] details = goalData.Split("|");

            string name = details[0];
            string description = details[1];
            int points = int.Parse(details[2]);

            if (goalType == "SimpleGoal")
            {
                bool isComplete = bool.Parse(details[3]);
                _goals.Add(new SimpleGoal(name, description, points, isComplete));
            }
            else if (goalType == "EternalGoal")
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                int target = int.Parse(details[3]);
                int bonus = int.Parse(details[4]);
                int amountCompleted = int.Parse(details[5]);

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private int GetIntInput()
    {
        string input = Console.ReadLine();
        int number;

        while (!int.TryParse(input, out number))
        {
            Console.Write("Please enter a valid number: ");
            input = Console.ReadLine();
        }

        return number;
    }
}