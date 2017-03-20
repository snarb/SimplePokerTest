using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePoker.Bots
{
    class LinearLearningBot : PokerPlayer
    {
        const double STD = 2.0;
        private const double BoostRate = 5.0;
        readonly double _std;


        public LinearLearningBot(double std = STD)
        {
            _std = std;
        }

        public override long MakeMove(OpponentsState opState)
        {
            double rndVal = Rnd.NextGaussian((double)Rank, _std);
            rndVal = Math.Max(0, rndVal);
            double val = rndVal * BoostRate / Enum.GetNames(typeof(Rank)).Length;
            return  (long)val;
        }
    }
}
