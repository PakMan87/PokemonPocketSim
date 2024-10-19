using System.Globalization;

namespace PokemonPocketSim;

class Program
{
    static void Main()
    {
        Logger.verbose = false;

        var scenarios = new List<Scenario>()
        {
            Scenarios.SecondPlaceGoingFirst,
            Scenarios.SecondPlaceGoingSecond,
            Scenarios.FourthPlaceGoingFirst,
            Scenarios.FourthPlaceGoingSecond,
            Scenarios.FifthPlaceGoingFirst,
            Scenarios.FifthPlaceGoingSecond,
            Scenarios.EighthPlaceGoingFirst,
            Scenarios.EighthPlaceGoingSecond,
            Scenarios.PikachuExRaichuVoltorbFirst,
            Scenarios.PikachuExRaichuVoltorbSecond,
        };

        foreach (var scenario in scenarios)
        {
            Console.WriteLine($"\nTesting {scenario.name} scenario");

            var deck = scenario.deck;
            var validator = scenario.Player;

            var totalRuns = 0;
            var completedTurns = new int[20];

            for (int i = 0; i < (Logger.verbose ? 1 : 10000); i++)
            {
                var thisDeck = new List<Card>(deck); 
                Utils.Shuffle(thisDeck);
                var turn = validator!.PlayGame(thisDeck);
                completedTurns[turn]++;
                totalRuns++;
            }

            Console.WriteLine();
            var format = new NumberFormatInfo();
            format.NumberDecimalDigits = 2;
            for (int i = 0; i < completedTurns.Length; i++)
            {
                if (completedTurns[i] == 0)
                {
                    continue;
                }
                Console.WriteLine($"Turn {i}: {(completedTurns[i] / (double) totalRuns * 100).ToString("N", format)}%");
            }
            Console.WriteLine();
        }
    }
}