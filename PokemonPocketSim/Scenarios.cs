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
        name = "Second place deck by Spotted going first",
        deck = Decks.SpottedSecondPlace,
        Player = new PikachuPlayerFirst(),
    };
    
    public static Scenario SecondPlaceGoingSecond = new()
    {
        name = "Second place deck by Spotted going second",
        deck = Decks.SpottedSecondPlace,
        Player = new PikachuPlayerSecond(),
    };
    
    public static Scenario FourthPlaceGoingFirst = new()
    {
        name = "Fourth place deck by AlphaWolf going first",
        deck = Decks.AlphaWolfFourthPlace,
        Player = new PikachuPlayerFirst(),
    };
    
    public static Scenario FourthPlaceGoingSecond = new()
    {
        name = "Fourth place deck by AlphaWolf going second",
        deck = Decks.AlphaWolfFourthPlace,
        Player = new PikachuPlayerSecond(),
    };
    
    public static Scenario FifthPlaceGoingFirst = new()
    {
        name = "Fifth place deck by Sera going first",
        deck = Decks.SeraFifthPlace,
        Player = new PikachuPlayerFirst(),
    };
    
    public static Scenario FifthPlaceGoingSecond = new()
    {
        name = "Fifth place deck by Sera going second",
        deck = Decks.SeraFifthPlace,
        Player = new PikachuPlayerSecond(),
    };
    
    public static Scenario EighthPlaceGoingFirst = new()
    {
        name = "Eighth place deck by Ant going first",
        deck = Decks.AntEighthPlace,
        Player = new PikachuPlayerFirst(),
    };
    
    public static Scenario EighthPlaceGoingSecond = new()
    {
        name = "Eighth place deck by Ant going second",
        deck = Decks.AntEighthPlace,
        Player = new PikachuPlayerSecond(),
    };
}