using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePoker.Bots
{
    class LinearLearningBot : BaseBot
    {
        const double STD = 2.0;
        readonly double _std;


        public LinearLearningBot(Hand hand, double std = STD) : base(hand)
        {
            _std = std;
        }

        public override long MakeMove(OpponentsState opState)
        {
            double rndVal = Rnd.NextGaussian((double)Hand.Rank, _std);
            double val = rndVal * Hand.Balance / Enum.GetNames(typeof(Rank)).Length;
            return (long)val;
        }
    }
}
