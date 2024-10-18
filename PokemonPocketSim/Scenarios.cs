namespace PokemonPocketSim;

public class Scenario
{
    public string name = "";
    public List<Card> deck = [];
    public Player? Player;
}

public class Scenarios
{
    public static Scenario PikachuExRaichuVoltorbSecond = new()
    {
        name = "Pikachu Ex with Raichu and Voltorb going second",
        deck = Decks.PikachuExRaichuVoltorb,
        Player = new PikachuPlayerSecond(),
    };
    
    public static Scenario PikachuExRaichuVoltorbFirst = new()
    {
        name = "Pikachu Ex with Raichu and Voltorb going first",
        deck = Decks.PikachuExRaichuVoltorb,
        Player = new PikachuPlayerFirst(),
    };
    
    public static Scenario SecondPlaceGoingFirst = new()
    {
        name = "Second place deck going first",
        deck = Decks.SecondPlace,
        Player = new PikachuPlayerFirst(),
    };
    
    public static Scenario SecondPlaceGoingSecond = new()
    {
        name = "Second place deck going second",
        deck = Decks.SecondPlace,
        Player = new PikachuPlayerSecond(),
    };
    
    public static Scenario FourthPlaceGoingFirst = new()
    {
        name = "Fourth place deck going first",
        deck = Decks.FourthPlace,
        Player = new PikachuPlayerFirst(),
    };
    
    public static Scenario FourthPlaceGoingSecond = new()
    {
        name = "Fourth place deck going second",
        deck = Decks.FourthPlace,
        Player = new PikachuPlayerSecond(),
    };
    
    public static Scenario FifthPlaceGoingFirst = new()
    {
        name = "Fifth place deck going first",
        deck = Decks.FifthPlace,
        Player = new PikachuPlayerFirst(),
    };
    
    public static Scenario FifthPlaceGoingSecond = new()
    {
        name = "Fifth place deck going second",
        deck = Decks.FifthPlace,
        Player = new PikachuPlayerSecond(),
    };
}