using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogRace
{
    class Bet
    {
        public int amount;
        public int dog;
        public Guy bettor;

        public Bet(Guy _bettor)
        {
            bettor = _bettor;
        }
        public string GetDescription()
        {
            if(amount > 0) return bettor.name + " bets " + amount + " bucks on dog #" + dog;
            return bettor.name + " hasn't placed a bet";
        }

        public int PayOut(int winner)
        {
            if (dog == winner) return amount;
            return -amount;
        }
    }
}
