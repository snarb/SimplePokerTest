using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimplePoker.Bots
{
    class RndBot : PokerPlayer
    {
        private int MaxBet = 20;

        public RndBot()
        {
        }

        public override long MakeMove(OpponentsState opState)
        {
            long res = Rnd.Next(MaxBet);
            //long res = Rnd.LongRandom(0, MaxBet);
            return res;
        }
    }
}
