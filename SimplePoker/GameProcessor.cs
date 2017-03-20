using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using SimplePoker.Bots;

namespace SimplePoker
{
    public class GameProcessor
    {
        private const int MaxRoundsCount = 3;
        public const int BigBlindSize = 10;
        public const int SmallBlindSize = 5;
        public List<PokerPlayer> Bots { get; }

        readonly Random _rnd = new Random();
        readonly List<Rank> _ranks = Enum.GetValues(typeof(Rank)).OfType<Rank>().ToList();
        readonly OpponentsState _state = new OpponentsState();
        private int _bigBlindIndex = 0;
        private int _smallBlindIndex = 1;


        public GameProcessor(List<PokerPlayer> players)
        {
            Bots = players;
        }

        private void MoveBlind(ref int index)
        {
            if (index == Bots.Count - 1)
                index = 0;
            else
                index++;

        }
        public void NextGame()
        {
            MoveBlind(ref _bigBlindIndex);
            MoveBlind(ref _smallBlindIndex);

            var ranks = _ranks.OrderBy(x => _rnd.Next()).Take(Bots.Count).ToList();
            for (int i = 0; i < Bots.Count; i++)
            {
                Bots[i].Rank = ranks[i];
                Bots[i].InGame = true;
            }

            long totalBets = RunGame();
            PokerPlayer winner = Bots.Where(bot => bot.InGame).MaxBy(bot => bot.Rank);
            winner.Balance += totalBets;
        }

        private long RoundBet(double bet)
        {
            return (long)(bet / SmallBlindSize);
        }

        private long RunGame()
        {
            int inGameLeft = Bots.Count;
            long totalBets = 0;
            long lastSmallBlind = 0;

            totalBets += BigBlindSize;
            Bots[_bigBlindIndex].Balance -= BigBlindSize;

            totalBets += SmallBlindSize;
            Bots[_smallBlindIndex].Balance -= SmallBlindSize;

            for (int i = 0; i < MaxRoundsCount; i++)
            {
                foreach (var bot in Bots)
                {
                    if (bot.InGame)
                    {
                        double bet = bot.MakeMove(_state);
                        long smallBlindsCount = RoundBet(bet);
                        totalBets += smallBlindsCount;

                        if (smallBlindsCount < lastSmallBlind)
                        {
                            bot.InGame = false;
                            if (inGameLeft == 1)
                                return totalBets;

                            continue;
                        }

                        bot.Balance -= smallBlindsCount * SmallBlindSize;
                        _state.Bets.Add(new Move(lastSmallBlind, bot));
                        lastSmallBlind = smallBlindsCount;
                    }
                }
            }

            return totalBets;
        }
    }
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