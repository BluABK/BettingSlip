using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSlip
{
    class Match
    {
        private const string AbortSymbol = "X";
        private const string HomeSymbol = "H";
        private const string AwaySymbol = "B";
        private string bet;
        private int homeGoals = 0;
        private int awayGoals = 0;
        private bool matchIsRunning = true;
        private string result;
        public bool IsRunning { get; private set; }
        public Match(string bet)
        {
            // Store the bet.
            this.bet = bet;

            // Play the match.
            Play();

            // Determine result.
            result = homeGoals == awayGoals ? "U" : homeGoals > awayGoals ? HomeSymbol : AwaySymbol;
        }

        public void Play()
        {
            this.matchIsRunning = true;

            while (matchIsRunning)
            {
                // Print commands.
                Console.Write($"Kommandoer: \r\n - {HomeSymbol} = scoring hjemmelag\r\n - {AwaySymbol} = scoring bortelag\r\n - {AbortSymbol} = kampen er ferdig\r\nAngi kommando: ");
                // Take user input.
                var command = Console.ReadLine();

                // If user entered abort symbol, end the match.
                if (command == AbortSymbol)
                {
                    // Stop the match.
                    Stop();

                    // Immediately return from the while loop.
                    return;
                }

                AddGoal(command == HomeSymbol);

                PrintStatus();
            }
        }

        private void PrintStatus()
        {
            Console.WriteLine($"Stillingen er {homeGoals}-{awayGoals}.");
        }

        public void AddGoal(bool isHomeTeam)
        {
            _ = isHomeTeam ? this.homeGoals++ : this.awayGoals++;
        }

        public bool IsBetCorrect()
        {
            return this.bet.Contains(this.result);
        }

        public void Stop()
        {
            this.matchIsRunning = false;
        }

        public string GetScore()
        {
            return $"Stillingen er {homeGoals}-{awayGoals}.";
        }

        public string GetResult()
        {
            return result;
        }
    }
}
