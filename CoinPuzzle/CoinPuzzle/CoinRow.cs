using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinPuzzle
{
    class CoinRow
    {
        private const int ROWSIZE = 5;
        private Coin[] Coins;

        public CoinRow()
        {
            Coins = new Coin[ROWSIZE];

            // extra code to go here
            for(int i = 0; i < Coins.Length; i++)
            {
                Coins[i] = new Coin();
            }
        }

        /// <summary>
        /// Randomly use the 3 operations to scramble the coin row 
        /// </summary>
        public void ScrambleRow()
        {
            // set up random object and initialise with time seed
            Random r = new Random(Environment.TickCount);

            int move;
            for (int i = 0; i < ROWSIZE; i++)
            {
                // generate a random number of 0 to 2
                move = r.Next(3);

                if (move == 0) Operation1();
                else if (move == 1) Operation2();
                else Operation3();
            }
        }

        /// <summary>
        /// Flip coins 1, 2  and 5
        /// </summary>
        public void Operation1()
        {
            // complete this method
            if (Coins.Length > 4)
            {
                Coins[0].FlipCoin();
                Coins[1].FlipCoin();
                Coins[4].FlipCoin();
            }
        }

        /// <summary>
        /// If coin 1 is heads, flip coins 2 and 3, else flip coins 3 and 4
        /// </summary>
        public void Operation2()
        {
            if (Coins[0].SideUp == CoinSide.HEAD)
            {
                Coins[1].FlipCoin();
                Coins[2].FlipCoin();
            }
            else
            {
                Coins[2].FlipCoin();
                Coins[3].FlipCoin();
            }
        }

        /// <summary>
        /// Swap coins 1 and 4
        /// </summary>
        public void Operation3()
        {
            // complete this method
            Coin temp = Coins[0];
            Coins[0] = Coins[3];
            Coins[3] = temp;
        }

        /// <summary>
        /// Print all the coins in the row
        /// </summary>
        public void PrintCoin()
        {
            // print the coins in the row
            for (int i=0; i<ROWSIZE; i++)
            {
                if (Coins[i].SideUp == CoinSide.HEAD)
                    Console.Write("H");
                else
                    Console.Write("T");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Return true if all the coins in the row are head up, otherwise return false
        /// </summary>
        /// <returns></returns>
        public bool AllHeadsUp()
        {
            for (int i = 0; i < ROWSIZE; i++)
            {
                if (Coins[i].SideUp != CoinSide.HEAD) return false;
            }
            return true;
        }
    }
}
