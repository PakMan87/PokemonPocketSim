namespace PokemonPocketSim;

public abstract class Player
{
    protected List<Func<List<Card>, List<Card>, bool>> playTurns;
    
    public int PlayGame(List<Card> deck)
    {
        resetGameState(deck);
        
        var turn = 0;
        var hand = drawHand(deck);
        
        foreach (var playTurn in playTurns)
        {
            Logger.Log($"\nTurn {turn}");
            if (turn != 0)
            {
                // Darw a card
                if (deck.Count == 0)
                {
                    Logger.Log($"No cards left in deck");
                }
                else
                {
                    var card = deck.First();
                    Logger.Log($"Drew {card}");
                    hand.Add(card);
                    deck.RemoveAt(0);   
                }
            }
            
            Logger.Log($"Hand: {string.Join(", ", hand)}");
            playTurn.Invoke(hand, deck);
            
            if (validate())
            {
                break;
            }
            
            turn++;
        }

        return turn;
    }

    protected abstract bool validate();

    private List<Card> drawHand(List<Card> deck)
    {
        var hand = deck.Take(5).ToList();
        // Starting hand must contain at least one basic Pokemon
        while (hand.Find(c => c.cardType == CardType.Basic) == null)
        {
            Utils.Shuffle(deck);
            hand = deck.Take(5).ToList();
        }
        
        deck.RemoveRange(0, 5);
        return hand;
    } 

    private void resetGameState(List<Card> deck)
    {
        GameState.ActivePokemon = null;
        GameState.BenchPokemon = [];

        foreach (var card in deck)
        {
            card.energy = 0;
        }
    }
}