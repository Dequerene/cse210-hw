using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        int sum = 0;

        foreach (int value in numbers)
        {
            sum += value;
        }

        double average = (double)sum / numbers.Count;

        int largest = numbers[0];

        foreach (int value in numbers)
        {
            if (value > largest)
            {
                largest = value;
            }
        }

        int smallestPositive = 0;
        bool foundPositive = false;

        foreach (int value in numbers)
        {
            if (value > 0)
            {
                if (!foundPositive || value < smallestPositive)
                {
                    smallestPositive = value;
                    foundPositive = true;
                }
            }
        }

        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

        if (foundPositive)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        Console.WriteLine("The sorted list is:");

        foreach (int value in numbers)
        {
            Console.WriteLine(value);
        }
    }
}