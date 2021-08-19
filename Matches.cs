using System;


namespace BettingSlip
{
    class Matches
    {
        private string[] bets;
        private Match[] matches;
        public Matches(int matchAmount = 12)
        {
            // Show info.
            Console.Write("Gyldig tips: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB\r\nSkriv inn dine 12 tips med komma mellom: ");

            // Take input.
            string betsText = Console.ReadLine();
            
            // Determine bets and matches.
            this.bets = betsText.Split(',');
            this.matches = new Match[matchAmount];

            // Populate list of matches:
            for (int i = 0; i < matchAmount; i++)
            {
                this.matches[i] = new Match(this.bets[i]);
            }

            while (true)
            {
                Console.Write("Skriv kampnr. 1-12 for scoring eller X for alle kampene er ferdige\r\nAngi kommando: ");
                var command = Console.ReadLine();

                if (command == "X") break;

                var matchNo = Convert.ToInt32(command);
                Console.Write($"Scoring i kamp {matchNo}. \r\nSkriv H for hjemmelag eller B for bortelag: ");

                var team = Console.ReadLine();
                var selectedIndex = matchNo - 1;
                var selectedMatch = matches[selectedIndex];

                selectedMatch.AddGoal(team == "H");

                var correctCount = 0;

                for (var index = 0; index < matches.Length; index++)
                {
                    var match = matches[index];
                    var mathNo = index + 1;
                    var isBetCorrect = match.IsBetCorrect();
                    var isBetCorrectText = isBetCorrect ? "riktig" : "feil";

                    if (isBetCorrect) correctCount++;

                    Console.WriteLine($"Kamp {matchNo}: {match.GetScore()} - {isBetCorrectText}");
                }

                Console.WriteLine($"Du har {correctCount} rette.");
            }
        }
    }
}
