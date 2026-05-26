using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity / Exceeding Requirements:
        // I added a ScriptureLibrary class that stores multiple scriptures and randomly
        // chooses one scripture for the user to memorize each time the program runs.
        // I also made the program hide only words that are not already hidden,
        // instead of randomly choosing words that may already be hidden.

        ScriptureLibrary library = new ScriptureLibrary();

        library.AddScripture(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"
        ));

        library.AddScripture(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart and lean not unto thine own understanding in all thy ways acknowledge him and he shall direct thy paths"
        ));

        library.AddScripture(new Scripture(
            new Reference("Ether", 12, 27),
            "And if men come unto me I will show unto them their weakness I give unto men weakness that they may be humble"
        ));

        Scripture scripture = library.GetRandomScripture();

        string userInput = "";

        while (userInput.ToLower() != "quit")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}