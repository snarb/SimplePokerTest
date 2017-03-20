using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePoker.Bots;

namespace SimplePoker
{
    public struct Move
    {
        public Move(double bet, PokerPlayer bot)
        {
            Bet = bet;
            Bot = bot;
        }

        public PokerPlayer Bot { get; }
        public double Bet { get; }
    }
}
