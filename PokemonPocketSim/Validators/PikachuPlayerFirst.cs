namespace PokemonPocketSim;

public class PikachuPlayerFirst : PikachuPlayerSecond
{
    public PikachuPlayerFirst()
    {
        playTurns = new List<Func<List<Card>, List<Card>, bool>>();
        playTurns.Add(Turn0);
        playTurns.Add(Turn1WithoutEnergy);
        for (int i = 0; i < 18; i++)
        {
            playTurns.Add(Turn2);            
        }
    }
}