namespace PokemonPocketSim;

public class Logger
{
    public static bool verbose;
    
    public static void Log(string message)
    {
        if (verbose)
        {
            Console.WriteLine(message);
        }
    }
}