namespace PokemonPocketSim;

public class Utils
{
    private static Random rng = new();
    
    public static void Shuffle<T>(IList<T> list)  
    {  
        for (var i = 0; i < rng.Next(5) + 3; i++)  
        {  
            ShuffleOnce(list);
        }  
    }
    
    private static void ShuffleOnce<T>(IList<T> list)  
    {  
        var n = list.Count;  
        while (n > 1) {  
            n--;  
            var k = rng.Next(n + 1);  
            (list[k], list[n]) = (list[n], list[k]);
        }  
    }
}