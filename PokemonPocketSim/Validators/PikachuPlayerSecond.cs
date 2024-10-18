namespace PokemonPocketSim;

public class PikachuPlayerSecond : Player
{
    public PikachuPlayerSecond()
    {
        playTurns = new List<Func<List<Card>, List<Card>, bool>>();
        playTurns.Add(Turn0);
        playTurns.Add(Turn1WithEnergy);
        for (int i = 0; i < 18; i++)
        {
            playTurns.Add(Turn2);            
        }
    }
    
    public bool Turn0(List<Card> hand, List<Card> deck)
    {
        // prioritize PikachuEx
        var pikachuEx = hand.Find(c => c is PikachuEx);
        if (pikachuEx != null)
        {
            pikachuEx.Play(hand, deck);
            GameState.ActivePokemon = pikachuEx;
        }
        
        // prioritize Voltorb
        var voltorb = hand.Find(c => c is Voltorb);
        if (voltorb != null && GameState.ActivePokemon == null)
        {
            voltorb.Play(hand, deck);
            GameState.ActivePokemon = voltorb;
        }
        
        var basics = hand.FindAll(c => c.cardType == CardType.Basic);
        foreach (var basic in basics)
        {
            if (GameState.ActivePokemon == null)
            {
                GameState.ActivePokemon = basic;
            }
            else
            {
                GameState.BenchPokemon.Add(basic);
            }
            
            basic.Play(hand, deck);
            
            // leave room for PikachuEx to be played
            if (GameState.BenchPokemon.Count == 2 && GameState.ActivePokemon is not PikachuEx)
            {
                break;
            }
            
            if (GameState.BenchPokemon.Count == 3)
            {
                break;
            }
        }

        return false;
    }

    public bool Turn1WithoutEnergy(List<Card> hand, List<Card> deck)
    {
        var pokeballs = hand.FindAll(c => c is PokeBall);
        foreach (var pokeball in pokeballs)
        {
            pokeball.Play(hand, deck);
        }
        
        var oak = hand.Find(c => c is ProfessorsResearch);
        oak?.Play(hand, deck);
        
        // may draw Pokeball
        pokeballs = hand.FindAll(c => c is PokeBall);
        foreach (var pokeball in pokeballs)
        {
            pokeball.Play(hand, deck);
        }
        
        // evolve Voltorb (only if is active)
        var electrode = hand.Find(c => c is Electrode);
        if (electrode != null && GameState.ActivePokemon is Voltorb)
        {
            electrode.energy = GameState.ActivePokemon.energy;
            electrode.Play(hand, deck);
            GameState.ActivePokemon = electrode;
        }
        
        // prioritize PikachuEx to bench
        var pikachuEx = hand.Find(c => c is PikachuEx);
        if (pikachuEx != null && GameState.BenchPokemon.Count < 3)
        {
            pikachuEx.Play(hand, deck);
            GameState.BenchPokemon.Add(pikachuEx);
        }
        
        
        // play basics
        var basics = hand.FindAll(c => c.cardType == CardType.Basic);
        foreach (var basic in basics)
        {
            // leave room for PikachuEx to be played
            if (GameState.BenchPokemon.Count == 2 && GameState.ActivePokemon is not PikachuEx && GameState.BenchPokemon.Find(c => c is PikachuEx) == null)
            {
                break;
            }
            
            if (GameState.BenchPokemon.Count == 3)
            {
                break;
            }
            
            GameState.BenchPokemon.Add(basic);
            basic.Play(hand, deck);
        }

        return false;
    } 
    
    public bool Turn1WithEnergy(List<Card> hand, List<Card> deck)
    {
        Turn1WithoutEnergy(hand, deck);
        
        // play energy
        if (GameState.ActivePokemon is PikachuEx)
        {
            GameState.ActivePokemon.energy++;
        } 
        else
        {
            var pikachuEx = GameState.BenchPokemon.Find(c => c is PikachuEx);
            if (pikachuEx != null && pikachuEx.energy < 2)
            {
                pikachuEx.energy++;
            } 
            else
            {
                GameState.ActivePokemon!.energy++;
            }
        }
        
        return false;
    }

    public bool Turn2(List<Card> hand, List<Card> deck)
    {
        Turn1WithEnergy(hand, deck);
        
        // switch to PikachuEx
        var benchedPikachuEx = GameState.BenchPokemon.Find(c => c is PikachuEx);
        var XSpeed = hand.Find(c => c is XSpeed);
        if (GameState.ActivePokemon is not PikachuEx && benchedPikachuEx != null )
        {
            // free retreat
            if (GameState.ActivePokemon!.retreatCost == 0)
            {
                switchToPikachuEx(false);
            }
            else if (GameState.ActivePokemon.energy >= GameState.ActivePokemon.retreatCost)
            {
                switchToPikachuEx(false);
            }
            else if (XSpeed != null && GameState.ActivePokemon.energy >= GameState.ActivePokemon.retreatCost - 1)
            {
                XSpeed.Play(hand, deck);
                switchToPikachuEx(true);
            }
        }

        return false;
    }
    
    private void switchToPikachuEx(bool xSpeed)
    {
        var benchedPikachuEx = GameState.BenchPokemon.Find(c => c is PikachuEx);
        Logger.Log($"Switching out {GameState.ActivePokemon} to {benchedPikachuEx}");
        GameState.ActivePokemon!.energy -= GameState.ActivePokemon.retreatCost - (xSpeed ? 1 : 0);
        GameState.BenchPokemon.Add(GameState.ActivePokemon);
        GameState.ActivePokemon = benchedPikachuEx;
        GameState.BenchPokemon.Remove(benchedPikachuEx!);
    }

    protected override bool validate()
    {
        string benchedPokemon = GameState.BenchPokemon.Aggregate<Card?, string>(null!, (current, bp) => current + $"({bp!.name} E: {bp.energy})");
        Logger.Log($"Active: ({GameState.ActivePokemon} E: {GameState.ActivePokemon!.energy}) Bench: {benchedPokemon}");
        return GameState.ActivePokemon is PikachuEx && GameState.ActivePokemon.energy >= 2 && GameState.BenchPokemon.Count == 3;
    }
}