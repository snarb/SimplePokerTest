using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePoker.Bots;

namespace SimplePoker
{
    class Program
    {
        static void Main(string[] args)
        {
            List <PokerPlayer> players = new List<PokerPlayer>() { new RndBot(), new LinearLearningBot(), new RndBot()};
            GameProcessor proc = new GameProcessor(players);
            proc.NextGame();
            //List<Dictionary<Rank, long>> stats = new List<Dictionary<Rank, long>>();
            //for (long i = 0; i < 1000000; i++)
            //{
            //    proc.NextGame();
            //    foreach (Hand hand in proc.Hands)
            //    {
            //        //Console.WriteLine(hand.Rank);
            //        Dictionary<Rank, long> curStats = stats[(int)hand.Id];
            //        if (!curStats.ContainsKey(hand.Rank))
            //            curStats.Add(hand.Rank, 0);

            //        curStats[hand.Rank] += 1;
            //    }

            //    //Console.WriteLine("------------------");
            //}

            Console.WriteLine("Done");
        }
    }
}
