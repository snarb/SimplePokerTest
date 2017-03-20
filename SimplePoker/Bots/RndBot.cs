using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimplePoker.Bots
{
    class RndBot : PokerPlayer
    {
        private int spliteRate = 20;

        public RndBot()
        {
        }

        public override long MakeMove(OpponentsState opState)
        {
            return Rnd.LongRandom(0, Balance / spliteRate);
        }
    }
}
