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
        private const string DrawSymbol = "U";
        private readonly string bet;
        private int homeGoals = 0;
        private int awayGoals = 0;

        public bool IsRunning { get; private set; }
        public Match(string bet)
        {
            this.bet = bet;
            this.IsRunning = true;
        }

        public void AddGoal(bool isHomeTeam)
        {
            _ = isHomeTeam ? this.homeGoals++ : this.awayGoals++;
        }

        public bool IsBetCorrect()
        {
            return this.bet.Contains(this.homeGoals == this.awayGoals ? DrawSymbol : this.homeGoals > this.awayGoals ? HomeSymbol : AwaySymbol);
        }

        public void Stop()
        {
            this.IsRunning = false;
        }

        public string GetScore()
        {
            return $"{homeGoals} - {awayGoals}";
        }

        public string GetResult()
        {
            return homeGoals == awayGoals ? "U" : homeGoals > awayGoals ? HomeSymbol : AwaySymbol;
        }
    }
}
