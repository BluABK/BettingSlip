using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSlip
{
    class Match
    {
        private int homeGoals = 0;
        private int awayGoals = 0;
        private bool matchIsRunning = true;
        private readonly string result;
        public Match()
        {
            while (matchIsRunning)
            {
                Console.Write("Kommandoer: \r\n - H = scoring hjemmelag\r\n - B = scoring bortelag\r\n - X = kampen er ferdig\r\nAngi kommando: ");
                var command = Console.ReadLine();

                matchIsRunning = command != "X";
                if (command == "H") homeGoals++;
                else if (command == "B") awayGoals++;

                Console.WriteLine($"Stillingen er {homeGoals}-{awayGoals}.");
            }

            // Determine result.
            result = homeGoals == awayGoals ? "U" : homeGoals > awayGoals ? "H" : "B";
        }

        public string GetResult()
        {
            return result;
        }
    }
}
