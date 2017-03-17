using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePoker
{
    public class Hand
    {
        public Rank Rank;

        public long Balance;

        public HandId Id { get; }

        public Hand(HandId id, long startBalance)
        {
            this.Id = id;
            this.Balance = startBalance;
        }
    }
}
