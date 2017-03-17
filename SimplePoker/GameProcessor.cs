using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePoker.Bots;

namespace SimplePoker
{
    public class GameProcessor
    {
        const int BigBlindSize = 10;
        const int SmallBlindSize = 5;
        const long StartBalance = 0;
        public List<Hand> Hands { get; }
        public List<BaseBot> Bots { get; }


        HandId _bigBlindHand = HandId.Zero;
        Round _currentRound = Round.PreFlop;
        readonly Random _rnd = new Random();
        readonly List<Rank> _ranks = Enum.GetValues(typeof(Rank)).OfType<Rank>().ToList();

        public GameProcessor(Round currentRound, BaseBot botOne, BaseBot botTwo, BaseBot botThree)
        {
            _currentRound = currentRound;
            Hand zeroHand = new Hand(HandId.Zero, StartBalance);
            Hand firstHand = new Hand(HandId.One, StartBalance);
            Hand secondHand = new Hand(HandId.Two, StartBalance);
            Hands = new List<Hand> { zeroHand, firstHand, secondHand };
            Bots = new List<BaseBot> { botOne, botTwo, botThree};
        }

        public void NextGame()
        {
            if (_bigBlindHand == HandId.Two)
                _bigBlindHand = HandId.Zero;
            else
                _bigBlindHand++;

            var ranks = _ranks.OrderBy(x => _rnd.Next()).Take(Enum.GetValues(typeof(HandId)).Length).ToList();
            for (int i = 0; i < Hands.Count; i++)
            {
                Hands[i].Rank = ranks[i];
            }


            //var needed = Enum.GetValues(typeof(HandId)).Length;
            //var available = Enum.GetValues(typeof(Rank)).Length;
            //while (needed > 0)
            //{
            //    double rndVal = _rnd.NextDouble();
            //    double prob = (double)needed / available;
            //    if (rndVal < prob)
            //    {
            //        Hands[needed - 1].Rank = (Rank)(available - 1);
            //        needed--;
            //    }

            //    available--;
            //}
        }

    }
}
