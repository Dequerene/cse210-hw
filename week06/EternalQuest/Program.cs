public class Program
{
    public static void Main(string[] args)
    {
        // Creativity: I added a level and rank system based on the user's score.
        // This goes beyond the core requirements by adding more gamification.
        // As the user earns more points, the program displays a higher level and rank.

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}