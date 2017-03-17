using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimplePoker.Bots
{
    class RndBot : BaseBot
    {
        public RndBot(Hand hand) : base(hand)
        {
        }

        public override long MakeMove(OpponentsState opState)
        {
            return Rnd.LongRandom(0, Hand.Balance);
        }
    }
}
