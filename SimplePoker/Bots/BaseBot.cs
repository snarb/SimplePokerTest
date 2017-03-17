using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePoker.Bots
{
    public abstract class BaseBot
    {
        protected Hand Hand { get; }

        protected Random Rnd { get; }

        public BaseBot(Hand hand)
        {
            Hand = hand;
            Rnd = new Random();
        }

        public abstract long MakeMove(OpponentsState opState);
    }
}
