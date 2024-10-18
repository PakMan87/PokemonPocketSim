namespace PokemonPocketSim;

public abstract class Card
{
    public string name = "";
    public CardType cardType;
    public int retreatCost = 0;
    public int energy = 0;

    public override string ToString()
    {
        return name;
    }

    public void Play(List<Card> hand, List<Card> deck)
    {
        Logger.Log($"Played {ToString()}");
        hand.Remove(this);
        PlayInternal(hand, deck);
    }

    protected virtual void PlayInternal(List<Card> hand, List<Card> deck) { }
}

public enum CardType
{
    Basic,
    Stage1,
    Stage2,
    Trainer,
    Item
}

public class PikachuEx : Card
{
    public PikachuEx()
    {
        name = "Pikachu EX";
        cardType = CardType.Basic;
        retreatCost = 1;
    }
}

public class ZapdosEx : Card
{
    public ZapdosEx()
    {
        name = "Zapdos EX";
        cardType = CardType.Basic;
        retreatCost = 1;
    }
}

public class Pikachu : Card
{
    public Pikachu()
    {
        name = "Pikachu";
        cardType = CardType.Basic;
        retreatCost = 1;
    }
}

public class Raichu : Card
{
    public Raichu()
    {
        name = "Raichu";
        cardType = CardType.Stage1;
        retreatCost = 1;
    }
}

public class Voltorb : Card
{
    public Voltorb()
    {
        name = "Voltorb";
        cardType = CardType.Basic;
        retreatCost = 1;
    }
}

public class Electrode : Card
{
    public Electrode()
    {
        name = "Electrode";
        cardType = CardType.Stage1;
        retreatCost = 0;
    }
}

public class Electabuzz : Card
{
    public Electabuzz()
    {
        name = "Electabuzz";
        cardType = CardType.Basic;
        retreatCost = 1;
    }
}

public class Pincurchin : Card
{
    public Pincurchin()
    {
        name = "Pincurchin";
        cardType = CardType.Basic;
        retreatCost = 1;
    }
}

public class Blitzle : Card
{
    public Blitzle()
    {
        name = "Blitzle";
        cardType = CardType.Basic;
        retreatCost = 1;
    }
}

public class Zebstrika : Card
{
    public Zebstrika()
    {
        name = "Zebstrika";
        cardType = CardType.Stage1;
        retreatCost = 1;
    }
}

public class PokeBall : Card
{
    public PokeBall()
    {
        name = "Poke Ball";
        cardType = CardType.Item;
    }

    protected override void PlayInternal(List<Card> hand, List<Card> deck)
    {
        var basic = deck.Find(c => c.cardType == CardType.Basic);
        if (basic != null)
        {
            Logger.Log($"Pokeball got a {basic}");
            deck.Remove(basic);
            hand.Add(basic);
            Utils.Shuffle(deck);
        }
    }
}

public class ProfessorsResearch : Card
{
    public ProfessorsResearch()
    {
        name = "Professor's Research";
        cardType = CardType.Trainer;
    }

    protected override void PlayInternal(List<Card> hand, List<Card> deck)
    {
        if (deck.Count < 2)
        {
            Logger.Log("No cards left in deck");
            return;
        }
        var cards = deck.Take(2);
        Logger.Log($"Professor's Research got {string.Join(", ", cards)}");
        hand.AddRange(cards);
        deck.RemoveRange(0, 2);
    }
}

public class Sabrina : Card
{
    public Sabrina()
    {
        name = "Sabrina";
        cardType = CardType.Trainer;
    }
}

public class LtSurge : Card
{
    public LtSurge()
    {
        name = "Lt. Surge";
        cardType = CardType.Trainer;
    }
}

public class Potion : Card
{
    public Potion()
    {
        name = "Potion";
        cardType = CardType.Item;
    }
}

public class XSpeed : Card
{
    public XSpeed()
    {
        name = "X Speed";
        cardType = CardType.Item;
    }
}

public class Giovanni : Card
{
    public Giovanni()
    {
        name = "Giovanni";
        cardType = CardType.Trainer;
    }
}

public class RedCard : Card
{
    public RedCard()
    {
        name = "Red Card";
        cardType = CardType.Item;
    }
}