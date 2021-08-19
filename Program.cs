using System;

namespace BettingSlip
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Gyldig tips: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB\r\nHva har du tippet for denne kampen? ");
            Console.Write("Valid tip: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB\r\nHva har du tippet for denne kampen? ");
            
            var bet = Console.ReadLine();

            Match match = new();

            var isBetCorrect = bet.Contains(match.GetResult());
            var isBetCorrectText = isBetCorrect ? "riktig" : "feil";
            
            Console.WriteLine($"Du tippet {isBetCorrectText}");
        }
    }
}
