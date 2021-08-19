using System;

namespace BettingSlip
{
    class Program
    {
        static void Main(string[] args)
        {
            int matchAmount = 12;
            //Console.Write("Gyldig tips: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB\r\nHva har du tippet for denne kampen? ");
            //Console.Write("Valid tip: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB\r\nHva har du tippet for denne kampen? ");

            //var bet = Console.ReadLine();

            // Match
            //Match match = new(bet);

            // Show result.
            //var isBetCorrectText = match.IsBetCorrect() ? "riktig" : "feil";
            //Console.WriteLine($"Du tippet {isBetCorrectText}");

            // Show info.
            Console.WriteLine("Gyldig tips:");
            Console.WriteLine("- H, U, B");
            Console.WriteLine("- halvgardering: HU, HB, UB");
            Console.WriteLine("- helgardering: HUB");

            // Take input.
            Console.Write("Skriv inn dine 12 tips med komma mellom: ");
            
            Matches matches = new(Console.ReadLine(), matchAmount);

            while (true)
            {
                Console.WriteLine($"Skriv kampnr. 1-{matchAmount} for scoring eller X for alle kampene er ferdige");

                // Take input.
                Console.Write("Angi kommando: ");
                var command = Console.ReadLine();

                if (command == "X") break;

                var matchNo = Convert.ToInt32(command);

                Console.WriteLine($"Scoring i kamp {matchNo}.");
                Console.Write($"Skriv H for hjemmelag eller B for bortelag: ");

                var team = Console.ReadLine();
                matches.AddGoal(matchNo, team == "H");
                
                // Print results.
                matches.ShowAllScores();
                matches.ShowCorrectCount();
            }
        }
    }
}
