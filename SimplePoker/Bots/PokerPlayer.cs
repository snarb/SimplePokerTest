using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SimplePoker.Bots
{
    public abstract class PokerPlayer
    {
        private const long StartBalance = GameProcessor.SmallBlindSize * 1000;

        public Rank Rank;

        public long Balance = StartBalance;

        public bool InGame { get; set; }

        protected Random Rnd { get; }

        protected PokerPlayer()
        {
            InGame = true;
            Rnd = new Random();
        }

        public abstract long MakeMove(OpponentsState opState);
    }
}
