using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinPuzzle
{
    public enum CoinSide
    {
        HEAD,
        TAIL
    }

    class Coin
    {
        private CoinSide sideUp;

        public CoinSide SideUp
        {
            get { return sideUp; }
        }

        public Coin()
        {
            sideUp = CoinSide.HEAD;
        }

        public void FlipCoin()
        {
            sideUp = (sideUp == CoinSide.HEAD) ? CoinSide.TAIL : CoinSide.HEAD;
        }
    }
}
