using System;


namespace BettingSlip
{
    class Matches
    {
        private Match[] matches;
        public Matches(string betsText, int matchAmount = 12)
        {
            // Determine bets and matches.
            string[] bets = betsText.Split(',');
            this.matches = new Match[matchAmount];

            // Populate list of matches:
            for (int i = 0; i < matchAmount; i++)
            {
                this.matches[i] = new Match(bets[i]);
            }
        }

        public void AddGoal(int matchNo, bool isHomeTeam)
        {
            matches[matchNo - 1].AddGoal(isHomeTeam);
        }

        public void ShowAllScores()
        {

            for (int index = 0; index < matches.Length; index++)
            {
                var match = matches[index];


                Console.WriteLine($"Kamp {index + 1}: {match.GetScore()} - {(match.IsBetCorrect() ? "riktig" : "feil")}");
            }
        }

        public void ShowCorrectCount()
        {
            int correctCount = 0;
            foreach (Match match in this.matches)
            {
                if (match.IsBetCorrect()) correctCount++;
            }

            Console.WriteLine($"Du har {correctCount} rette.");
        }
    }
}
