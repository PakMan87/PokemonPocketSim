namespace PokemonPocketSim;

public class Scenario
{
    public string name = "";
    public List<Card> deck = [];
    public Player? Player;
}

public class Scenarios
{
    public static Scenario EightBasicsWithElectrodeSecond = new()
    {
        name = "8 Basics with Electrode going second",
        deck = Decks.EightBasicsWithElectrode,
        Player = new PikachuPlayerSecond(),
    };
    
    public static Scenario EightBasicsWithElectrodeFirst = new()
    {
        name = "8 Basics with Electrode going first",
        deck = Decks.EightBasicsWithElectrode,
        Player = new PikachuPlayerFirst(),
    };
    
    public static Scenario EightBasicsSecond = new()
    {
        name = "8 Basics going second",
        deck = Decks.EightBasics,
        Player = new PikachuPlayerSecond(),
    };
    
    public static Scenario EightBasicsFirst = new()
    {
        name = "8 Basics going first",
        deck = Decks.EightBasics,
        Player = new PikachuPlayerFirst(),
    };
    
    public static Scenario SixBasicsWithElectrodeSecond = new()
    {
        name = "6 Basics with Electrode going second",
        deck = Decks.SixBasicsWithElectrode,
        Player = new PikachuPlayerSecond(),
    };
    
    public static Scenario SixBasicsWithElectrodeFirst = new()
    {
        name = "6 Basics with Electrode going first",
        deck = Decks.SixBasicsWithElectrode,
        Player = new PikachuPlayerFirst(),
    };
    
    public static Scenario SixBasicsSecond = new()
    {
        name = "6 Basics going second",
        deck = Decks.EightBasics,
        Player = new PikachuPlayerSecond(),
    };
    
    public static Scenario SixBasicsFirst = new()
    {
        name = "6 Basics going first",
        deck = Decks.SixBasics,
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